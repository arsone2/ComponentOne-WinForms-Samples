﻿using C1.Chart;
using C1.Win.Chart;
using CurrencyComparison.Model;
using CurrencyComparison.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using C1.Win.Chart.Interaction;

namespace CurrencyComparison
{
    public partial class MainForm : Form
    {
        #region ** Fields

        string _baseCurrency;
        MeasureMode _measureMode = MeasureMode.Both;
        TimeFrame _timeFrame = TimeFrame.SixMonths;
        DataTable _sourceTable;
        DataTable _dtExchangeRate;
        DataTable _dtPercentageChange;
        Dictionary<string, TimeFrame> _dictTimeFrame;
        Dictionary<string, bool> _visibilityState;
        List<Currency> _currencies;
        List<Color> _chartColors;
        DateTime _endPlotDate;
        DateTime _startPlotDate;
        Axis y2Main, y2Range;
        RangeSelector _rangeSelector;
        bool isChangeFromLegend;

        #endregion

        #region ** Init

        public MainForm()
        {
            InitializeComponent();
            Init();
            SetUpMainChart();
            SetUpRangeChart();
            //Start application with 6 month's data
            btnTimeFrameChanged(rb6Months, null);
            UpdateChartView();
        }

        private void Init()
        {
            _visibilityState = new Dictionary<string, bool>();

            //Initialize Chart Colors
            _chartColors = new List<Color>();
            _chartColors.Add(ColorTranslator.FromHtml("#2a9fd6"));
            _chartColors.Add(ColorTranslator.FromHtml("#77b300"));
            _chartColors.Add(ColorTranslator.FromHtml("#9933cc"));
            _chartColors.Add(ColorTranslator.FromHtml("#ff8800"));
            _chartColors.Add(ColorTranslator.FromHtml("#cc0000"));
            _chartColors.Add(ColorTranslator.FromHtml("#00cca3"));
            _chartColors.Add(ColorTranslator.FromHtml("#3d6dcc"));
            _chartColors.Add(ColorTranslator.FromHtml("#525252"));
            _chartColors.Add(ColorTranslator.FromHtml("#323232"));

            //Initialize TimeFrame dictionary values
            _dictTimeFrame = new Dictionary<string, TimeFrame>();
            _dictTimeFrame.Add("5D", TimeFrame.FiveDays);
            _dictTimeFrame.Add("10D", TimeFrame.TenDays);
            _dictTimeFrame.Add("1M", TimeFrame.OneMonth);
            _dictTimeFrame.Add("6M", TimeFrame.SixMonths);
            _dictTimeFrame.Add("1Y", TimeFrame.OneYear);
            _dictTimeFrame.Add("5Y", TimeFrame.FiveYears);
            _dictTimeFrame.Add("10Y", TimeFrame.TenYears);

            //Init Controls
            cbMeasure.Items.AddRange(AppResources.Measures.Split(','));
            cbMeasure.SelectedIndex = (int)_measureMode;
            imgLegend.Image = Resources.AppResources.ImgLegend;

            //Init Currencies
            _baseCurrency = AppResources.BaseCurrency;
            var currencies = AppResources.Currencies.Split(',');
            _currencies = new List<Currency>();
            foreach (string currency in currencies)
            {
                _currencies.Add(new Currency
                {
                    DisplayName = currency.Split('-')[0].Trim(),
                    Symbol = currency.Split('-')[1].Trim()
                });
            }

            cbCurrency.ItemsDataSource = _currencies;
            cbCurrency.ItemsDisplayMember = "DisplayName";
            cbCurrency.ItemsValueMember = "Symbol";
            cbCurrency.Value = _baseCurrency;

            //Init Data
            _sourceTable = HelperExtensions.ImportData();
            _endPlotDate = (DateTime)_sourceTable.Rows[0].ItemArray[0];
            _sourceTable = _sourceTable.FilterTableByDate(_endPlotDate.AddYears(-10));
            _dtExchangeRate = _sourceTable.ConvertToBase(_baseCurrency);
            _dtPercentageChange = _dtExchangeRate.ConvertToPercentage();
            _startPlotDate = (DateTime)_dtExchangeRate.Rows[_dtExchangeRate.Rows.Count - 1].ItemArray[0];

        }

