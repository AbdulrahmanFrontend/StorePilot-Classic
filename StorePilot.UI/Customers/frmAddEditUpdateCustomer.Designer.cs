namespace StorePilot.UI.Customers
{
    partial class frmAddEditUpdateCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUpdateCustomer));
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnSave = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnActivate = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAddress = new System.Windows.Forms.TableLayoutPanel();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tlpPhoneNumber = new System.Windows.Forms.TableLayoutPanel();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.tlpName = new System.Windows.Forms.TableLayoutPanel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tlpDown = new System.Windows.Forms.TableLayoutPanel();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.epCustomerData = new System.Windows.Forms.ErrorProvider(this.components);
            this.flpFooter.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.tlpUp.SuspendLayout();
            this.tlpAddress.SuspendLayout();
            this.tlpPhoneNumber.SuspendLayout();
            this.tlpName.SuspendLayout();
            this.tlpDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCustomerData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Image = global::StorePilot.UI.Properties.Resources.customer;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(659, 54);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpFooter
            // 
            this.flpFooter.AutoSize = true;
            this.flpFooter.Controls.Add(this.btnClose);
            this.flpFooter.Controls.Add(this.btnSave);
            this.flpFooter.Controls.Add(this.btnActivate);
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpFooter.Location = new System.Drawing.Point(0, 291);
            this.flpFooter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flpFooter.Name = "flpFooter";
            this.flpFooter.Padding = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.flpFooter.Size = new System.Drawing.Size(659, 47);
            this.flpFooter.TabIndex = 10;
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
            this.btnClose.Location = new System.Drawing.Point(8, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnClose.Size = new System.Drawing.Size(98, 35);
            this.btnClose.TabIndex = 6;
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
            this.btnSave.Location = new System.Drawing.Point(114, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnSave.Size = new System.Drawing.Size(98, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnActivate.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Danger;
            this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnActivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnActivate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Image = global::StorePilot.UI.Properties.Resources.activate_profile;
            this.btnActivate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivate.Location = new System.Drawing.Point(220, 6);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnActivate.Size = new System.Drawing.Size(98, 35);
            this.btnActivate.TabIndex = 4;
            this.btnActivate.Text = "تفعيل";
            this.btnActivate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Controls.Add(this.tlpUp, 0, 0);
            this.tlpContainer.Controls.Add(this.tlpDown, 0, 1);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 54);
            this.tlpContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 2;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Size = new System.Drawing.Size(659, 237);
            this.tlpContainer.TabIndex = 11;
            // 
            // tlpUp
            // 
            this.tlpUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpUp.ColumnCount = 2;
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Controls.Add(this.tlpAddress, 0, 1);
            this.tlpUp.Controls.Add(this.tlpPhoneNumber, 1, 0);
            this.tlpUp.Controls.Add(this.tlpName, 0, 0);
            this.tlpUp.Location = new System.Drawing.Point(4, 3);
            this.tlpUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpUp.Name = "tlpUp";
            this.tlpUp.RowCount = 2;
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Size = new System.Drawing.Size(651, 112);
            this.tlpUp.TabIndex = 4;
            // 
            // tlpAddress
            // 
            this.tlpAddress.ColumnCount = 1;
            this.tlpAddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAddress.Controls.Add(this.tbAddress, 0, 1);
            this.tlpAddress.Controls.Add(this.lblAddress, 0, 0);
            this.tlpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAddress.Location = new System.Drawing.Point(326, 56);
            this.tlpAddress.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAddress.Name = "tlpAddress";
            this.tlpAddress.RowCount = 2;
            this.tlpAddress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAddress.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAddress.Size = new System.Drawing.Size(325, 56);
            this.tlpAddress.TabIndex = 5;
            // 
            // tbAddress
            // 
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddress.Location = new System.Drawing.Point(23, 26);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(4, 3, 23, 3);
            this.tbAddress.MaxLength = 50;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(298, 27);
            this.tbAddress.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Image = global::StorePilot.UI.Properties.Resources.Address_32;
            this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.Location = new System.Drawing.Point(4, 0);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(317, 23);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "العنوان:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpPhoneNumber
            // 
            this.tlpPhoneNumber.ColumnCount = 1;
            this.tlpPhoneNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhoneNumber.Controls.Add(this.tbPhone, 0, 1);
            this.tlpPhoneNumber.Controls.Add(this.lblPhoneNumber, 0, 0);
            this.tlpPhoneNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPhoneNumber.Location = new System.Drawing.Point(0, 0);
            this.tlpPhoneNumber.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPhoneNumber.Name = "tlpPhoneNumber";
            this.tlpPhoneNumber.RowCount = 2;
            this.tlpPhoneNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPhoneNumber.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPhoneNumber.Size = new System.Drawing.Size(326, 56);
            this.tlpPhoneNumber.TabIndex = 4;
            // 
            // tbPhone
            // 
            this.tbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPhone.Location = new System.Drawing.Point(23, 26);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(4, 3, 23, 3);
            this.tbPhone.MaxLength = 20;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(299, 27);
            this.tbPhone.TabIndex = 1;
            this.tbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.tbPhone_Validating);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhoneNumber.Image = global::StorePilot.UI.Properties.Resources.Phone_32;
            this.lblPhoneNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhoneNumber.Location = new System.Drawing.Point(4, 0);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(318, 23);
            this.lblPhoneNumber.TabIndex = 1;
            this.lblPhoneNumber.Text = "رقم الهاتف:";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpName
            // 
            this.tlpName.ColumnCount = 1;
            this.tlpName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpName.Controls.Add(this.tbName, 0, 1);
            this.tlpName.Controls.Add(this.lblName, 0, 0);
            this.tlpName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpName.Location = new System.Drawing.Point(326, 0);
            this.tlpName.Margin = new System.Windows.Forms.Padding(0);
            this.tlpName.Name = "tlpName";
            this.tlpName.RowCount = 2;
            this.tlpName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpName.Size = new System.Drawing.Size(325, 56);
            this.tlpName.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(23, 26);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 3, 23, 3);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(298, 27);
            this.tbName.TabIndex = 0;
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Image = global::StorePilot.UI.Properties.Resources.Person_32;
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Location = new System.Drawing.Point(4, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(317, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "الإسم:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDown
            // 
            this.tlpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDown.ColumnCount = 1;
            this.tlpDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDown.Controls.Add(this.tbNotes, 0, 1);
            this.tlpDown.Controls.Add(this.lblNotes, 0, 0);
            this.tlpDown.Location = new System.Drawing.Point(4, 121);
            this.tlpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpDown.Name = "tlpDown";
            this.tlpDown.RowCount = 2;
            this.tlpDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDown.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDown.Size = new System.Drawing.Size(651, 113);
            this.tlpDown.TabIndex = 5;
            // 
            // tbNotes
            // 
            this.tbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNotes.Location = new System.Drawing.Point(23, 23);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 3, 23, 3);
            this.tbNotes.MaxLength = 500;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(624, 87);
            this.tbNotes.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotes.AutoSize = true;
            this.lblNotes.Image = global::StorePilot.UI.Properties.Resources.Notes_32;
            this.lblNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Location = new System.Drawing.Point(4, 0);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(643, 20);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "ملاحظات:";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epCustomerData
            // 
            this.epCustomerData.ContainerControl = this;
            this.epCustomerData.RightToLeft = true;
            // 
            // frmAddEditUpdateCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(659, 338);
            this.Controls.Add(this.tlpContainer);
            this.Controls.Add(this.flpFooter);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmAddEditUpdateCustomer";
            this.Text = "frmAddEditUpdateCustomer";
            this.Load += new System.EventHandler(this.frmAddEditUpdateCustomer_Load);
            this.flpFooter.ResumeLayout(false);
            this.tlpContainer.ResumeLayout(false);
            this.tlpUp.ResumeLayout(false);
            this.tlpAddress.ResumeLayout(false);
            this.tlpAddress.PerformLayout();
            this.tlpPhoneNumber.ResumeLayout(false);
            this.tlpPhoneNumber.PerformLayout();
            this.tlpName.ResumeLayout(false);
            this.tlpName.PerformLayout();
            this.tlpDown.ResumeLayout(false);
            this.tlpDown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCustomerData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpFooter;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnClose;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnSave;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnActivate;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.TableLayoutPanel tlpUp;
        private System.Windows.Forms.TableLayoutPanel tlpAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TableLayoutPanel tlpPhoneNumber;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TableLayoutPanel tlpName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TableLayoutPanel tlpDown;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ErrorProvider epCustomerData;
    }
}