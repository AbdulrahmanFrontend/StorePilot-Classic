namespace StorePilot.WinForms.Forms
{
    partial class MainShellForm
    {
        private Krypton.Toolkit.KryptonPanel sidebarPanel;
        private System.Windows.Forms.FlowLayoutPanel sidebarFlow;

        private void InitializeComponent()
        {
            sidebarPanel = new Krypton.Toolkit.KryptonPanel();
            sidebarFlow = new FlowLayoutPanel();
            headerTableLayoutPanel = new TableLayoutPanel();
            appTitleLabel = new Krypton.Toolkit.KryptonLabel();
            shopNameLabel = new Krypton.Toolkit.KryptonLabel();
            userNameLabel = new Krypton.Toolkit.KryptonLabel();
            settingsButton = new Krypton.Toolkit.KryptonButton();
            themeButton = new Krypton.Toolkit.KryptonButton();
            homeButton = new Krypton.Toolkit.KryptonButton();
            contentHost = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)sidebarPanel).BeginInit();
            sidebarPanel.SuspendLayout();
            headerTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contentHost).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.Controls.Add(sidebarFlow);
            sidebarPanel.Dock = DockStyle.Right;
            sidebarPanel.Location = new Point(982, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(185, 603);
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
            sidebarFlow.Size = new Size(185, 603);
            sidebarFlow.TabIndex = 0;
            sidebarFlow.WrapContents = false;
            // 
            // headerTableLayoutPanel
            // 
            headerTableLayoutPanel.ColumnCount = 6;
            headerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            headerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            headerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            headerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            headerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            headerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            headerTableLayoutPanel.Controls.Add(appTitleLabel, 5, 0);
            headerTableLayoutPanel.Controls.Add(shopNameLabel, 4, 0);
            headerTableLayoutPanel.Controls.Add(userNameLabel, 3, 0);
            headerTableLayoutPanel.Controls.Add(settingsButton, 2, 0);
            headerTableLayoutPanel.Controls.Add(themeButton, 1, 0);
            headerTableLayoutPanel.Controls.Add(homeButton, 0, 0);
            headerTableLayoutPanel.Dock = DockStyle.Top;
            headerTableLayoutPanel.Location = new Point(0, 0);
            headerTableLayoutPanel.Name = "headerTableLayoutPanel";
            headerTableLayoutPanel.RowCount = 1;
            headerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headerTableLayoutPanel.Size = new Size(982, 42);
            headerTableLayoutPanel.TabIndex = 0;
            // 
            // appTitleLabel
            // 
            appTitleLabel.Anchor = AnchorStyles.Right;
            appTitleLabel.Location = new Point(3, 3);
            appTitleLabel.Name = "appTitleLabel";
            appTitleLabel.Size = new Size(126, 36);
            appTitleLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            appTitleLabel.TabIndex = 6;
            appTitleLabel.Values.Text = "StorePilot";
            // 
            // shopNameLabel
            // 
            shopNameLabel.Anchor = AnchorStyles.None;
            shopNameLabel.Location = new Point(201, 6);
            shopNameLabel.Name = "shopNameLabel";
            shopNameLabel.Size = new Size(95, 29);
            shopNameLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            shopNameLabel.TabIndex = 5;
            shopNameLabel.Values.Text = "اسم المحل";
            // 
            // userNameLabel
            // 
            userNameLabel.Anchor = AnchorStyles.None;
            userNameLabel.Location = new Point(375, 9);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(73, 24);
            userNameLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 9F);
            userNameLabel.TabIndex = 4;
            userNameLabel.Values.Text = "المستخدم";
            // 
            // settingsButton
            // 
            settingsButton.Anchor = AnchorStyles.None;
            settingsButton.Location = new Point(523, 8);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(104, 26);
            settingsButton.TabIndex = 3;
            settingsButton.Values.DropDownArrowColor = Color.Empty;
            settingsButton.Values.Text = "إعدادات النظام";
            settingsButton.Click += settingsButton_Click;
            // 
            // themeButton
            // 
            themeButton.Anchor = AnchorStyles.None;
            themeButton.Location = new Point(693, 8);
            themeButton.Name = "themeButton";
            themeButton.Size = new Size(90, 26);
            themeButton.TabIndex = 2;
            themeButton.Values.DropDownArrowColor = Color.Empty;
            themeButton.Values.Text = "الوضع";
            themeButton.Click += themeButton_Click;
            // 
            // homeButton
            // 
            homeButton.Anchor = AnchorStyles.Left;
            homeButton.Location = new Point(889, 8);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(90, 26);
            homeButton.TabIndex = 1;
            homeButton.Values.DropDownArrowColor = Color.Empty;
            homeButton.Values.Text = "الرئيسية";
            homeButton.Click += homeButton_Click;
            // 
            // contentHost
            // 
            contentHost.Dock = DockStyle.Fill;
            contentHost.Location = new Point(0, 42);
            contentHost.Name = "contentHost";
            contentHost.Size = new Size(982, 561);
            contentHost.StateCommon.Color1 = Color.FromArgb(245, 246, 248);
            contentHost.TabIndex = 4;
            // 
            // MainShellForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 603);
            Controls.Add(contentHost);
            Controls.Add(headerTableLayoutPanel);
            Controls.Add(sidebarPanel);
            FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Far;
            MinimumSize = new Size(1000, 650);
            Name = "MainShellForm";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StorePilot";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)sidebarPanel).EndInit();
            sidebarPanel.ResumeLayout(false);
            headerTableLayoutPanel.ResumeLayout(false);
            headerTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)contentHost).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel headerTableLayoutPanel;
        private Krypton.Toolkit.KryptonLabel appTitleLabel;
        private Krypton.Toolkit.KryptonLabel shopNameLabel;
        private Krypton.Toolkit.KryptonLabel userNameLabel;
        private Krypton.Toolkit.KryptonButton settingsButton;
        private Krypton.Toolkit.KryptonButton themeButton;
        private Krypton.Toolkit.KryptonButton homeButton;
        private Krypton.Toolkit.KryptonPanel contentHost;
    }
}
