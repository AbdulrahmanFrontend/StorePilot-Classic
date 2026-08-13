namespace StorePilot.UI.Returns
{
    partial class frmAddEditReturnInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditReturnInvoice));
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnSavePrint = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnInvoiceItems = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnCancel = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInvoiceDate = new System.Windows.Forms.TableLayoutPanel();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.tlpTotalAmount = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.tlpNotes = new System.Windows.Forms.TableLayoutPanel();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.epReturnData = new System.Windows.Forms.ErrorProvider(this.components);
            this.flpFooter.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.tlpUp.SuspendLayout();
            this.tlpInvoiceDate.SuspendLayout();
            this.tlpTotalAmount.SuspendLayout();
            this.tlpNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epReturnData)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(664, 46);
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
            this.flpFooter.Controls.Add(this.btnCancel);
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpFooter.Location = new System.Drawing.Point(0, 289);
            this.flpFooter.Name = "flpFooter";
            this.flpFooter.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flpFooter.Size = new System.Drawing.Size(664, 40);
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
            this.btnClose.TabIndex = 5;
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
            this.btnSavePrint.TabIndex = 4;
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
            this.btnInvoiceItems.TabIndex = 3;
            this.btnInvoiceItems.Text = "إضافة عناصر الفاتورة";
            this.btnInvoiceItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInvoiceItems.UseVisualStyleBackColor = false;
            this.btnInvoiceItems.Click += new System.EventHandler(this.btnInvoiceItems_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(410, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(88, 28);
            this.btnCancel.TabIndex = 2;
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
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.45267F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.54733F));
            this.tlpContainer.Size = new System.Drawing.Size(664, 243);
            this.tlpContainer.TabIndex = 13;
            // 
            // tlpUp
            // 
            this.tlpUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpUp.ColumnCount = 2;
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Controls.Add(this.tlpInvoiceDate, 0, 0);
            this.tlpUp.Controls.Add(this.tlpTotalAmount, 1, 0);
            this.tlpUp.Location = new System.Drawing.Point(3, 3);
            this.tlpUp.Name = "tlpUp";
            this.tlpUp.RowCount = 1;
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Size = new System.Drawing.Size(658, 67);
            this.tlpUp.TabIndex = 0;
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
            this.tlpInvoiceDate.Location = new System.Drawing.Point(332, 3);
            this.tlpInvoiceDate.Name = "tlpInvoiceDate";
            this.tlpInvoiceDate.RowCount = 2;
            this.tlpInvoiceDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInvoiceDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpInvoiceDate.Size = new System.Drawing.Size(323, 61);
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
            this.lblInvoiceDate.Size = new System.Drawing.Size(317, 25);
            this.lblInvoiceDate.TabIndex = 0;
            this.lblInvoiceDate.Text = "تاريخ الإرجاع:";
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
            this.dtpInvoiceDate.Location = new System.Drawing.Point(20, 28);
            this.dtpInvoiceDate.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.dtpInvoiceDate.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtpInvoiceDate.MinDate = new System.DateTime(1981, 1, 1, 0, 0, 0, 0);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(300, 30);
            this.dtpInvoiceDate.TabIndex = 0;
            this.dtpInvoiceDate.Value = new System.DateTime(2026, 8, 12, 16, 29, 11, 0);
            this.dtpInvoiceDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpInvoiceDate_Validating);
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
            this.tlpTotalAmount.Location = new System.Drawing.Point(3, 3);
            this.tlpTotalAmount.Name = "tlpTotalAmount";
            this.tlpTotalAmount.RowCount = 2;
            this.tlpTotalAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTotalAmount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTotalAmount.Size = new System.Drawing.Size(323, 61);
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
            this.lblTotalAmount.Size = new System.Drawing.Size(317, 25);
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
            this.tbTotalAmount.Location = new System.Drawing.Point(20, 28);
            this.tbTotalAmount.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbTotalAmount.MaxLength = 6;
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.ReadOnly = true;
            this.tbTotalAmount.Size = new System.Drawing.Size(300, 30);
            this.tbTotalAmount.TabIndex = 1;
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
            this.tlpNotes.Location = new System.Drawing.Point(3, 76);
            this.tlpNotes.Name = "tlpNotes";
            this.tlpNotes.RowCount = 2;
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpNotes.Size = new System.Drawing.Size(658, 164);
            this.tlpNotes.TabIndex = 1;
            // 
            // tbNotes
            // 
            this.tbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(20, 27);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbNotes.MaxLength = 500;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(635, 134);
            this.tbNotes.TabIndex = 1;
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
            this.lblNotes.Size = new System.Drawing.Size(652, 24);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "ملاحظات:";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epReturnData
            // 
            this.epReturnData.ContainerControl = this;
            this.epReturnData.RightToLeft = true;
            // 
            // frmAddEditReturnInvoice
            // 
            this.AcceptButton = this.btnSavePrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(664, 329);
            this.Controls.Add(this.tlpContainer);
            this.Controls.Add(this.flpFooter);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditReturnInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditReturnInvoice";
            this.Load += new System.EventHandler(this.frmAddEditReturnInvoice_Load);
            this.flpFooter.ResumeLayout(false);
            this.tlpContainer.ResumeLayout(false);
            this.tlpUp.ResumeLayout(false);
            this.tlpInvoiceDate.ResumeLayout(false);
            this.tlpTotalAmount.ResumeLayout(false);
            this.tlpTotalAmount.PerformLayout();
            this.tlpNotes.ResumeLayout(false);
            this.tlpNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epReturnData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpFooter;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnClose;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnSavePrint;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnInvoiceItems;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.TableLayoutPanel tlpUp;
        private System.Windows.Forms.TableLayoutPanel tlpTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox tbTotalAmount;
        private System.Windows.Forms.TableLayoutPanel tlpInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.TableLayoutPanel tlpNotes;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ErrorProvider epReturnData;
    }
}