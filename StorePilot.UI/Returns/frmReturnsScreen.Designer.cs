namespace StorePilot.UI.Returns
{
    partial class frmReturnsScreen
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
            this.ctrlCmsReturns = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCmsReturns.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCmsReturns
            // 
            this.ctrlCmsReturns.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsReturns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsReturns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiPrint,
            this.tss,
            this.tsmiCancel});
            this.ctrlCmsReturns.Name = "ctrlCmsReturns";
            this.ctrlCmsReturns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsReturns.Size = new System.Drawing.Size(211, 122);
            this.ctrlCmsReturns.Opening += new System.ComponentModel.CancelEventHandler(this.ctrlCmsReturns_Opening);
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
            // tsmiPrint
            // 
            this.tsmiPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiPrint.Image = global::StorePilot.UI.Properties.Resources.print;
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(210, 28);
            this.tsmiPrint.Text = "طباعة";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tss
            // 
            this.tss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiCancel.Image = global::StorePilot.UI.Properties.Resources.cancel;
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.Size = new System.Drawing.Size(210, 28);
            this.tsmiCancel.Text = "إلغاء";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // frmReturnsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 643);
            this.Name = "frmReturnsScreen";
            this.Load += new System.EventHandler(this.frmReturnsScreen_Load);
            this.ctrlCmsReturns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsReturns;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripSeparator tss;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
    }
}