namespace StorePilot.WinForms.Forms
{
    partial class ShopSetupForm
    {
        private System.ComponentModel.IContainer components = null;
        private Krypton.Toolkit.KryptonPanel pnlMain;
        private Krypton.Toolkit.KryptonLabel lblTitle;
        private Krypton.Toolkit.KryptonLabel lblShopName;
        private Krypton.Toolkit.KryptonLabel lblUserName;
        private Krypton.Toolkit.KryptonLabel lblLogo;
        private Krypton.Toolkit.KryptonTextBox txtShopName;
        private Krypton.Toolkit.KryptonTextBox txtUserName;
        private Krypton.Toolkit.KryptonButton btnBrowseLogo;
        private Krypton.Toolkit.KryptonButton btnRemoveLogo;
        private Krypton.Toolkit.KryptonButton btnSave;
        private Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.PictureBox picLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Krypton.Toolkit.KryptonPanel();
            btnCancel = new Krypton.Toolkit.KryptonButton();
            btnSave = new Krypton.Toolkit.KryptonButton();
            btnRemoveLogo = new Krypton.Toolkit.KryptonButton();
            btnBrowseLogo = new Krypton.Toolkit.KryptonButton();
            picLogo = new PictureBox();
            lblLogo = new Krypton.Toolkit.KryptonLabel();
            txtUserName = new Krypton.Toolkit.KryptonTextBox();
            lblUserName = new Krypton.Toolkit.KryptonLabel();
            txtShopName = new Krypton.Toolkit.KryptonTextBox();
            lblShopName = new Krypton.Toolkit.KryptonLabel();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(btnSave);
            pnlMain.Controls.Add(btnRemoveLogo);
            pnlMain.Controls.Add(btnBrowseLogo);
            pnlMain.Controls.Add(picLogo);
            pnlMain.Controls.Add(lblLogo);
            pnlMain.Controls.Add(txtUserName);
            pnlMain.Controls.Add(lblUserName);
            pnlMain.Controls.Add(txtShopName);
            pnlMain.Controls.Add(lblShopName);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(45);
            pnlMain.Size = new Size(760, 440);
            pnlMain.StateCommon.Color1 = Color.White;
            pnlMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(560, 345);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(155, 45);
            btnCancel.TabIndex = 0;
            btnCancel.Values.DropDownArrowColor = Color.Empty;
            btnCancel.Values.Text = "إلغاء";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(390, 345);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(155, 45);
            btnSave.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 10.5F);
            btnSave.TabIndex = 1;
            btnSave.Values.DropDownArrowColor = Color.Empty;
            btnSave.Values.Text = "حفظ والمتابعة";
            btnSave.Click += btnSave_Click;
            // 
            // btnRemoveLogo
            // 
            btnRemoveLogo.Location = new Point(240, 215);
            btnRemoveLogo.Name = "btnRemoveLogo";
            btnRemoveLogo.Size = new Size(105, 42);
            btnRemoveLogo.TabIndex = 2;
            btnRemoveLogo.Values.DropDownArrowColor = Color.Empty;
            btnRemoveLogo.Values.Text = "إزالة";
            btnRemoveLogo.Click += btnRemoveLogo_Click;
            // 
            // btnBrowseLogo
            // 
            btnBrowseLogo.Location = new Point(240, 160);
            btnBrowseLogo.Name = "btnBrowseLogo";
            btnBrowseLogo.Size = new Size(105, 42);
            btnBrowseLogo.TabIndex = 3;
            btnBrowseLogo.Values.DropDownArrowColor = Color.Empty;
            btnBrowseLogo.Values.Text = "اختيار صورة";
            btnBrowseLogo.Click += btnBrowseLogo_Click;
            // 
            // picLogo
            // 
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(45, 145);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(180, 180);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 4;
            picLogo.TabStop = false;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = false;
            lblLogo.Location = new Point(45, 110);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(300, 30);
            lblLogo.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 10F);
            lblLogo.TabIndex = 5;
            lblLogo.Values.Text = "لوجو المحل (اختياري)";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(390, 240);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(325, 32);
            txtUserName.StateCommon.Content.Font = new Font("Segoe UI", 11F);
            txtUserName.TabIndex = 6;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = false;
            lblUserName.Location = new Point(390, 205);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(325, 30);
            lblUserName.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 10F);
            lblUserName.TabIndex = 7;
            lblUserName.Values.Text = "اسم المستخدم *";
            // 
            // txtShopName
            // 
            txtShopName.Location = new Point(390, 145);
            txtShopName.Name = "txtShopName";
            txtShopName.Size = new Size(325, 32);
            txtShopName.StateCommon.Content.Font = new Font("Segoe UI", 11F);
            txtShopName.TabIndex = 8;
            txtShopName.TextChanged += txtShopName_TextChanged;
            // 
            // lblShopName
            // 
            lblShopName.AutoSize = false;
            lblShopName.Location = new Point(390, 110);
            lblShopName.Name = "lblShopName";
            lblShopName.Size = new Size(325, 30);
            lblShopName.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 10F);
            lblShopName.TabIndex = 9;
            lblShopName.Values.Text = "اسم المحل *";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(45, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(670, 45);
            lblTitle.StateCommon.ShortText.Color1 = Color.FromArgb(31, 41, 55);
            lblTitle.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 20F);
            lblTitle.TabIndex = 10;
            lblTitle.Values.Text = "إعداد معلومات المحل";
            // 
            // ShopSetupForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(760, 440);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Far;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShopSetupForm";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "معلومات المحل";
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }
    }
}
