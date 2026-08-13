namespace StorePilot.UI.Purchases
{
    partial class frmAddEditPurchaseInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditPurchaseInvoice));
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnSavePrint = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnInvoiceItems = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnViewPayments = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnCancel = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTotalAmount = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.tlpRemainingAmount = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.tbRemainingAmount = new System.Windows.Forms.TextBox();
            this.tlpPaidAmount = new System.Windows.Forms.TableLayoutPanel();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.tbPaidAmount = new System.Windows.Forms.TextBox();
            this.tlpStatuses = new System.Windows.Forms.TableLayoutPanel();
            this.cbStatuses = new System.Windows.Forms.ComboBox();
            this.lblInvoiceStatus = new System.Windows.Forms.Label();
            this.tlpCustomer = new System.Windows.Forms.TableLayoutPanel();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.btnAddNew = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpInvoiceDate = new System.Windows.Forms.TableLayoutPanel();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.tlpNotes = new System.Windows.Forms.TableLayoutPanel();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.flpFooter.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.tlpUp.SuspendLayout();
            this.tlpTotalAmount.SuspendLayout();
            this.tlpRemainingAmount.SuspendLayout();
            this.tlpPaidAmount.SuspendLayout();
            this.tlpStatuses.SuspendLayout();
            this.tlpCustomer.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.tlpInvoiceDate.SuspendLayout();
            this.tlpNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Image = global::StorePilot.UI.Properties.Resources.invoice;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(963, 46);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpFooter
            // 
            this.flpFooter.AutoSize = true;
            this.flpFooter.Controls.Add(this.btnClose);
            this.flpFooter.Controls.Add(this.btnSavePrint);
            this.flpFooter.Controls.Add(this.btnInvoiceItems);
            this.flpFooter.Controls.Add(this.btnViewPayments);
            this.flpFooter.Controls.Add(this.btnCancel);
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpFooter.Location = new System.Drawing.Point(0, 457);
            this.flpFooter.Name = "flpFooter";
            this.flpFooter.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flpFooter.Size = new System.Drawing.Size(963, 40);
            this.flpFooter.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnClose.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Primary;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::StorePilot.UI.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnClose.Size = new System.Drawing.Size(99, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "إغلاق";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnSavePrint.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Success;
            this.btnSavePrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePrint.FlatAppearance.BorderSize = 0;
            this.btnSavePrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(101)))), ((int)(((byte)(47)))));
            this.btnSavePrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(74)))));
            this.btnSavePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePrint.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePrint.Location = new System.Drawing.Point(111, 6);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSavePrint.Size = new System.Drawing.Size(97, 28);
            this.btnSavePrint.TabIndex = 8;
            this.btnSavePrint.Text = "حفظ";
            this.btnSavePrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePrint.UseVisualStyleBackColor = false;
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // btnInvoiceItems
            // 
            this.btnInvoiceItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnInvoiceItems.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Secondary;
            this.btnInvoiceItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvoiceItems.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnInvoiceItems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnInvoiceItems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInvoiceItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoiceItems.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoiceItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnInvoiceItems.Image = global::StorePilot.UI.Properties.Resources.list;
            this.btnInvoiceItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoiceItems.Location = new System.Drawing.Point(214, 6);
            this.btnInvoiceItems.Name = "btnInvoiceItems";
            this.btnInvoiceItems.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnInvoiceItems.Size = new System.Drawing.Size(190, 28);
            this.btnInvoiceItems.TabIndex = 7;
            this.btnInvoiceItems.Text = "إضافة عناصر الفاتورة";
            this.btnInvoiceItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInvoiceItems.UseVisualStyleBackColor = false;
            this.btnInvoiceItems.Click += new System.EventHandler(this.btnInvoiceItems_Click);
            // 
            // btnViewPayments
            // 
            this.btnViewPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnViewPayments.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Secondary;
            this.btnViewPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewPayments.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnViewPayments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))));
            this.btnViewPayments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPayments.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnViewPayments.Image = global::StorePilot.UI.Properties.Resources.payment;
            this.btnViewPayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPayments.Location = new System.Drawing.Point(410, 6);
            this.btnViewPayments.Name = "btnViewPayments";
            this.btnViewPayments.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnViewPayments.Size = new System.Drawing.Size(156, 28);
            this.btnViewPayments.TabIndex = 6;
            this.btnViewPayments.Text = "عرض سجل الدفع";
            this.btnViewPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewPayments.UseVisualStyleBackColor = false;
            this.btnViewPayments.Click += new System.EventHandler(this.btnViewPayments_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnCancel.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Danger;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::StorePilot.UI.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(572, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(88, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Controls.Add(this.tlpUp, 0, 0);
            this.tlpContainer.Controls.Add(this.tlpNotes, 0, 1);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 46);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 2;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Size = new System.Drawing.Size(963, 411);
            this.tlpContainer.TabIndex = 12;
            // 
            // tlpUp
            // 
            this.tlpUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpUp.ColumnCount = 2;
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Controls.Add(this.tlpTotalAmount, 1, 2);
            this.tlpUp.Controls.Add(this.tlpRemainingAmount, 0, 2);
            this.tlpUp.Controls.Add(this.tlpPaidAmount, 1, 1);
            this.tlpUp.Controls.Add(this.tlpStatuses, 0, 1);
            this.tlpUp.Controls.Add(this.tlpCustomer, 1, 0);
            this.tlpUp.Controls.Add(this.tlpInvoiceDate, 0, 0);
            this.tlpUp.Location = new System.Drawing.Point(3, 3);
            this.tlpUp.Name = "tlpUp";
            this.tlpUp.RowCount = 3;
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlpUp.Size = new System.Drawing.Size(957, 199);
            this.tlpUp.TabIndex = 0;
            // 
            // tlpTotalAmount
            // 
            this.tlpTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTotalAmount.ColumnCount = 1;
            this.tlpTotalAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTotalAmount.Controls.Add(this.lblTotalAmount, 0, 0);
            this.tlpTotalAmount.Controls.Add(this.tbTotalAmount, 0, 1);
            this.tlpTotalAmount.Location = new System.Drawing.Point(3, 139);
            this.tlpTotalAmount.Name = "tlpTotalAmount";
            this.tlpTotalAmount.RowCount = 2;
            this.tlpTotalAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTotalAmount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTotalAmount.Size = new System.Drawing.Size(473, 57);
            this.tlpTotalAmount.TabIndex = 5;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblTotalAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalAmount.Location = new System.Drawing.Point(3, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(467, 21);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "إجمالي الفاتورة:";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalAmount.Location = new System.Drawing.Point(3, 24);
            this.tbTotalAmount.MaxLength = 6;
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.ReadOnly = true;
            this.tbTotalAmount.Size = new System.Drawing.Size(467, 30);
            this.tbTotalAmount.TabIndex = 1;
            // 
            // tlpRemainingAmount
            // 
            this.tlpRemainingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpRemainingAmount.ColumnCount = 1;
            this.tlpRemainingAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRemainingAmount.Controls.Add(this.lblRemainingAmount, 0, 0);
            this.tlpRemainingAmount.Controls.Add(this.tbRemainingAmount, 0, 1);
            this.tlpRemainingAmount.Location = new System.Drawing.Point(482, 139);
            this.tlpRemainingAmount.Name = "tlpRemainingAmount";
            this.tlpRemainingAmount.RowCount = 2;
            this.tlpRemainingAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRemainingAmount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRemainingAmount.Size = new System.Drawing.Size(472, 57);
            this.tlpRemainingAmount.TabIndex = 4;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainingAmount.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblRemainingAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemainingAmount.Location = new System.Drawing.Point(3, 0);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.Size = new System.Drawing.Size(466, 21);
            this.lblRemainingAmount.TabIndex = 0;
            this.lblRemainingAmount.Text = "المبلغ المتبقي:";
            this.lblRemainingAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbRemainingAmount
            // 
            this.tbRemainingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemainingAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemainingAmount.Location = new System.Drawing.Point(3, 24);
            this.tbRemainingAmount.MaxLength = 6;
            this.tbRemainingAmount.Name = "tbRemainingAmount";
            this.tbRemainingAmount.ReadOnly = true;
            this.tbRemainingAmount.Size = new System.Drawing.Size(466, 30);
            this.tbRemainingAmount.TabIndex = 1;
            // 
            // tlpPaidAmount
            // 
            this.tlpPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPaidAmount.ColumnCount = 1;
            this.tlpPaidAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaidAmount.Controls.Add(this.lblPaidAmount, 0, 0);
            this.tlpPaidAmount.Controls.Add(this.tbPaidAmount, 0, 1);
            this.tlpPaidAmount.Location = new System.Drawing.Point(3, 71);
            this.tlpPaidAmount.Name = "tlpPaidAmount";
            this.tlpPaidAmount.RowCount = 2;
            this.tlpPaidAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaidAmount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPaidAmount.Size = new System.Drawing.Size(473, 62);
            this.tlpPaidAmount.TabIndex = 3;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaidAmount.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblPaidAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaidAmount.Location = new System.Drawing.Point(3, 0);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(467, 26);
            this.lblPaidAmount.TabIndex = 0;
            this.lblPaidAmount.Text = "المبلغ المدفوع:";
            this.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPaidAmount
            // 
            this.tbPaidAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPaidAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPaidAmount.Location = new System.Drawing.Point(3, 29);
            this.tbPaidAmount.MaxLength = 6;
            this.tbPaidAmount.Name = "tbPaidAmount";
            this.tbPaidAmount.ReadOnly = true;
            this.tbPaidAmount.Size = new System.Drawing.Size(467, 30);
            this.tbPaidAmount.TabIndex = 1;
            // 
            // tlpStatuses
            // 
            this.tlpStatuses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpStatuses.ColumnCount = 1;
            this.tlpStatuses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatuses.Controls.Add(this.cbStatuses, 0, 1);
            this.tlpStatuses.Controls.Add(this.lblInvoiceStatus, 0, 0);
            this.tlpStatuses.Location = new System.Drawing.Point(482, 71);
            this.tlpStatuses.Name = "tlpStatuses";
            this.tlpStatuses.RowCount = 2;
            this.tlpStatuses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatuses.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStatuses.Size = new System.Drawing.Size(472, 62);
            this.tlpStatuses.TabIndex = 2;
            // 
            // cbStatuses
            // 
            this.cbStatuses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatuses.DropDownHeight = 100;
            this.cbStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatuses.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatuses.FormattingEnabled = true;
            this.cbStatuses.IntegralHeight = false;
            this.cbStatuses.Items.AddRange(new object[] {
            "مدفوع",
            "آجل"});
            this.cbStatuses.Location = new System.Drawing.Point(3, 28);
            this.cbStatuses.Name = "cbStatuses";
            this.cbStatuses.Size = new System.Drawing.Size(466, 31);
            this.cbStatuses.TabIndex = 3;
            this.cbStatuses.SelectedIndexChanged += new System.EventHandler(this.cbStatuses_SelectedIndexChanged);
            // 
            // lblInvoiceStatus
            // 
            this.lblInvoiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceStatus.Image = global::StorePilot.UI.Properties.Resources.status;
            this.lblInvoiceStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInvoiceStatus.Location = new System.Drawing.Point(3, 0);
            this.lblInvoiceStatus.Name = "lblInvoiceStatus";
            this.lblInvoiceStatus.Size = new System.Drawing.Size(466, 25);
            this.lblInvoiceStatus.TabIndex = 0;
            this.lblInvoiceStatus.Text = "حالة الفاتورة:";
            this.lblInvoiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCustomer
            // 
            this.tlpCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCustomer.ColumnCount = 1;
            this.tlpCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCustomer.Controls.Add(this.lblSupplier, 0, 0);
            this.tlpCustomer.Controls.Add(this.pnlCustomer, 0, 1);
            this.tlpCustomer.Location = new System.Drawing.Point(3, 3);
            this.tlpCustomer.Name = "tlpCustomer";
            this.tlpCustomer.RowCount = 2;
            this.tlpCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.53846F));
            this.tlpCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.46154F));
            this.tlpCustomer.Size = new System.Drawing.Size(473, 62);
            this.tlpCustomer.TabIndex = 1;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplier.Image = global::StorePilot.UI.Properties.Resources.supplier;
            this.lblSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSupplier.Location = new System.Drawing.Point(3, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(467, 25);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "المورد:";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCustomer.Controls.Add(this.cbSuppliers);
            this.pnlCustomer.Controls.Add(this.btnAddNew);
            this.pnlCustomer.Location = new System.Drawing.Point(3, 28);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(467, 31);
            this.pnlCustomer.TabIndex = 1;
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSuppliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSuppliers.DropDownHeight = 100;
            this.cbSuppliers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.IntegralHeight = false;
            this.cbSuppliers.Location = new System.Drawing.Point(128, 0);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(339, 31);
            this.cbSuppliers.TabIndex = 1;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAddNew.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Primary;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Image = global::StorePilot.UI.Properties.Resources.supplier;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(0, 0);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnAddNew.Size = new System.Drawing.Size(128, 31);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "عميل جديد";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tlpInvoiceDate
            // 
            this.tlpInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpInvoiceDate.ColumnCount = 1;
            this.tlpInvoiceDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInvoiceDate.Controls.Add(this.lblInvoiceDate, 0, 0);
            this.tlpInvoiceDate.Controls.Add(this.dtpInvoiceDate, 0, 1);
            this.tlpInvoiceDate.Location = new System.Drawing.Point(482, 3);
            this.tlpInvoiceDate.Name = "tlpInvoiceDate";
            this.tlpInvoiceDate.RowCount = 2;
            this.tlpInvoiceDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInvoiceDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInvoiceDate.Size = new System.Drawing.Size(472, 62);
            this.tlpInvoiceDate.TabIndex = 0;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceDate.Image = global::StorePilot.UI.Properties.Resources.Calendar_32;
            this.lblInvoiceDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInvoiceDate.Location = new System.Drawing.Point(3, 0);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(466, 26);
            this.lblInvoiceDate.TabIndex = 0;
            this.lblInvoiceDate.Text = "تاريخ الشراء:";
            this.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.AllowDrop = true;
            this.dtpInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(3, 29);
            this.dtpInvoiceDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtpInvoiceDate.MinDate = new System.DateTime(1981, 1, 1, 0, 0, 0, 0);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(466, 30);
            this.dtpInvoiceDate.TabIndex = 0;
            this.dtpInvoiceDate.Value = new System.DateTime(2026, 8, 12, 16, 29, 11, 0);
            // 
            // tlpNotes
            // 
            this.tlpNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpNotes.ColumnCount = 1;
            this.tlpNotes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.Controls.Add(this.tbNotes, 0, 1);
            this.tlpNotes.Controls.Add(this.lblNotes, 0, 0);
            this.tlpNotes.Location = new System.Drawing.Point(3, 208);
            this.tlpNotes.Name = "tlpNotes";
            this.tlpNotes.RowCount = 2;
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpNotes.Size = new System.Drawing.Size(957, 200);
            this.tlpNotes.TabIndex = 1;
            // 
            // tbNotes
            // 
            this.tbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(3, 27);
            this.tbNotes.MaxLength = 500;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(951, 170);
            this.tbNotes.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotes.Image = global::StorePilot.UI.Properties.Resources.Notes_32;
            this.lblNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Location = new System.Drawing.Point(3, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(951, 24);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "ملاحظات:";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddEditPurchaseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(963, 497);
            this.Controls.Add(this.tlpContainer);
            this.Controls.Add(this.flpFooter);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddEditPurchaseInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditPurchaseInvoice";
            this.Load += new System.EventHandler(this.frmAddEditPurchaseInvoice_Load);
            this.flpFooter.ResumeLayout(false);
            this.tlpContainer.ResumeLayout(false);
            this.tlpUp.ResumeLayout(false);
            this.tlpTotalAmount.ResumeLayout(false);
            this.tlpTotalAmount.PerformLayout();
            this.tlpRemainingAmount.ResumeLayout(false);
            this.tlpRemainingAmount.PerformLayout();
            this.tlpPaidAmount.ResumeLayout(false);
            this.tlpPaidAmount.PerformLayout();
            this.tlpStatuses.ResumeLayout(false);
            this.tlpCustomer.ResumeLayout(false);
            this.pnlCustomer.ResumeLayout(false);
            this.tlpInvoiceDate.ResumeLayout(false);
            this.tlpNotes.ResumeLayout(false);
            this.tlpNotes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpFooter;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnClose;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnSavePrint;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnInvoiceItems;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnViewPayments;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.TableLayoutPanel tlpUp;
        private System.Windows.Forms.TableLayoutPanel tlpTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox tbTotalAmount;
        private System.Windows.Forms.TableLayoutPanel tlpRemainingAmount;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.TextBox tbRemainingAmount;
        private System.Windows.Forms.TableLayoutPanel tlpPaidAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.TextBox tbPaidAmount;
        private System.Windows.Forms.TableLayoutPanel tlpStatuses;
        private System.Windows.Forms.ComboBox cbStatuses;
        private System.Windows.Forms.Label lblInvoiceStatus;
        private System.Windows.Forms.TableLayoutPanel tlpCustomer;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnAddNew;
        private System.Windows.Forms.TableLayoutPanel tlpInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.TableLayoutPanel tlpNotes;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lblNotes;
    }
}