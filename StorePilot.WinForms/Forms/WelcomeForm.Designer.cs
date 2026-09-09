namespace StorePilot.WinForms.Forms
{
    partial class WelcomeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Krypton.Toolkit.KryptonPanel pnlMain;
        private Krypton.Toolkit.KryptonLabel lblTitle;
        private Krypton.Toolkit.KryptonLabel lblSubtitle;
        private Krypton.Toolkit.KryptonLabel lblDescription;
        private Krypton.Toolkit.KryptonButton btnStart;
        private Krypton.Toolkit.KryptonButton btnExit;
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
            btnExit = new Krypton.Toolkit.KryptonButton();
            btnStart = new Krypton.Toolkit.KryptonButton();
            lblDescription = new Krypton.Toolkit.KryptonLabel();
            lblSubtitle = new Krypton.Toolkit.KryptonLabel();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            picLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnExit);
            pnlMain.Controls.Add(btnStart);
            pnlMain.Controls.Add(lblDescription);
            pnlMain.Controls.Add(lblSubtitle);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(picLogo);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(55);
            pnlMain.Size = new Size(760, 455);
            pnlMain.StateCommon.Color1 = Color.White;
            pnlMain.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(275, 335);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 45);
            btnExit.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 10F);
            btnExit.TabIndex = 1;
            btnExit.Values.DropDownArrowColor = Color.Empty;
            btnExit.Values.Text = "إغلاق";
            btnExit.Click += btnExit_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(55, 335);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(205, 45);
            btnStart.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 11F);
            btnStart.TabIndex = 0;
            btnStart.Values.DropDownArrowColor = Color.Empty;
            btnStart.Values.Text = "بدء إعداد النظام";
            btnStart.Click += btnStart_Click;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = false;
            lblDescription.Location = new Point(55, 215);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(635, 75);
            lblDescription.StateCommon.ShortText.Color1 = Color.FromArgb(107, 114, 128);
            lblDescription.StateCommon.ShortText.Font = new Font("Segoe UI", 11F);
            lblDescription.TabIndex = 2;
            lblDescription.Values.Text = "لنبدأ بإعداد معلومات المحل الأساسية. يمكنك تغيير اسم المحل واسم المستخدم واللوجو في أي وقت من إعدادات النظام.";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = false;
            lblSubtitle.Location = new Point(220, 125);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(470, 35);
            lblSubtitle.StateCommon.ShortText.Color1 = Color.FromArgb(75, 85, 99);
            lblSubtitle.StateCommon.ShortText.Font = new Font("Segoe UI", 13F);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Values.Text = "نظام إدارة المبيعات والمخزون";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(220, 58);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(470, 61);
            lblTitle.StateCommon.ShortText.Color1 = Color.FromArgb(31, 41, 55);
            lblTitle.StateCommon.ShortText.Font = new Font("Segoe UI Semibold", 24F);
            lblTitle.TabIndex = 4;
            lblTitle.Values.Text = "مرحبًا بك في StorePilot";
            // 
            // picLogo
            // 
            picLogo.Location = new Point(55, 55);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(130, 130);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 455);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Far;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomeForm";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StorePilot";
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }
    }
}
