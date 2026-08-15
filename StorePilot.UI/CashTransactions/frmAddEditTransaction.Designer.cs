namespace StorePilot.UI.CashTransactions
{
    partial class frmAddEditTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditTransaction));
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnSave = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnCancel = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpNotes = new System.Windows.Forms.TableLayoutPanel();
            this.lblNotes = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tlpUp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDescription = new System.Windows.Forms.TableLayoutPanel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tlpTransactionType = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cbTransactionType = new System.Windows.Forms.ComboBox();
            this.tlpPaidAmount = new System.Windows.Forms.TableLayoutPanel();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.tbPaidAmount = new System.Windows.Forms.TextBox();
            this.tlpTransactionDate = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.epTransactionData = new System.Windows.Forms.ErrorProvider(this.components);
            this.flpFooter.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.tlpNotes.SuspendLayout();
            this.tlpUp.SuspendLayout();
            this.tlpDescription.SuspendLayout();
            this.tlpTransactionType.SuspendLayout();
            this.tlpPaidAmount.SuspendLayout();
            this.tlpTransactionDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epTransactionData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Image = global::StorePilot.UI.Properties.Resources.payment;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 46);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.flpFooter.Size = new System.Drawing.Size(800, 40);
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
            this.tlpContainer.Size = new System.Drawing.Size(800, 269);
            this.tlpContainer.TabIndex = 12;
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
            this.tlpNotes.Size = new System.Drawing.Size(794, 127);
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
            this.lblNotes.Size = new System.Drawing.Size(788, 27);
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
            this.tbNotes.Size = new System.Drawing.Size(771, 94);
            this.tbNotes.TabIndex = 4;
            // 
            // tlpUp
            // 
            this.tlpUp.ColumnCount = 2;
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Controls.Add(this.tlpDescription, 1, 1);
            this.tlpUp.Controls.Add(this.tlpTransactionType, 1, 0);
            this.tlpUp.Controls.Add(this.tlpPaidAmount, 0, 1);
            this.tlpUp.Controls.Add(this.tlpTransactionDate, 0, 0);
            this.tlpUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUp.Location = new System.Drawing.Point(3, 4);
            this.tlpUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpUp.Name = "tlpUp";
            this.tlpUp.RowCount = 2;
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Size = new System.Drawing.Size(794, 126);
            this.tlpUp.TabIndex = 0;
            // 
            // tlpDescription
            // 
            this.tlpDescription.ColumnCount = 1;
            this.tlpDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDescription.Controls.Add(this.tbDescription, 0, 1);
            this.tlpDescription.Controls.Add(this.lblDescription, 0, 0);
            this.tlpDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDescription.Location = new System.Drawing.Point(3, 67);
            this.tlpDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpDescription.Name = "tlpDescription";
            this.tlpDescription.RowCount = 2;
            this.tlpDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDescription.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDescription.Size = new System.Drawing.Size(391, 55);
            this.tlpDescription.TabIndex = 6;
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(20, 27);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbDescription.MaxLength = 100;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(368, 25);
            this.tbDescription.TabIndex = 3;
            this.tbDescription.Validating += new System.ComponentModel.CancelEventHandler(this.tbDescription_Validating);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Image = global::StorePilot.UI.Properties.Resources.Notes_32;
            this.lblDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescription.Location = new System.Drawing.Point(3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(385, 24);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "توصيف الحركة:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpTransactionType
            // 
            this.tlpTransactionType.ColumnCount = 1;
            this.tlpTransactionType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTransactionType.Controls.Add(this.lblTransactionType, 0, 0);
            this.tlpTransactionType.Controls.Add(this.cbTransactionType, 0, 1);
            this.tlpTransactionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTransactionType.Location = new System.Drawing.Point(3, 4);
            this.tlpTransactionType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpTransactionType.Name = "tlpTransactionType";
            this.tlpTransactionType.RowCount = 2;
            this.tlpTransactionType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTransactionType.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTransactionType.Size = new System.Drawing.Size(391, 55);
            this.tlpTransactionType.TabIndex = 5;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransactionType.Image = global::StorePilot.UI.Properties.Resources.status;
            this.lblTransactionType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTransactionType.Location = new System.Drawing.Point(3, 0);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(385, 24);
            this.lblTransactionType.TabIndex = 0;
            this.lblTransactionType.Text = "نوع الحركة:";
            this.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTransactionType
            // 
            this.cbTransactionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTransactionType.DropDownHeight = 100;
            this.cbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransactionType.FormattingEnabled = true;
            this.cbTransactionType.IntegralHeight = false;
            this.cbTransactionType.Items.AddRange(new object[] {
            "ايرادات",
            "مصروفات"});
            this.cbTransactionType.Location = new System.Drawing.Point(20, 27);
            this.cbTransactionType.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cbTransactionType.Name = "cbTransactionType";
            this.cbTransactionType.Size = new System.Drawing.Size(368, 25);
            this.cbTransactionType.TabIndex = 1;
            // 
            // tlpPaidAmount
            // 
            this.tlpPaidAmount.ColumnCount = 1;
            this.tlpPaidAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaidAmount.Controls.Add(this.lblPaidAmount, 0, 0);
            this.tlpPaidAmount.Controls.Add(this.tbPaidAmount, 0, 1);
            this.tlpPaidAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPaidAmount.Location = new System.Drawing.Point(400, 67);
            this.tlpPaidAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpPaidAmount.Name = "tlpPaidAmount";
            this.tlpPaidAmount.RowCount = 2;
            this.tlpPaidAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaidAmount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPaidAmount.Size = new System.Drawing.Size(391, 55);
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
            this.lblPaidAmount.Size = new System.Drawing.Size(385, 24);
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
            this.tbPaidAmount.Size = new System.Drawing.Size(368, 25);
            this.tbPaidAmount.TabIndex = 2;
            this.tbPaidAmount.Validating += new System.ComponentModel.CancelEventHandler(this.tbPaidAmount_Validating);
            // 
            // tlpTransactionDate
            // 
            this.tlpTransactionDate.ColumnCount = 1;
            this.tlpTransactionDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTransactionDate.Controls.Add(this.lblTransactionDate, 0, 0);
            this.tlpTransactionDate.Controls.Add(this.dtpTransactionDate, 0, 1);
            this.tlpTransactionDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTransactionDate.Location = new System.Drawing.Point(400, 4);
            this.tlpTransactionDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlpTransactionDate.Name = "tlpTransactionDate";
            this.tlpTransactionDate.RowCount = 2;
            this.tlpTransactionDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTransactionDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTransactionDate.Size = new System.Drawing.Size(391, 55);
            this.tlpTransactionDate.TabIndex = 2;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransactionDate.Image = global::StorePilot.UI.Properties.Resources.Calendar_32;
            this.lblTransactionDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTransactionDate.Location = new System.Drawing.Point(3, 0);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(385, 24);
            this.lblTransactionDate.TabIndex = 0;
            this.lblTransactionDate.Text = "تاريخ الحركة:";
            this.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpTransactionDate.CustomFormat = "dd/MM/yyyy   hh:mm tt";
            this.dtpTransactionDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTransactionDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDate.Location = new System.Drawing.Point(20, 27);
            this.dtpTransactionDate.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.dtpTransactionDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtpTransactionDate.MinDate = new System.DateTime(1960, 1, 1, 0, 0, 0, 0);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.RightToLeftLayout = true;
            this.dtpTransactionDate.Size = new System.Drawing.Size(368, 25);
            this.dtpTransactionDate.TabIndex = 0;
            // 
            // epTransactionData
            // 
            this.epTransactionData.ContainerControl = this;
            this.epTransactionData.RightToLeft = true;
            // 
            // frmAddEditUpdateTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 355);
            this.Controls.Add(this.tlpContainer);
            this.Controls.Add(this.flpFooter);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditUpdateTransaction";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditUpdateTransaction";
            this.Load += new System.EventHandler(this.frmAddEditTransaction_Load);
            this.flpFooter.ResumeLayout(false);
            this.tlpContainer.ResumeLayout(false);
            this.tlpNotes.ResumeLayout(false);
            this.tlpNotes.PerformLayout();
            this.tlpUp.ResumeLayout(false);
            this.tlpDescription.ResumeLayout(false);
            this.tlpDescription.PerformLayout();
            this.tlpTransactionType.ResumeLayout(false);
            this.tlpPaidAmount.ResumeLayout(false);
            this.tlpPaidAmount.PerformLayout();
            this.tlpTransactionDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epTransactionData)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tlpDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TableLayoutPanel tlpTransactionType;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.TableLayoutPanel tlpPaidAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.TextBox tbPaidAmount;
        private System.Windows.Forms.TableLayoutPanel tlpTransactionDate;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.ComboBox cbTransactionType;
        private System.Windows.Forms.ErrorProvider epTransactionData;
    }
}