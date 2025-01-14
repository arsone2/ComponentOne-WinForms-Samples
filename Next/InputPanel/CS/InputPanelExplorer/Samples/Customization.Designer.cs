﻿namespace InputPanelExplorer.Samples
{
    partial class Customization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customization));
            this.c1InputPanel1 = new C1.Win.InputPanel.C1InputPanel();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hdrEmployees = new C1.Win.InputPanel.InputGroupHeader();
            this.navEmployees = new C1.Win.InputPanel.InputDataNavigator();
            this.hdrPersonal = new C1.Win.InputPanel.InputGroupHeader();
            this.lblName = new C1.Win.InputPanel.InputLabel();
            this.txtTitleOfCourtesy = new C1.Win.InputPanel.InputTextBox();
            this.txtFirstName = new C1.Win.InputPanel.InputTextBox();
            this.txtLastName = new C1.Win.InputPanel.InputTextBox();
            this.lblBirthDate = new C1.Win.InputPanel.InputLabel();
            this.dtpBirthDate = new C1.Win.InputPanel.InputDatePicker();
            this.lblNotes = new C1.Win.InputPanel.InputLabel();
            this.txtNotes = new C1.Win.InputPanel.InputTextBox();
            this.imgPhoto = new C1.Win.InputPanel.InputImage();
            this.hdrJobInfo = new C1.Win.InputPanel.InputGroupHeader();
            this.lblTitle = new C1.Win.InputPanel.InputLabel();
            this.txtTitle = new C1.Win.InputPanel.InputTextBox();
            this.lblReportsTo = new C1.Win.InputPanel.InputLabel();
            this.cbReportsTo = new C1.Win.InputPanel.InputComboBox();
            this.lblHireDate = new C1.Win.InputPanel.InputLabel();
            this.dtpHireDate = new C1.Win.InputPanel.InputDatePicker();
            this.hdrAddress = new C1.Win.InputPanel.InputGroupHeader();
            this.lblAddress = new C1.Win.InputPanel.InputLabel();
            this.txtAddress = new C1.Win.InputPanel.InputTextBox();
            this.lblCity = new C1.Win.InputPanel.InputLabel();
            this.txtCity = new C1.Win.InputPanel.InputTextBox();
            this.txtRegion = new C1.Win.InputPanel.InputTextBox();
            this.lblCountry = new C1.Win.InputPanel.InputLabel();
            this.txtCountry = new C1.Win.InputPanel.InputTextBox();
            this.lblPostalCode = new C1.Win.InputPanel.InputLabel();
            this.txtPostalCode = new C1.Win.InputPanel.InputTextBox();
            this.lblHomePhone = new C1.Win.InputPanel.InputLabel();
            this.txtPhone = new C1.Win.InputPanel.InputMaskedTextBox();
            this.lblExtension = new C1.Win.InputPanel.InputLabel();
            this.txtExtension = new C1.Win.InputPanel.InputTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1InputPanel1.DataSource = this.employeesBindingSource;
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1InputPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.c1InputPanel1.Items.Add(this.hdrEmployees);
            this.c1InputPanel1.Items.Add(this.navEmployees);
            this.c1InputPanel1.Items.Add(this.hdrPersonal);
            this.c1InputPanel1.Items.Add(this.lblName);
            this.c1InputPanel1.Items.Add(this.txtTitleOfCourtesy);
            this.c1InputPanel1.Items.Add(this.txtFirstName);
            this.c1InputPanel1.Items.Add(this.txtLastName);
            this.c1InputPanel1.Items.Add(this.lblBirthDate);
            this.c1InputPanel1.Items.Add(this.dtpBirthDate);
            this.c1InputPanel1.Items.Add(this.lblNotes);
            this.c1InputPanel1.Items.Add(this.txtNotes);
            this.c1InputPanel1.Items.Add(this.imgPhoto);
            this.c1InputPanel1.Items.Add(this.hdrJobInfo);
            this.c1InputPanel1.Items.Add(this.lblTitle);
            this.c1InputPanel1.Items.Add(this.txtTitle);
            this.c1InputPanel1.Items.Add(this.lblReportsTo);
            this.c1InputPanel1.Items.Add(this.cbReportsTo);
            this.c1InputPanel1.Items.Add(this.lblHireDate);
            this.c1InputPanel1.Items.Add(this.dtpHireDate);
            this.c1InputPanel1.Items.Add(this.hdrAddress);
            this.c1InputPanel1.Items.Add(this.lblAddress);
            this.c1InputPanel1.Items.Add(this.txtAddress);
            this.c1InputPanel1.Items.Add(this.lblCity);
            this.c1InputPanel1.Items.Add(this.txtCity);
            this.c1InputPanel1.Items.Add(this.txtRegion);
            this.c1InputPanel1.Items.Add(this.lblCountry);
            this.c1InputPanel1.Items.Add(this.txtCountry);
            this.c1InputPanel1.Items.Add(this.lblPostalCode);
            this.c1InputPanel1.Items.Add(this.txtPostalCode);
            this.c1InputPanel1.Items.Add(this.lblHomePhone);
            this.c1InputPanel1.Items.Add(this.txtPhone);
            this.c1InputPanel1.Items.Add(this.lblExtension);
            this.c1InputPanel1.Items.Add(this.txtExtension);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(660, 480);
            this.c1InputPanel1.TabIndex = 0;
            // 
            // hdrEmployees
            // 
            this.hdrEmployees.Name = "hdrEmployees";
            this.hdrEmployees.Text = "&Employees";
            // 
            // navEmployees
            // 
            this.navEmployees.AddNewImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.AddNewImage")));
            this.navEmployees.AddNewToolTip = "Add New";
            this.navEmployees.ImageScaling = C1.Win.InputPanel.InputImageScaling.Clip;
            this.navEmployees.ApplyImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.ApplyImage")));
            this.navEmployees.ApplyToolTip = "Apply Changes";
            this.navEmployees.CancelImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.CancelImage")));
            this.navEmployees.CancelToolTip = "Cancel Changes";
            this.navEmployees.DataSource = this.employeesBindingSource;
            this.navEmployees.DeleteImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.DeleteImage")));
            this.navEmployees.DeleteToolTip = "Delete";
            this.navEmployees.EditImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.EditImage")));            
            this.navEmployees.EditToolTip = "Edit";
            this.navEmployees.MoveFirstImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.MoveFirstImage")));
            this.navEmployees.MoveFirstToolTip = "Move First";
            this.navEmployees.MoveLastImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.MoveLastImage")));
            this.navEmployees.MoveLastToolTip = "Move Last";
            this.navEmployees.MoveNextImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.MoveNextImage")));
            this.navEmployees.MoveNextToolTip = "Move Next";
            this.navEmployees.MovePreviousImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.MovePreviousImage")));
            this.navEmployees.MovePreviousToolTip = "Move Previous";
            this.navEmployees.Name = "navEmployees";
            this.navEmployees.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.navEmployees.ReloadImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.ReloadImage")));
            this.navEmployees.ReloadToolTip = "Reload Data";
            this.navEmployees.SaveImage = ((System.Drawing.Image)(resources.GetObject("navEmployees.SaveImage")));
            this.navEmployees.SaveToolTip = "Save Data";
            this.navEmployees.ShowEditButton = true;
            // 
            // hdrPersonal
            // 
            this.hdrPersonal.Name = "hdrPersonal";
            this.hdrPersonal.Text = "Personal Info";
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Text = "&Name:";
            this.lblName.Width = 97;
            // 
            // txtTitleOfCourtesy
            // 
            this.txtTitleOfCourtesy.Break = C1.Win.InputPanel.BreakType.None;
            this.txtTitleOfCourtesy.Name = "txtTitleOfCourtesy";
            this.txtTitleOfCourtesy.Width = 50;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Break = C1.Win.InputPanel.BreakType.None;
            this.txtFirstName.Name = "txtFirstName";
            // 
            // txtLastName
            // 
            this.txtLastName.Name = "txtLastName";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Text = "&Birth Date:";
            this.lblBirthDate.Width = 97;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Name = "dtpBirthDate";
            // 
            // lblNotes
            // 
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Text = "&Notes:";
            this.lblNotes.Width = 97;
            // 
            // txtNotes
            // 
            this.txtNotes.Break = C1.Win.InputPanel.BreakType.Column;
            this.txtNotes.Height = 75;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.VerticalAlign = C1.Win.InputPanel.InputContentAlignment.Spread;
            this.txtNotes.Width = 260;
            // 
            // imgPhoto
            // 
            this.imgPhoto.Height = 120;
            this.imgPhoto.Name = "imgPhoto";
            this.imgPhoto.Width = 120;
            // 
            // hdrJobInfo
            // 
            this.hdrJobInfo.Collapsible = true;
            this.hdrJobInfo.Name = "hdrJobInfo";
            this.hdrJobInfo.Text = "Job Information";
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "&Title:";
            this.lblTitle.Width = 97;
            // 
            // txtTitle
            // 
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Width = 150;
            // 
            // lblReportsTo
            // 
            this.lblReportsTo.Name = "lblReportsTo";
            this.lblReportsTo.Text = "Report&s To:";
            this.lblReportsTo.Width = 97;
            // 
            // cbReportsTo
            // 
            this.cbReportsTo.AutoCompleteMode = C1.Win.InputPanel.InputAutoCompleteMode.Suggest;
            this.cbReportsTo.Break = C1.Win.InputPanel.BreakType.Column;
            this.cbReportsTo.DataSource = this.employeesBindingSource;
            this.cbReportsTo.DisplayMember = "LastName";
            this.cbReportsTo.FormattingEnabled = true;
            this.cbReportsTo.Name = "cbReportsTo";
            this.cbReportsTo.UpdateListPosition = false;
            this.cbReportsTo.ValueMember = "EmployeeID";
            this.cbReportsTo.Width = 150;
            this.cbReportsTo.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbReportsTo_Format);
            // 
            // lblHireDate
            // 
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Text = "&Hire Date:";
            this.lblHireDate.Width = 97;
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Name = "dtpHireDate";
            // 
            // hdrAddress
            // 
            this.hdrAddress.Collapsible = true;
            this.hdrAddress.Name = "hdrAddress";
            this.hdrAddress.Text = "Address";
            // 
            // lblAddress
            // 
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "&Street:";
            this.lblAddress.Width = 97;
            // 
            // txtAddress
            // 
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Width = 150;
            // 
            // lblCity
            // 
            this.lblCity.Name = "lblCity";
            this.lblCity.Text = "&City, Region:";
            this.lblCity.Width = 97;
            // 
            // txtCity
            // 
            this.txtCity.Break = C1.Win.InputPanel.BreakType.None;
            this.txtCity.Name = "txtCity";
            // 
            // txtRegion
            // 
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Width = 45;
            // 
            // lblCountry
            // 
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Text = "Co&untry:";
            this.lblCountry.Width = 97;
            // 
            // txtCountry
            // 
            this.txtCountry.Break = C1.Win.InputPanel.BreakType.Column;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Width = 150;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Text = "&Postal Code:";
            this.lblPostalCode.Width = 97;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Name = "txtPostalCode";
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Text = "Ho&me Phone:";
            this.lblHomePhone.Width = 97;
            // 
            // txtPhone
            // 
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Text = "(   )    -";
            // 
            // lblExtension
            // 
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Text = "E&xtension:";
            this.lblExtension.Width = 97;
            // 
            // txtExtension
            // 
            this.txtExtension.Name = "txtExtension";
            // 
            // DataBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c1InputPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DataBinding";
            this.Size = new System.Drawing.Size(660, 480);
            this.Load += new System.EventHandler(this.Customization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.InputPanel.InputGroupHeader hdrEmployees;
        private C1.Win.InputPanel.InputDataNavigator navEmployees;
        private C1.Win.InputPanel.InputGroupHeader hdrPersonal;
        private C1.Win.InputPanel.InputLabel lblName;
        private C1.Win.InputPanel.InputTextBox txtLastName;
        private C1.Win.InputPanel.InputTextBox txtFirstName;
        private C1.Win.InputPanel.InputTextBox txtTitle;
        private C1.Win.InputPanel.InputLabel lblTitle;
        private C1.Win.InputPanel.InputTextBox txtTitleOfCourtesy;
        private C1.Win.InputPanel.InputLabel lblBirthDate;
        private C1.Win.InputPanel.InputDatePicker dtpBirthDate;
        private C1.Win.InputPanel.InputLabel lblHireDate;
        private C1.Win.InputPanel.InputDatePicker dtpHireDate;
        private C1.Win.InputPanel.InputLabel lblAddress;
        private C1.Win.InputPanel.InputTextBox txtAddress;
        private C1.Win.InputPanel.InputLabel lblCity;
        private C1.Win.InputPanel.InputTextBox txtCity;
        private C1.Win.InputPanel.InputTextBox txtRegion;
        private C1.Win.InputPanel.InputLabel lblPostalCode;
        private C1.Win.InputPanel.InputTextBox txtPostalCode;
        private C1.Win.InputPanel.InputLabel lblCountry;
        private C1.Win.InputPanel.InputTextBox txtCountry;
        private C1.Win.InputPanel.InputLabel lblHomePhone;
        private C1.Win.InputPanel.InputLabel lblExtension;
        private C1.Win.InputPanel.InputTextBox txtExtension;
        private C1.Win.InputPanel.InputImage imgPhoto;
        private C1.Win.InputPanel.InputLabel lblNotes;
        private C1.Win.InputPanel.InputTextBox txtNotes;
        private C1.Win.InputPanel.InputLabel lblReportsTo;
        private C1.Win.InputPanel.InputGroupHeader hdrJobInfo;
        private C1.Win.InputPanel.InputGroupHeader hdrAddress;
        private C1.Win.InputPanel.InputMaskedTextBox txtPhone;
        private C1.Win.InputPanel.InputComboBox cbReportsTo;
    }
}