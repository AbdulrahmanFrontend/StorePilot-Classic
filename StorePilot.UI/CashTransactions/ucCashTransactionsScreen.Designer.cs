namespace StorePilot.UI.CashTransactions
{
    partial class ucCashTransactionsScreen
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
            this.ctrlCmsCashTransactions = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCmsCashTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCmsCashTransactions
            // 
            this.ctrlCmsCashTransactions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsCashTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsCashTransactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiUpdate,
            this.tss,
            this.tsmiCancel});
            this.ctrlCmsCashTransactions.Name = "ctrlCmsCashTransactions";
            this.ctrlCmsCashTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsCashTransactions.Size = new System.Drawing.Size(211, 122);
            this.ctrlCmsCashTransactions.Opening += new System.ComponentModel.CancelEventHandler(this.ctrlCmsCashTransactions_Opening);
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
            // tss
            // 
            this.tss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiCancel.Image = global::StorePilot.UI.Properties.Resources.activate_profile;
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.Size = new System.Drawing.Size(210, 28);
            this.tsmiCancel.Text = "إلغاء";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // ucCashTransactionsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucCashTransactionsScreen";
            this.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Load += new System.EventHandler(this.ucCashTransactionsScreen_Load);
            this.ctrlCmsCashTransactions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsCashTransactions;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.ToolStripSeparator tss;
    }
}
