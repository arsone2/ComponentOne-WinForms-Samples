﻿namespace CellStyles
{
    partial class Form1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._flex = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnBold = new System.Windows.Forms.ToolStripButton();
            this._btnItalic = new System.Windows.Forms.ToolStripButton();
            this._btnUnderline = new System.Windows.Forms.ToolStripButton();
            this._btnLeft = new System.Windows.Forms.ToolStripButton();
            this._btnCenter = new System.Windows.Forms.ToolStripButton();
            this._btnRight = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flex)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnBold,
            this._btnItalic,
            this._btnUnderline,
            this.toolStripSeparator1,
            this._btnLeft,
            this._btnCenter,
            this._btnRight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // _flex
            // 
            this._flex.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this._flex.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this._flex.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flex.Location = new System.Drawing.Point(0, 25);
            this._flex.Name = "_flex";
            this._flex.Rows.DefaultSize = 21;
            this._flex.Size = new System.Drawing.Size(526, 359);
            this._flex.TabIndex = 1;
            this._flex.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this._flex_AfterRowColChange);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnBold
            // 
            this._btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnBold.Image = global::CellStyles.Properties.Resources.ToolStrip_Bold;
            this._btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnBold.Name = "_btnBold";
            this._btnBold.Size = new System.Drawing.Size(23, 22);
            this._btnBold.Text = "toolStripButton1";
            // 
            // _btnItalic
            // 
            this._btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnItalic.Image = global::CellStyles.Properties.Resources.ToolStrip_Italic;
            this._btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnItalic.Name = "_btnItalic";
            this._btnItalic.Size = new System.Drawing.Size(23, 22);
            this._btnItalic.Text = "toolStripButton2";
            // 
            // _btnUnderline
            // 
            this._btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnUnderline.Image = global::CellStyles.Properties.Resources.ToolStrip_Underline;
            this._btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnUnderline.Name = "_btnUnderline";
            this._btnUnderline.Size = new System.Drawing.Size(23, 22);
            this._btnUnderline.Text = "toolStripButton3";
            // 
            // _btnLeft
            // 
            this._btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnLeft.Image = global::CellStyles.Properties.Resources.ToolStrip_AlignTextLeft;
            this._btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnLeft.Name = "_btnLeft";
            this._btnLeft.Size = new System.Drawing.Size(23, 22);
            this._btnLeft.Text = "toolStripButton4";
            // 
            // _btnCenter
            // 
            this._btnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnCenter.Image = global::CellStyles.Properties.Resources.ToolStrip_AlignTextCenter;
            this._btnCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCenter.Name = "_btnCenter";
            this._btnCenter.Size = new System.Drawing.Size(23, 22);
            this._btnCenter.Text = "toolStripButton5";
            // 
            // _btnRight
            // 
            this._btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnRight.Image = global::CellStyles.Properties.Resources.ToolStrip_AlignTextRight;
            this._btnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnRight.Name = "_btnRight";
            this._btnRight.Size = new System.Drawing.Size(23, 22);
            this._btnRight.Text = "toolStripButton6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 384);
            this.Controls.Add(this._flex);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C1FlexGrid: Cell Styles";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private C1.Win.C1FlexGrid.C1FlexGrid _flex;
        private System.Windows.Forms.ToolStripButton _btnBold;
        private System.Windows.Forms.ToolStripButton _btnItalic;
        private System.Windows.Forms.ToolStripButton _btnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _btnLeft;
        private System.Windows.Forms.ToolStripButton _btnCenter;
        private System.Windows.Forms.ToolStripButton _btnRight;
    }
}