        private void SetUpMainChart()
        {
            //Setup Main Chart
            chartMain.Series.Clear();
            chartMain.BackgroundImage = AppResources.Img_WaterMark_C1Logo;
            chartMain.BindingX = "Date";
            chartMain.ChartType = ChartType.Line;
            chartMain.LegendToggle = true;
            chartMain.Legend.Position = Position.Top;
            chartMain.AxisY.AxisLine = true;
            chartMain.AxisY.Title = AppResources.Y1Title;

            //Secondary Axis to display Percentage Change in currencies
            y2Main = new Axis();
            y2Main.Position = C1.Chart.Position.Right;
            y2Main.Title = AppResources.Y2Title;
            y2Main.Format = "P0";

            #region ** Series

            for (int i = 0; i < _currencies.Count; i++)
            {
                var currency = _currencies[i];
                currency.ExchangeRateSeries = new ChartSeries
                {
                    Binding = currency.Symbol,
                    Name = currency.Symbol,
                };
                currency.PercentageChangeSeries = new ChartSeries
                {
                    Binding = currency.Symbol,
                    Name = currency.Symbol,
                    IsPercentage = true,
                    AxisY = y2Main,
                };
                currency.ExchangeRateSeries.Style.StrokeColor = _chartColors[i % _chartColors.Count];
                currency.PercentageChangeSeries.Style.StrokeColor = _chartColors[i % _chartColors.Count];
                currency.PercentageChangeSeries.Style.StrokeDashPattern = new[] { 5f, 2f };

                //Set Initial Visibilities
                if (currency.Symbol == AppResources.InitialDsplayedCurrency)
                {
                    currency.ExchangeRateSeries.Visibility = SeriesVisibility.Visible;
                    currency.PercentageChangeSeries.Visibility = SeriesVisibility.Plot;

                    _visibilityState.Add(currency.Symbol, true);
                }
                else
                {
                    currency.ExchangeRateSeries.Visibility = SeriesVisibility.Legend;
                    currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden;
                    _visibilityState.Add(currency.Symbol, false);
                }
                chartMain.Series.Add(currency.ExchangeRateSeries);
                chartMain.Series.Add(currency.PercentageChangeSeries);
            }
            chartMain.SeriesVisibilityChanged += chartMain_SeriesVisibilityChanged;
            #endregion
        }

        private void SetUpRangeChart()
        {
            chartRangeSelector.ChartType = ChartType.Line;
            chartRangeSelector.Series.Clear();
            chartRangeSelector.ToolTip.Active = false;
            chartRangeSelector.AxisY.MajorGrid = false;
            chartRangeSelector.BindingX = "Date";

            y2Range = new Axis()
            {
                AxisLine = false,
                Title = string.Empty,
                Labels = false
            };

            foreach (var currency in _currencies)
            {
                ChartSeries s = new ChartSeries
                {
                    Binding = currency.Symbol,
                    Name = currency.Symbol,
                    Visibility = currency.ExchangeRateSeries.Visibility,
                    DataSource = _dtExchangeRate
                };
                ChartSeries p = new ChartSeries
                {
                    Binding = currency.Symbol,
                    Name = currency.Symbol,
                    IsPercentage = true,
                    AxisY = y2Range,
                    Visibility = currency.PercentageChangeSeries.Visibility,
                    DataSource = _dtPercentageChange
                };
                s.Style.StrokeColor = currency.ExchangeRateSeries.Style.StrokeColor;
                p.Style.StrokeColor = currency.PercentageChangeSeries.Style.StrokeColor;
                p.Style.StrokeDashPattern = currency.PercentageChangeSeries.Style.StrokeDashPattern;

                chartRangeSelector.Series.Add(s);
                chartRangeSelector.Series.Add(p);
            }

        }

