﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Printing;

namespace CustomPaperSize
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void CorrectConnectionString(C1.C1Report.C1Report rep)
        {
            string cs = rep.DataSource.ConnectionString;

            //
            int i = cs.IndexOf("Data Source", 0, StringComparison.OrdinalIgnoreCase);
            if (i < 0)
                return;
            while (i < cs.Length && cs[i] != '=') i++;
            if (i >= cs.Length)
                return;
            int j = i;
            while (i < cs.Length && cs[i] != ';') i++;

            //
            string mdbName = cs.Substring(j + 1, i - j - 1).Trim();
            if (mdbName.Length <= 0)
                return;
            mdbName = System.IO.Path.GetFileName(mdbName);
            if (string.Compare(mdbName, "nwind.mdb", true) == 0)
                mdbName = "c1nwind.mdb";

            //
            cs = cs.Substring(0, j + 1) +
                Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                @"\ComponentOne Samples\Common\" +
                mdbName +
                cs.Substring(i);

            rep.DataSource.ConnectionString = cs;

            //
            foreach (C1.C1Report.Field field in rep.Fields)
                if (field.Subreport != null)
                    CorrectConnectionString(field.Subreport);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            C1.C1Report.C1Report c1r = new C1.C1Report.C1Report();

            // load report definition
            c1r.Load(@"..\..\report.xml", "Alphabetical List of Products Report");
            CorrectConnectionString(c1r);

            // define custom paper size, 20" x 60"
            PaperSize cps = new PaperSize("MyCustomSize", 2000, 6000);

            // assign custom paper size to report
            c1r.Document.DefaultPageSettings.PaperSize = cps;
            c1r.Render();

            //
            c1DocumentViewer1.Document = c1r.C1Document.FixedDocumentSequence;
        }
    }
}
