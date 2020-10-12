﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace RowDetails
{
    public partial class CustomSample : UserControl
    {
        public CustomSample()
        {
            InitializeComponent();
        }

        private void CustomSample_Load(object sender, EventArgs e)
        {
            string conn = Util.GetConnectionString();
            var ds = new DataSet();
            Util.FillTable(ds, "Employees", conn);

            flexGrid.DataSource = ds;
            flexGrid.DataMember = "Employees";

            flexGrid.RowDetailProvider = (g, r) => new CustomRowDetail();
            flexGrid.RowDetailsVisibilityMode = RowDetailsVisibilityMode.VisibleWhenSelected;

            flexGrid.Cols["Notes"].Visible = false;
        }
    }
}