        #endregion

        #region ** Implementation

        private void UpdateChart(TimeFrame timeFrame)
        {
            chartMain.BeginUpdate();
            _dtPercentageChange = _dtExchangeRate.ConvertToPercentage();
            foreach (var currency in _currencies)
            {
                currency.ExchangeRateSeries.DataSource = _dtExchangeRate;
                currency.PercentageChangeSeries.DataSource = _dtPercentageChange;

                foreach (var series in chartRangeSelector.Series.Where(s => s.Name.Equals(currency.Symbol)))
                {
                    series.DataSource = ((ChartSeries)series).IsPercentage ? _dtPercentageChange : _dtExchangeRate;
                }
            }
           chartMain.EndUpdate();
            switch (timeFrame)
            {
                case TimeFrame.FiveDays:
                    chartMain.AxisX.Min = _endPlotDate.AddBusinessDays(-5).ToOADate();
                    chartMain.AxisX.Format = "MMM dd yyyy";
                    break;
                case TimeFrame.TenDays:
                    chartMain.AxisX.Min = _endPlotDate.AddBusinessDays(-10).ToOADate();
                    chartMain.AxisX.Format = "MMM dd yyyy";
                    break;
                case TimeFrame.OneMonth:
                    chartMain.AxisX.Format = "MMM dd yyyy";
                    chartMain.AxisX.Min = _endPlotDate.AddMonths(-1).ToOADate();

                    break;
                case TimeFrame.SixMonths:
                    chartMain.AxisX.Format = "MMM dd yyyy";
                    chartMain.AxisX.Min = _endPlotDate.AddMonths(-6).ToOADate();
                    break;
                case TimeFrame.OneYear:
                    chartMain.AxisX.Format = "MMM yy";
                    chartMain.AxisX.Min = _endPlotDate.AddYears(-1).ToOADate();

                    break;
                case TimeFrame.FiveYears:
                    chartMain.AxisX.Format = "yyyy";
                    chartMain.AxisX.Min = _endPlotDate.AddYears(-5).ToOADate();

                    break;
                case TimeFrame.TenYears:
                    chartMain.AxisX.Format = "yyyy";
                    chartMain.AxisX.Min = _startPlotDate.ToOADate();

                    break;
            }
            chartMain.AxisX.Max = _endPlotDate.ToOADate();
        }

        private void UpdateGridLines()
        {
            chartMain.AxisY.MajorGrid = _measureMode != MeasureMode.PercentageChange;
            y2Main.MajorGrid = _measureMode == MeasureMode.PercentageChange;
        }

        private void UpdateChartView()
        {
            switch (_measureMode)
            {
                case MeasureMode.Both:
                    double max = 0;
                    foreach (var currency in _currencies)
                    {
                        if (Utils.IsVisible(currency.PercentageChangeSeries))
                        {
                            var seriesMax = currency.PercentageChangeSeries.GetValues(0).Max();
                            max = Math.Max(max, seriesMax);
                        }
                    }
                    y2Main.Max = max > 1 ? max + 0.5 : max + 0.2;
                    y2Range.Max = max > 1 ? max + 0.5 : max + 0.2;
                    break;
                case MeasureMode.PercentageChange:
                    y2Main.Max = double.NaN;
                    y2Range.Max = double.NaN;
                    break;
                case MeasureMode.ExchangeRate:
                    y2Main.Max = 0.0;
                    y2Range.Max = 0.0;
                    break;
            }

            UpdateGridLines();
    
        }

        private void UpdateVisibilityState(Currency currency)
        {
            _visibilityState[currency.Symbol] = Utils.IsVisible(currency.ExchangeRateSeries) || Utils.IsVisible(currency.PercentageChangeSeries);
        }

