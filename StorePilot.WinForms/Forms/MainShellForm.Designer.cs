using Krypton.Toolkit;

namespace StorePilot.WinForms.Forms;

partial class MainShellForm
{ 
    private System.ComponentModel.IContainer components = null; 
    private Krypton.Toolkit.KryptonPanel sidebar = null!,
        header = null!,
        content = null!; 

    private FlowLayoutPanel sidebarFlow = null!; 

    private Krypton.Toolkit.KryptonLabel shopLabel = null!,
        userLabel = null!; 

    private Panel contentHost = null!;

    protected override void Dispose(bool disposing) 
    { 
        if (disposing)
            components?.Dispose();
        
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        sidebar = new KryptonPanel();
        sidebarFlow = new FlowLayoutPanel();
        userLabel = new KryptonLabel();
        shopLabel = new KryptonLabel();
        header = new KryptonPanel();
        settings = new KryptonButton();
        backup = new KryptonButton();
        content = new KryptonPanel();
        contentHost = new Panel();
        ((System.ComponentModel.ISupportInitialize)sidebar).BeginInit();
        sidebar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)header).BeginInit();
        header.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)content).BeginInit();
        content.SuspendLayout();
        SuspendLayout();
        // 
        // sidebar
        // 
        sidebar.Controls.Add(sidebarFlow);
        sidebar.Controls.Add(userLabel);
        sidebar.Controls.Add(shopLabel);
        sidebar.Dock = DockStyle.Right;
        sidebar.Location = new Point(940, 0);
        sidebar.Name = "sidebar";
        sidebar.Padding = new Padding(12);
        sidebar.Size = new Size(220, 573);
        sidebar.TabIndex = 2;
        // 
        // sidebarFlow
        // 
        sidebarFlow.AutoScroll = true;
        sidebarFlow.Dock = DockStyle.Fill;
        sidebarFlow.FlowDirection = FlowDirection.TopDown;
        sidebarFlow.Location = new Point(12, 60);
        sidebarFlow.Name = "sidebarFlow";
        sidebarFlow.Padding = new Padding(0, 15, 0, 0);
        sidebarFlow.Size = new Size(196, 501);
        sidebarFlow.TabIndex = 0;
        sidebarFlow.WrapContents = false;
        // 
        // userLabel
        // 
        userLabel.Dock = DockStyle.Top;
        userLabel.Location = new Point(12, 36);
        userLabel.Name = "userLabel";
        userLabel.RightToLeft = RightToLeft.Yes;
        userLabel.Size = new Size(196, 24);
        userLabel.TabIndex = 1;
        userLabel.Values.Text = "المستخدم";
        // 
        // shopLabel
        // 
        shopLabel.Dock = DockStyle.Top;
        shopLabel.Location = new Point(12, 12);
        shopLabel.Name = "shopLabel";
        shopLabel.RightToLeft = RightToLeft.Yes;
        shopLabel.Size = new Size(196, 24);
        shopLabel.TabIndex = 2;
        shopLabel.Values.Text = "StorePilot";
        // 
        // header
        // 
        header.Controls.Add(settings);
        header.Controls.Add(backup);
        header.Dock = DockStyle.Top;
        header.Location = new Point(0, 0);
        header.Name = "header";
        header.Padding = new Padding(14);
        header.Size = new Size(940, 62);
        header.TabIndex = 1;
        // 
        // settings
        // 
        settings.Dock = DockStyle.Left;
        settings.Location = new Point(114, 14);
        settings.Name = "settings";
        settings.Size = new Size(100, 34);
        settings.TabIndex = 1;
        settings.Values.DropDownArrowColor = Color.Empty;
        settings.Values.Text = "الإعدادات";
        settings.Click += settings_Click;
        // 
        // backup
        // 
        backup.Dock = DockStyle.Left;
        backup.Location = new Point(14, 14);
        backup.Name = "backup";
        backup.Size = new Size(100, 34);
        backup.TabIndex = 0;
        backup.Values.DropDownArrowColor = Color.Empty;
        backup.Values.Text = "نسخ احتياطي";
        backup.Click += backup_Click;
        // 
        // content
        // 
        content.Controls.Add(contentHost);
        content.Dock = DockStyle.Fill;
        content.Location = new Point(0, 62);
        content.Name = "content";
        content.Size = new Size(940, 511);
        content.TabIndex = 0;
        // 
        // contentHost
        // 
        contentHost.Dock = DockStyle.Fill;
        contentHost.Location = new Point(0, 0);
        contentHost.Name = "contentHost";
        contentHost.Padding = new Padding(12);
        contentHost.Size = new Size(940, 511);
        contentHost.TabIndex = 0;
        // 
        // MainShellForm
        // 
        ClientSize = new Size(1160, 573);
        Controls.Add(content);
        Controls.Add(header);
        Controls.Add(sidebar);
        MinimumSize = new Size(980, 620);
        Name = "MainShellForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "StorePilot";
        WindowState = FormWindowState.Maximized;
        ((System.ComponentModel.ISupportInitialize)sidebar).EndInit();
        sidebar.ResumeLayout(false);
        sidebar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)header).EndInit();
        header.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)content).EndInit();
        content.ResumeLayout(false);
        ResumeLayout(false);
    }

    private KryptonButton backup;
    private KryptonButton settings;
}
