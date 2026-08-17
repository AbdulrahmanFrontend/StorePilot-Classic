namespace StorePilot.UI.Payments
{
    partial class frmAddEditPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditPayment));
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnSave = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnCancel = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpNotes = new System.Windows.Forms.TableLayoutPanel();
            this.lblNotes = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tlpUp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInvoiceID = new System.Windows.Forms.TableLayoutPanel();
            this.tbInvoiceID = new System.Windows.Forms.TextBox();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.tlpPaymentMethods = new System.Windows.Forms.TableLayoutPanel();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cbPaymentMethods = new System.Windows.Forms.ComboBox();
            this.tlpPaidAmount = new System.Windows.Forms.TableLayoutPanel();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.tbPaidAmount = new System.Windows.Forms.TextBox();
            this.tlpPaymentDate = new System.Windows.Forms.TableLayoutPanel();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epPaymentData = new System.Windows.Forms.ErrorProvider(this.components);
            this.flpFooter.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.tlpNotes.SuspendLayout();
            this.tlpUp.SuspendLayout();
            this.tlpInvoiceID.SuspendLayout();
            this.tlpPaymentMethods.SuspendLayout();
            this.tlpPaidAmount.SuspendLayout();
            this.tlpPaymentDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPaymentData)).BeginInit();
            this.SuspendLayout();
            // 
            // flpFooter
            // 
            this.flpFooter.AutoSize = true;
            this.flpFooter.Controls.Add(this.btnClose);
            this.flpFooter.Controls.Add(this.btnSave);
            this.flpFooter.Controls.Add(this.btnCancel);
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpFooter.Location = new System.Drawing.Point(0, 315);
            this.flpFooter.Name = "flpFooter";
            this.flpFooter.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flpFooter.Size = new System.Drawing.Size(498, 40);
            this.flpFooter.TabIndex = 12;
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
            this.btnClose.Size = new System.Drawing.Size(92, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "إغلاق";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnSave.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Success;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(101)))), ((int)(((byte)(47)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(74)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::StorePilot.UI.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(104, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSave.Size = new System.Drawing.Size(92, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(202, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(92, 28);
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
            this.tlpContainer.Controls.Add(this.tlpNotes, 0, 1);
            this.tlpContainer.Controls.Add(this.tlpUp, 0, 0);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 46);
            this.tlpContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 2;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Size = new System.Drawing.Size(498, 269);
            this.tlpContainer.TabIndex = 13;
            // 
            // tlpNotes
            // 
            this.tlpNotes.ColumnCount = 1;
            this.tlpNotes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.Controls.Add(this.lblNotes, 0, 0);
            this.tlpNotes.Controls.Add(this.tbNotes, 0, 1);
            this.tlpNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNotes.Location = new System.Drawing.Point(3, 138);
            this.tlpNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpNotes.Name = "tlpNotes";
            this.tlpNotes.RowCount = 2;
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpNotes.Size = new System.Drawing.Size(492, 127);
            this.tlpNotes.TabIndex = 1;
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
            this.lblNotes.Size = new System.Drawing.Size(486, 27);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "ملاحظات:";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNotes
            // 
            this.tbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNotes.Location = new System.Drawing.Point(20, 30);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbNotes.MaxLength = 500;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(469, 94);
            this.tbNotes.TabIndex = 4;
            // 
            // tlpUp
            // 
            this.tlpUp.ColumnCount = 2;
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Controls.Add(this.tlpInvoiceID, 1, 1);
            this.tlpUp.Controls.Add(this.tlpPaymentMethods, 1, 0);
            this.tlpUp.Controls.Add(this.tlpPaidAmount, 0, 1);
            this.tlpUp.Controls.Add(this.tlpPaymentDate, 0, 0);
            this.tlpUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUp.Location = new System.Drawing.Point(3, 4);
            this.tlpUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpUp.Name = "tlpUp";
            this.tlpUp.RowCount = 2;
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Size = new System.Drawing.Size(492, 126);
            this.tlpUp.TabIndex = 0;
            // 
            // tlpInvoiceID
            // 
            this.tlpInvoiceID.ColumnCount = 1;
            this.tlpInvoiceID.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInvoiceID.Controls.Add(this.tbInvoiceID, 0, 1);
            this.tlpInvoiceID.Controls.Add(this.lblInvoiceID, 0, 0);
            this.tlpInvoiceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInvoiceID.Location = new System.Drawing.Point(3, 67);
            this.tlpInvoiceID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpInvoiceID.Name = "tlpInvoiceID";
            this.tlpInvoiceID.RowCount = 2;
            this.tlpInvoiceID.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInvoiceID.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInvoiceID.Size = new System.Drawing.Size(240, 55);
            this.tlpInvoiceID.TabIndex = 6;
            // 
            // tbInvoiceID
            // 
            this.tbInvoiceID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInvoiceID.Location = new System.Drawing.Point(20, 27);
            this.tbInvoiceID.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbInvoiceID.Name = "tbInvoiceID";
            this.tbInvoiceID.ReadOnly = true;
            this.tbInvoiceID.Size = new System.Drawing.Size(217, 25);
            this.tbInvoiceID.TabIndex = 3;
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceID.Image = global::StorePilot.UI.Properties.Resources.Number_32;
            this.lblInvoiceID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInvoiceID.Location = new System.Drawing.Point(3, 0);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(234, 24);
            this.lblInvoiceID.TabIndex = 0;
            this.lblInvoiceID.Text = "رقم الفاتورة:";
            this.lblInvoiceID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpPaymentMethods
            // 
            this.tlpPaymentMethods.ColumnCount = 1;
            this.tlpPaymentMethods.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaymentMethods.Controls.Add(this.lblPaymentMethod, 0, 0);
            this.tlpPaymentMethods.Controls.Add(this.cbPaymentMethods, 0, 1);
            this.tlpPaymentMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPaymentMethods.Location = new System.Drawing.Point(3, 4);
            this.tlpPaymentMethods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpPaymentMethods.Name = "tlpPaymentMethods";
            this.tlpPaymentMethods.RowCount = 2;
            this.tlpPaymentMethods.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaymentMethods.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPaymentMethods.Size = new System.Drawing.Size(240, 55);
            this.tlpPaymentMethods.TabIndex = 5;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentMethod.Image = global::StorePilot.UI.Properties.Resources.payment;
            this.lblPaymentMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaymentMethod.Location = new System.Drawing.Point(3, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(234, 25);
            this.lblPaymentMethod.TabIndex = 0;
            this.lblPaymentMethod.Text = "طريقة الدفغ:";
            this.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPaymentMethods
            // 
            this.cbPaymentMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPaymentMethods.DropDownHeight = 100;
            this.cbPaymentMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethods.FormattingEnabled = true;
            this.cbPaymentMethods.IntegralHeight = false;
            this.cbPaymentMethods.Location = new System.Drawing.Point(20, 28);
            this.cbPaymentMethods.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cbPaymentMethods.Name = "cbPaymentMethods";
            this.cbPaymentMethods.Size = new System.Drawing.Size(217, 25);
            this.cbPaymentMethods.TabIndex = 1;
            // 
            // tlpPaidAmount
            // 
            this.tlpPaidAmount.ColumnCount = 1;
            this.tlpPaidAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaidAmount.Controls.Add(this.lblPaidAmount, 0, 0);
            this.tlpPaidAmount.Controls.Add(this.tbPaidAmount, 0, 1);
            this.tlpPaidAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPaidAmount.Location = new System.Drawing.Point(249, 67);
            this.tlpPaidAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpPaidAmount.Name = "tlpPaidAmount";
            this.tlpPaidAmount.RowCount = 2;
            this.tlpPaidAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaidAmount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPaidAmount.Size = new System.Drawing.Size(240, 55);
            this.tlpPaidAmount.TabIndex = 4;
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
            this.lblPaidAmount.Size = new System.Drawing.Size(234, 24);
            this.lblPaidAmount.TabIndex = 0;
            this.lblPaidAmount.Text = "المبلغ المدفوع:";
            this.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPaidAmount
            // 
            this.tbPaidAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPaidAmount.Location = new System.Drawing.Point(20, 27);
            this.tbPaidAmount.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbPaidAmount.MaxLength = 6;
            this.tbPaidAmount.Name = "tbPaidAmount";
            this.tbPaidAmount.Size = new System.Drawing.Size(217, 25);
            this.tbPaidAmount.TabIndex = 2;
            this.tbPaidAmount.Validating += new System.ComponentModel.CancelEventHandler(this.tbPaidAmount_Validating);
            // 
            // tlpPaymentDate
            // 
            this.tlpPaymentDate.ColumnCount = 1;
            this.tlpPaymentDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaymentDate.Controls.Add(this.lblPaymentDate, 0, 0);
            this.tlpPaymentDate.Controls.Add(this.dtpPaymentDate, 0, 1);
            this.tlpPaymentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPaymentDate.Location = new System.Drawing.Point(249, 4);
            this.tlpPaymentDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpPaymentDate.Name = "tlpPaymentDate";
            this.tlpPaymentDate.RowCount = 2;
            this.tlpPaymentDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaymentDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPaymentDate.Size = new System.Drawing.Size(240, 55);
            this.tlpPaymentDate.TabIndex = 2;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentDate.Image = global::StorePilot.UI.Properties.Resources.Calendar_32;
            this.lblPaymentDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaymentDate.Location = new System.Drawing.Point(3, 0);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(234, 24);
            this.lblPaymentDate.TabIndex = 0;
            this.lblPaymentDate.Text = "تاريخ الدفع:";
            this.lblPaymentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy   hh:mm tt";
            this.dtpPaymentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPaymentDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(20, 27);
            this.dtpPaymentDate.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.dtpPaymentDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtpPaymentDate.MinDate = new System.DateTime(1960, 1, 1, 0, 0, 0, 0);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.RightToLeftLayout = true;
            this.dtpPaymentDate.Size = new System.Drawing.Size(217, 25);
            this.dtpPaymentDate.TabIndex = 0;
            this.dtpPaymentDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpPaymentDate_Validating);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Image = global::StorePilot.UI.Properties.Resources.payment;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(498, 46);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epPaymentData
            // 
            this.epPaymentData.ContainerControl = this;
            this.epPaymentData.RightToLeft = true;
            // 
            // frmAddEditPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(498, 355);
            this.Controls.Add(this.tlpContainer);
            this.Controls.Add(this.flpFooter);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPayment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditUpdatePayment";
            this.Load += new System.EventHandler(this.frmAddEditPayment_Load);
            this.flpFooter.ResumeLayout(false);
            this.tlpContainer.ResumeLayout(false);
            this.tlpNotes.ResumeLayout(false);
            this.tlpNotes.PerformLayout();
            this.tlpUp.ResumeLayout(false);
            this.tlpInvoiceID.ResumeLayout(false);
            this.tlpInvoiceID.PerformLayout();
            this.tlpPaymentMethods.ResumeLayout(false);
            this.tlpPaidAmount.ResumeLayout(false);
            this.tlpPaidAmount.PerformLayout();
            this.tlpPaymentDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epPaymentData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpFooter;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnClose;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnSave;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.TableLayoutPanel tlpNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.TableLayoutPanel tlpUp;
        private System.Windows.Forms.TableLayoutPanel tlpInvoiceID;
        private System.Windows.Forms.TextBox tbInvoiceID;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.TableLayoutPanel tlpPaymentMethods;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cbPaymentMethods;
        private System.Windows.Forms.TableLayoutPanel tlpPaidAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.TextBox tbPaidAmount;
        private System.Windows.Forms.TableLayoutPanel tlpPaymentDate;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.ErrorProvider epPaymentData;
    }
}