        private void UpdateToFromDates()
        {
            var from = DateTime.FromOADate(chartMain.AxisX.Min).ToShortDateString();
            var to = DateTime.FromOADate(chartMain.AxisX.Max).ToShortDateString();
            lblPeriod.Text = string.Format("Period:{0} to {1}", from, to);
        }

        private void chartRangeSelector_Rendered(object sender, RenderEventArgs e)
        {
            SetupRangeSelector();
        }

        private void SetupRangeSelector()
        {
            if (_rangeSelector != null)
                return;
            _rangeSelector = new RangeSelector(chartRangeSelector);
            _rangeSelector.LowerValue = chartMain.AxisX.Min;
            _rangeSelector.ValueChanged += rangeSelector_ValueChanged;
        }

        private void rangeSelector_ValueChanged(object sender, EventArgs e)
        {
            chartMain.AxisX.Min = _rangeSelector.LowerValue;
            chartMain.AxisX.Max = _rangeSelector.UpperValue;
            chartMain.AxisX.Format = string.Empty;

            UpdateToFromDates();

            //Reset the time frame buttons Color when range selector is used
            foreach (RadioButton control in pnlButtons.Controls)
                control.BackColor = Color.White;
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sourceTable == null)
                return;

            chartMain.SeriesVisibilityChanged -= chartMain_SeriesVisibilityChanged;
            isChangeFromLegend = false;

            var oldBaseCurrency = _baseCurrency;
            _baseCurrency = cbCurrency.SelectedItem.ToString();
            //Convert data as per the new base currency
            _dtExchangeRate = _sourceTable.ConvertToBase(_baseCurrency);
            UpdateChart(_timeFrame);

            var newBaseCurrencySeries = _currencies.First(c => c.Symbol.Equals(_baseCurrency));
            var oldBaseCurrencySeries = _currencies.First(c => c.Symbol.Equals(oldBaseCurrency));

            UpdateVisibilityState(newBaseCurrencySeries);

            switch (_measureMode)
            {
                case MeasureMode.ExchangeRate:
                    newBaseCurrencySeries.ExchangeRateSeries.Visibility = SeriesVisibility.Legend;
                    oldBaseCurrencySeries.ExchangeRateSeries.Visibility = _visibilityState[_baseCurrency] ? SeriesVisibility.Visible : SeriesVisibility.Legend;
                    break;
                case MeasureMode.PercentageChange:
                    newBaseCurrencySeries.PercentageChangeSeries.Visibility = SeriesVisibility.Legend;
                    oldBaseCurrencySeries.PercentageChangeSeries.Visibility = _visibilityState[_baseCurrency] ? SeriesVisibility.Visible : SeriesVisibility.Legend;
                    break;
                case MeasureMode.Both:
                    newBaseCurrencySeries.ExchangeRateSeries.Visibility = SeriesVisibility.Legend;
                    newBaseCurrencySeries.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden;
                    oldBaseCurrencySeries.ExchangeRateSeries.Visibility = _visibilityState[_baseCurrency] ? SeriesVisibility.Visible : SeriesVisibility.Legend;
                    oldBaseCurrencySeries.PercentageChangeSeries.Visibility = _visibilityState[_baseCurrency] ? SeriesVisibility.Plot : SeriesVisibility.Hidden;
                    break;
            }
            UpdateChartView();
            isChangeFromLegend = true;
            chartMain.SeriesVisibilityChanged += chartMain_SeriesVisibilityChanged;
        }

