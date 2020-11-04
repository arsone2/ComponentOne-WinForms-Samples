﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using C1.Chart;
using C1.Win.Chart;

namespace FlexChart101.Samples
{
    public partial class FunnelChart : UserControl
    {
        public FunnelChart()
        {
            InitializeComponent();
            InitializeControls();

            SetupChart();
        }

        void SetupChart()
        {
            flexChart1.BeginUpdate();

            flexChart1.Series.Clear();
            var data = new[]{
                new { Name = "US", Value = 10000 },
                new { Name = "Germany", Value = 9594 },
                new { Name = "UK", Value = 8692 },
                new { Name = "Japan", Value = 7488 },
                new { Name = "Italy", Value = 5662 },
                new { Name = "Greece", Value = 5329 }
            };

            // Add 3 data series
            var s1 = new Series();
            s1.Binding = s1.Name = "Value";
            flexChart1.Series.Add(s1);

            // Set x-binding and add data to the chart
            flexChart1.BindingX = "Name";
            flexChart1.DataSource = data;
            flexChart1.DataLabel.Content = "{}{y}";
            flexChart1.DataLabel.Position = LabelPosition.Center;

            flexChart1.EndUpdate();
        }
        private void nudNeckWidth_ValueChanged(object sender, EventArgs e)
        {
            flexChart1.Options.FunnelNeckWidth = (double)nudNeckWidth.Value;
        }

        private void nudNeckHeight_ValueChanged(object sender, EventArgs e)
        {
            flexChart1.Options.FunnelNeckHeight = (double)nudNeckHeight.Value;
        }

        private void cbFunnelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            flexChart1.Options.FunnelType = (C1.Chart.FunnelChartType)Enum.Parse(typeof(C1.Chart.FunnelChartType), (cbFunnelType.SelectedItem as ComboBoxItem).Text);
        }

        private void InitializeControls()
        {
            #region Init controls

            // Set localized text
            baseSample1.lblTitle.Text = Localizer.GetItem("funnel", "title");
            baseSample1.pDescription.Height = 80;
            baseSample1.tbDescription.Rtf = Localizer.GetItem("funnel", "description").MakeRtf();

            baseSample1.tbCode.Text = @"// Set FunnelNeckWidth properties
flexChart1.Options.FunnelNeckWidth = 0.2;
// Set FunnelNeckHeight property
flexChart1.Options.FunnelNeckHeight = 0.2;
// Set FunnelType property
flexChart1.Options.FunnelType = FunnelChartType.Default;
";

            flexChart1 = baseSample1.flexChart1;
            flexChart1.ChartType = ChartType.Funnel;
            

            // Initialize FunnelNeckWidth
            nudNeckWidth = new NumericUpDown()
            {
                Size = new Size(150, 21),
                ForeColor = Color.DimGray,
                Minimum = 0,
                Maximum = 1,
                DecimalPlaces = 1,
                Increment = 0.1m,
                Value = 0.2m
            };
            nudNeckWidth.ValueChanged += nudNeckWidth_ValueChanged;

            // Initialize FunnelNeckHeight
            nudNeckHeight = new NumericUpDown()
            {
                Size = new Size(150, 21),
                ForeColor = Color.DimGray,
                Minimum = 0,
                Maximum = 1,
                DecimalPlaces = 1,
                Increment = 0.1m,
                Value = 0.2m
            };
            nudNeckHeight.ValueChanged += nudNeckHeight_ValueChanged;

            // Initialize FunnelType combo box
            cbFunnelType = new ComboBox()
            {
                Size = new Size(150, 21),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.DimGray,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbFunnelType.SelectedIndexChanged += cbFunnelType_SelectedIndexChanged;

            baseSample1.pControls.Controls.Add(new Label() { Text = "Neck Width:", Width = 80, Height = 21, TextAlign = ContentAlignment.BottomLeft });
            baseSample1.pControls.Controls.Add(nudNeckWidth);
            baseSample1.pControls.Controls.Add(new Label() { Text = "Neck Height:", Width = 80, Height = 21, TextAlign = ContentAlignment.BottomLeft });
            baseSample1.pControls.Controls.Add(nudNeckHeight);
            baseSample1.pControls.Controls.Add(cbFunnelType);
            #endregion

            foreach (var item in Enum.GetValues(typeof(C1.Chart.FunnelChartType)))
                cbFunnelType.Items.Add(new ComboBoxItem("FunnelType") { Text = ((C1.Chart.FunnelChartType)item).ToString(), Value = (int)item });
            cbFunnelType.SelectedIndex = 0;
        }
    }
}
