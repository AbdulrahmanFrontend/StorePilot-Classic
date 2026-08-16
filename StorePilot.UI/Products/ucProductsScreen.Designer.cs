namespace StorePilot.UI.Products
{
    partial class ucProductsScreen
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
            this.ctrlCmsProducts = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.ctrlCmsProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCmsProducts
            // 
            this.ctrlCmsProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiUpdate,
            this.tss,
            this.tsmiActivate});
            this.ctrlCmsProducts.Name = "ctrlCmsProducts";
            this.ctrlCmsProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsProducts.Size = new System.Drawing.Size(211, 122);
            this.ctrlCmsProducts.Opening += new System.ComponentModel.CancelEventHandler(this.ctrlCmsProducts_Opening);
            // 
            // tsmiView
            // 
            this.tsmiView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiView.Image = global::StorePilot.UI.Properties.Resources.view;
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(210, 28);
            this.tsmiView.Text = "عرض";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiUpdate.Image = global::StorePilot.UI.Properties.Resources.update;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(210, 28);
            this.tsmiUpdate.Text = "تحديث";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiActivate
            // 
            this.tsmiActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiActivate.Image = global::StorePilot.UI.Properties.Resources.activate_profile;
            this.tsmiActivate.Name = "tsmiActivate";
            this.tsmiActivate.Size = new System.Drawing.Size(210, 28);
            this.tsmiActivate.Text = "تفعيل / تعطيل";
            this.tsmiActivate.Click += new System.EventHandler(this.tsmiActivate_Click);
            // 
            // tss
            // 
            this.tss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(207, 6);
            // 
            // ucProductsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucProductsScreen";
            this.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Load += new System.EventHandler(this.ucProductsScreen_Load);
            this.ctrlCmsProducts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripSeparator tss;
        private System.Windows.Forms.ToolStripMenuItem tsmiActivate;
    }
}