        private void cbMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartMain.SeriesVisibilityChanged -= chartMain_SeriesVisibilityChanged;
            isChangeFromLegend = false;
            if (_currencies != null)
            {
                _measureMode = (MeasureMode)cbMeasure.SelectedIndex;
                foreach (var currency in _currencies)
                {
                    switch (_measureMode)
                    {
                        case MeasureMode.ExchangeRate:
                            //Display ExchangeRate if %age change is already visbile
                            if (Utils.IsVisible(currency.PercentageChangeSeries))
                                currency.ExchangeRateSeries.Visibility = SeriesVisibility.Visible;
                            else
                                currency.ExchangeRateSeries.Visibility = SeriesVisibility.Legend;
                            //Hide %age Change
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden;
                            break;

                        case MeasureMode.PercentageChange:
                            //Display %age Change if the ExchangeRate is already visbile
                            if (Utils.IsVisible(currency.ExchangeRateSeries))
                                currency.PercentageChangeSeries.Visibility = SeriesVisibility.Visible;
                            else
                                currency.PercentageChangeSeries.Visibility = SeriesVisibility.Legend;
                            //Hide ExchangeRate
                            currency.ExchangeRateSeries.Visibility = SeriesVisibility.Hidden;
                            break;

                        case MeasureMode.Both:
                            if (Utils.IsVisible(currency.ExchangeRateSeries) || Utils.IsVisible(currency.PercentageChangeSeries))
                            {
                                currency.PercentageChangeSeries.Visibility = SeriesVisibility.Plot;
                                currency.ExchangeRateSeries.Visibility = SeriesVisibility.Visible;
                            }
                            else
                            {
                                currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden;
                                currency.ExchangeRateSeries.Visibility = SeriesVisibility.Legend;
                            }
                            break;
                    }
                }
                UpdateChartView();
            }
            isChangeFromLegend = true;
            chartMain.SeriesVisibilityChanged += chartMain_SeriesVisibilityChanged;
        }

        private void chartMain_SeriesVisibilityChanged(object sender, SeriesEventArgs e)
        {
            var series = e.Series as ChartSeries;
            var currency = _currencies.First(c => c.Symbol.Equals(series.Name));
            if (isChangeFromLegend)
            {
                if (!series.IsPercentage)
                {
                    if (_measureMode == MeasureMode.Both)
                    {
                        if (Utils.IsVisible(currency.ExchangeRateSeries))
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Plot;
                        else
                            currency.PercentageChangeSeries.Visibility = SeriesVisibility.Hidden;
                    }
                }
                UpdateVisibilityState(currency);
            }

            var rangeSeries = chartRangeSelector.Series.First(s => s.Name.Equals(series.Name) && ((ChartSeries)s).IsPercentage == series.IsPercentage);
            rangeSeries.Visibility = series.Visibility;
            chartRangeSelector.Invalidate();
            UpdateChartView();
        }

        private void chartMain_MouseMove(object sender, MouseEventArgs e)
        {
            var hitTestInfo = chartMain.HitTest(e.Location);
            if (hitTestInfo != null && hitTestInfo.Series != null)
            {
                var series = (ChartSeries)hitTestInfo.Series;
                if (series.IsPercentage)
                    chartMain.ToolTip.Content = AppResources.PercentChangeTooltip;
                else
                    chartMain.ToolTip.Content = AppResources.ExchangeRateTooltip;
            }
        }

        private void btnTimeFrameChanged(object sender, EventArgs e)
        {
            var btnSelectedTimeFrame = sender as RadioButton;
            _timeFrame = _dictTimeFrame[btnSelectedTimeFrame.Tag.ToString()];
            UpdateChart(_timeFrame);
            if (_rangeSelector != null)
            {
                _rangeSelector.ValueChanged -= rangeSelector_ValueChanged;
                _rangeSelector.UpperValue = _endPlotDate.ToOADate();
                _rangeSelector.LowerValue = chartMain.AxisX.Min;
                _rangeSelector.Invalidate();
                _rangeSelector.ValueChanged += rangeSelector_ValueChanged;
            }
            UpdateToFromDates();
            foreach (RadioButton control in pnlButtons.Controls)
                control.BackColor = control.Name.Equals(btnSelectedTimeFrame.Name) ? Color.Gray : Color.White;
        }

        #endregion

    }
}
