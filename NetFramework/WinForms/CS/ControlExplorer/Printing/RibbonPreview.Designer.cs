﻿
namespace ControlExplorer.Printing
{
    partial class RibbonPreview
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
            this.c1RibbonPreview1 = new C1.Win.RibbonPreview.C1RibbonPreview();
            this.c1PrintDocument1 = new C1.C1Preview.C1PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.c1RibbonPreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintDocument1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1RibbonPreview1
            // 
            this.c1RibbonPreview1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.c1RibbonPreview1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.c1RibbonPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1RibbonPreview1.Document = this.c1PrintDocument1;
            this.c1RibbonPreview1.Location = new System.Drawing.Point(0, 0);
            this.c1RibbonPreview1.Name = "c1RibbonPreview1";
            this.c1RibbonPreview1.Size = new System.Drawing.Size(1078, 583);
            this.c1RibbonPreview1.TabIndex = 0;
            // 
            // RibbonPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 583);
            this.Controls.Add(this.c1RibbonPreview1);
            this.Name = "RibbonPreview";
            this.Text = "RibbonPreview";
            this.Load += new System.EventHandler(this.RibbonPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1RibbonPreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintDocument1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.RibbonPreview.C1RibbonPreview c1RibbonPreview1;
        private C1.C1Preview.C1PrintDocument c1PrintDocument1;
    }
}