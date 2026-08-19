namespace StorePilot.UI.Purchases
{
    partial class ucPurchasesScreen
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
            this.ctrlCmsPurchases = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCmsPurchases.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCmsPurchases
            // 
            this.ctrlCmsPurchases.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsPurchases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsPurchases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiPrint,
            this.tsmiAddPayments,
            this.tsmiViewPayments,
            this.tss,
            this.tsmiCancel});
            this.ctrlCmsPurchases.Name = "ctrlCmsPurchases";
            this.ctrlCmsPurchases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsPurchases.Size = new System.Drawing.Size(202, 150);
            this.ctrlCmsPurchases.Opening += new System.ComponentModel.CancelEventHandler(this.ctrlCmsPurchases_Opening);
            // 
            // tsmiView
            // 
            this.tsmiView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiView.Image = global::StorePilot.UI.Properties.Resources.view;
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(201, 28);
            this.tsmiView.Text = "عرض";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
            // 
            // tsmiPrint
            // 
            this.tsmiPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiPrint.Image = global::StorePilot.UI.Properties.Resources.print;
            this.tsmiPrint.Name = "tsmiPrint";
            this.tsmiPrint.Size = new System.Drawing.Size(201, 28);
            this.tsmiPrint.Text = "طباعة";
            this.tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // tsmiAddPayments
            // 
            this.tsmiAddPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiAddPayments.Image = global::StorePilot.UI.Properties.Resources.payment;
            this.tsmiAddPayments.Name = "tsmiAddPayments";
            this.tsmiAddPayments.Size = new System.Drawing.Size(201, 28);
            this.tsmiAddPayments.Text = "إضافة دفعة";
            this.tsmiAddPayments.Click += new System.EventHandler(this.tsmiAddPayments_Click);
            // 
            // tsmiViewPayments
            // 
            this.tsmiViewPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiViewPayments.Image = global::StorePilot.UI.Properties.Resources.payment;
            this.tsmiViewPayments.Name = "tsmiViewPayments";
            this.tsmiViewPayments.Size = new System.Drawing.Size(201, 28);
            this.tsmiViewPayments.Text = "عرض المدفوعات";
            this.tsmiViewPayments.Click += new System.EventHandler(this.tsmiViewPayments_Click);
            // 
            // tss
            // 
            this.tss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(198, 6);
            // 
            // tsmiCancel
            // 
            this.tsmiCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiCancel.Image = global::StorePilot.UI.Properties.Resources.cancel;
            this.tsmiCancel.Name = "tsmiCancel";
            this.tsmiCancel.Size = new System.Drawing.Size(201, 28);
            this.tsmiCancel.Text = "إلغاء";
            this.tsmiCancel.Click += new System.EventHandler(this.tsmiCancel_Click);
            // 
            // ucPurchasesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucPurchasesScreen";
            this.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Load += new System.EventHandler(this.ucPurchasesScreen_Load);
            this.ctrlCmsPurchases.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsPurchases;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddPayments;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPayments;
        private System.Windows.Forms.ToolStripSeparator tss;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
    }
}
