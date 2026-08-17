namespace StorePilot.UI.Sales
{
    partial class ucSalesScreen
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
            this.ctrlCmsSales = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddReturns = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewReturns = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlCmsSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCmsSales
            // 
            this.ctrlCmsSales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsSales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiPrint,
            this.tsmiAddPayments,
            this.tsmiViewPayments,
            this.tsmiAddReturns,
            this.tsmiViewReturns,
            this.tss,
            this.tsmiCancel});
            this.ctrlCmsSales.Name = "ctrlCmsSales";
            this.ctrlCmsSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsSales.Size = new System.Drawing.Size(202, 206);
            this.ctrlCmsSales.Opening += new System.ComponentModel.CancelEventHandler(this.ctrlCmsSales_Opening);
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
            // tsmiAddReturns
            // 
            this.tsmiAddReturns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiAddReturns.Image = global::StorePilot.UI.Properties.Resources.invoice;
            this.tsmiAddReturns.Name = "tsmiAddReturns";
            this.tsmiAddReturns.Size = new System.Drawing.Size(201, 28);
            this.tsmiAddReturns.Text = "إضافة مرتجع";
            this.tsmiAddReturns.Click += new System.EventHandler(this.tsmiAddReturns_Click);
            // 
            // tsmiViewReturns
            // 
            this.tsmiViewReturns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiViewReturns.Image = global::StorePilot.UI.Properties.Resources.invoice;
            this.tsmiViewReturns.Name = "tsmiViewReturns";
            this.tsmiViewReturns.Size = new System.Drawing.Size(201, 28);
            this.tsmiViewReturns.Text = "عرض المرتجعات";
            this.tsmiViewReturns.Click += new System.EventHandler(this.tsmiViewReturns_Click);
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
            // ucSalesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucSalesScreen";
            this.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Load += new System.EventHandler(this.ucSalesScreen_Load);
            this.ctrlCmsSales.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsSales;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddPayments;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPayments;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddReturns;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewReturns;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.ToolStripSeparator tss;
    }
}
