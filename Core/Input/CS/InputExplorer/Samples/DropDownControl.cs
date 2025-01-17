﻿using C1.Win.Input;
using C1.Win.TreeView;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InputExplorer.Samples
{
    public partial class DropDownControl : UserControl
    {
        public DropDownControl()
        {
            InitializeComponent();
            foreach (Control control in Controls)
            {
                if (control is C1DropDownControl)
                {
                    control.GotFocus += Control_GotFocus;
                }
            }
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = sender;
        }

        private void treeList_SelectionChanged(object sender, C1TreeViewEventArgs e)
        {
            // set value from first column
            dropDownTreeList.Text = treeList.SelectedNodes.FirstOrDefault()?.GetValue(0)?.ToString();
            // close drop down
            dropDownTreeList.DroppedDown = false;
        }

        private void DropDownControl_Load(object sender, System.EventArgs e)
        {
            treeList.BindingInfo.DataSource = Employee.GetData();
            multiColumnTreeView.BindingInfo.DataSource = Employee.GetData();
        }

        private void c1TreeView2_SelectionChanged(object sender, C1TreeViewEventArgs e)
        {
            // set value from first column
            var firstSelectedNode = multiColumnTreeView.SelectedNodes.FirstOrDefault();
            if (firstSelectedNode is not null)
                dropDownMultiColumnTreeView.Text = $"{firstSelectedNode.GetValue(0)} - {firstSelectedNode.GetValue(1)}";
            else
                dropDownMultiColumnTreeView.Text = string.Empty;
            // close drop down
            dropDownMultiColumnTreeView.DroppedDown = false;
        }
    }
}
