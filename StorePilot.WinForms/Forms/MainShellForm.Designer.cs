namespace StorePilot.WinForms.Forms
{
    partial class MainShellForm
    {
        private Krypton.Toolkit.KryptonPanel sidebarPanel;
        private Krypton.Toolkit.KryptonPanel headerPanel;
        private Krypton.Toolkit.KryptonPanel contentHost;
        private System.Windows.Forms.FlowLayoutPanel sidebarFlow;
        private Krypton.Toolkit.KryptonLabel shopNameLabel;
        private Krypton.Toolkit.KryptonLabel userNameLabel;
        private Krypton.Toolkit.KryptonButton settingsButton;
        private Krypton.Toolkit.KryptonButton themeButton;
        private Krypton.Toolkit.KryptonButton homeButton;
        private Krypton.Toolkit.KryptonLabel appTitleLabel;

        private void InitializeComponent()
        {
            sidebarPanel = new Krypton.Toolkit.KryptonPanel();
            sidebarFlow = new FlowLayoutPanel();
            headerPanel = new Krypton.Toolkit.KryptonPanel();
            homeButton = new Krypton.Toolkit.KryptonButton();
            themeButton = new Krypton.Toolkit.KryptonButton();
            settingsButton = new Krypton.Toolkit.KryptonButton();
            userNameLabel = new Krypton.Toolkit.KryptonLabel();
            shopNameLabel = new Krypton.Toolkit.KryptonLabel();
            appTitleLabel = new Krypton.Toolkit.KryptonLabel();
            contentHost = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)sidebarPanel).BeginInit();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerPanel).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contentHost).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.Controls.Add(sidebarFlow);
            sidebarPanel.Dock = DockStyle.Right;
            sidebarPanel.Location = new Point(1596, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(185, 760);
            sidebarPanel.StateCommon.Color1 = Color.FromArgb(32, 36, 42);
            sidebarPanel.TabIndex = 2;
            // 
            // sidebarFlow
            // 
            sidebarFlow.AutoScroll = true;
            sidebarFlow.BackColor = Color.FromArgb(32, 36, 42);
            sidebarFlow.Dock = DockStyle.Fill;
            sidebarFlow.FlowDirection = FlowDirection.TopDown;
            sidebarFlow.Location = new Point(0, 0);
            sidebarFlow.Name = "sidebarFlow";
            sidebarFlow.Padding = new Padding(7, 85, 7, 10);
            sidebarFlow.Size = new Size(185, 760);
            sidebarFlow.TabIndex = 0;
            sidebarFlow.WrapContents = false;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(homeButton);
            headerPanel.Controls.Add(themeButton);
            headerPanel.Controls.Add(settingsButton);
            headerPanel.Controls.Add(userNameLabel);
            headerPanel.Controls.Add(shopNameLabel);
            headerPanel.Controls.Add(appTitleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1596, 119);
            headerPanel.StateCommon.Color1 = Color.White;
            headerPanel.TabIndex = 1;
            // 
            // homeButton
            // 
            homeButton.Dock = DockStyle.Right;
            homeButton.Location = new Point(1521, 0);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(75, 119);
            homeButton.TabIndex = 0;
            homeButton.Values.DropDownArrowColor = Color.Empty;
            homeButton.Values.Text = "الرئيسية";
            homeButton.Click += homeButton_Click;
            // 
            // themeButton
            // 
            themeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            themeButton.Location = new Point(2006, 15);
            themeButton.Name = "themeButton";
            themeButton.Size = new Size(95, 40);
            themeButton.TabIndex = 1;
            themeButton.Values.DropDownArrowColor = Color.Empty;
            themeButton.Values.Text = "الوضع";
            themeButton.Click += themeButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            settingsButton.Location = new Point(2116, 15);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(120, 40);
            settingsButton.TabIndex = 2;
            settingsButton.Values.DropDownArrowColor = Color.Empty;
            settingsButton.Values.Text = "إعدادات المحل";
            settingsButton.Click += settingsButton_Click;
            // 
            // userNameLabel
            // 
            userNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            userNameLabel.Location = new Point(2031, 39);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(73, 24);
            userNameLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 9F);
            userNameLabel.TabIndex = 3;
            userNameLabel.Values.Text = "المستخدم";
            // 
            // shopNameLabel
            // 
            shopNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            shopNameLabel.Location = new Point(1833, 13);
            shopNameLabel.Name = "shopNameLabel";
            shopNameLabel.Size = new Size(95, 29);
            shopNameLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            shopNameLabel.TabIndex = 4;
            shopNameLabel.Values.Text = "اسم المحل";
            // 
            // appTitleLabel
            // 
            appTitleLabel.Dock = DockStyle.Left;
            appTitleLabel.Location = new Point(0, 0);
            appTitleLabel.Name = "appTitleLabel";
            appTitleLabel.Size = new Size(126, 119);
            appTitleLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            appTitleLabel.TabIndex = 5;
            appTitleLabel.Values.Text = "StorePilot";
            // 
            // contentHost
            // 
            contentHost.Dock = DockStyle.Fill;
            contentHost.Location = new Point(0, 119);
            contentHost.Name = "contentHost";
            contentHost.Size = new Size(1596, 641);
            contentHost.StateCommon.Color1 = Color.FromArgb(245, 246, 248);
            contentHost.TabIndex = 0;
            // 
            // MainShellForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1781, 760);
            Controls.Add(contentHost);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Far;
            MinimumSize = new Size(1000, 650);
            Name = "MainShellForm";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StorePilot";
            UseDropShadow = true;
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)sidebarPanel).EndInit();
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)headerPanel).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)contentHost).EndInit();
            ResumeLayout(false);
        }
    }
}
