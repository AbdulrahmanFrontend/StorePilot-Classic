namespace StorePilot.UI.Suppliers
{
    partial class ucSuppliersScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlCmsSuppliers = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCmsSuppliers.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCmsSuppliers
            // 
            this.ctrlCmsSuppliers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsSuppliers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiUpdate,
            this.tss,
            this.tsmiActivate});
            this.ctrlCmsSuppliers.Name = "cmsSuppliers";
            this.ctrlCmsSuppliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsSuppliers.Size = new System.Drawing.Size(187, 94);
            this.ctrlCmsSuppliers.Opening += new System.ComponentModel.CancelEventHandler(this.ctrlCmsSuppliers_Opening);
            // 
            // tsmiView
            // 
            this.tsmiView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiView.Image = global::StorePilot.UI.Properties.Resources.view;
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(186, 28);
            this.tsmiView.Text = "عرض";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiUpdate.Image = global::StorePilot.UI.Properties.Resources.update;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(186, 28);
            this.tsmiUpdate.Text = "تحديث";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tss
            // 
            this.tss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiActivate
            // 
            this.tsmiActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiActivate.Image = global::StorePilot.UI.Properties.Resources.activate_profile;
            this.tsmiActivate.Name = "tsmiActivate";
            this.tsmiActivate.Size = new System.Drawing.Size(186, 28);
            this.tsmiActivate.Text = "تفعيل / تعطيل";
            this.tsmiActivate.Click += new System.EventHandler(this.tsmiActivate_Click);
            // 
            // ucSuppliersScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucSuppliersScreen";
            this.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Load += new System.EventHandler(this.ucSuppliersScreen_Load);
            this.ctrlCmsSuppliers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsSuppliers;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripSeparator tss;
        private System.Windows.Forms.ToolStripMenuItem tsmiActivate;
    }
}
