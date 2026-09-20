namespace StorePilot.WinForms.Forms;

partial class SplashForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel backgroundPanel = null!;
    private Panel contentPanel = null!;
    private Label logoMarkLabel = null!;
    private Label brandLabel = null!;
    private Label subtitleLabel = null!;
    private Label loadingLabel = null!;
    private Panel loadingTrackPanel = null!;
    private Panel loadingProgressPanel = null!;
    private Label versionLabel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        backgroundPanel = new Panel();
        contentPanel = new Panel();
        versionLabel = new Label();
        loadingLabel = new Label();
        loadingTrackPanel = new Panel();
        loadingProgressPanel = new Panel();
        subtitleLabel = new Label();
        brandLabel = new Label();
        logoMarkLabel = new Label();
        logoMarkPictureBox = new PictureBox();
        backgroundPanel.SuspendLayout();
        contentPanel.SuspendLayout();
        loadingTrackPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoMarkPictureBox).BeginInit();
        SuspendLayout();
        // 
        // backgroundPanel
        // 
        backgroundPanel.BackColor = Color.FromArgb(20, 24, 32);
        backgroundPanel.Controls.Add(contentPanel);
        backgroundPanel.Dock = DockStyle.Fill;
        backgroundPanel.Location = new Point(0, 0);
        backgroundPanel.Name = "backgroundPanel";
        backgroundPanel.Padding = new Padding(40);
        backgroundPanel.Size = new Size(539, 360);
        backgroundPanel.TabIndex = 0;
        // 
        // contentPanel
        // 
        contentPanel.BackColor = Color.FromArgb(20, 24, 32);
        contentPanel.Controls.Add(logoMarkPictureBox);
        contentPanel.Controls.Add(versionLabel);
        contentPanel.Controls.Add(loadingLabel);
        contentPanel.Controls.Add(loadingTrackPanel);
        contentPanel.Controls.Add(subtitleLabel);
        contentPanel.Controls.Add(brandLabel);
        contentPanel.Controls.Add(logoMarkLabel);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(40, 40);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(459, 280);
        contentPanel.TabIndex = 0;
        // 
        // versionLabel
        // 
        versionLabel.Dock = DockStyle.Bottom;
        versionLabel.Font = new Font("Segoe UI", 8F);
        versionLabel.ForeColor = Color.FromArgb(120, 130, 145);
        versionLabel.Location = new Point(0, 220);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new Size(459, 25);
        versionLabel.TabIndex = 0;
        versionLabel.Text = "Prototype • v0.1";
        versionLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // loadingLabel
        // 
        loadingLabel.Dock = DockStyle.Bottom;
        loadingLabel.Font = new Font("Segoe UI", 9F);
        loadingLabel.ForeColor = Color.FromArgb(170, 180, 195);
        loadingLabel.Location = new Point(0, 245);
        loadingLabel.Name = "loadingLabel";
        loadingLabel.Size = new Size(459, 31);
        loadingLabel.TabIndex = 1;
        loadingLabel.Text = "جاري تجهيز النظام...";
        loadingLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // loadingTrackPanel
        // 
        loadingTrackPanel.BackColor = Color.FromArgb(50, 57, 70);
        loadingTrackPanel.Controls.Add(loadingProgressPanel);
        loadingTrackPanel.Dock = DockStyle.Bottom;
        loadingTrackPanel.Location = new Point(0, 276);
        loadingTrackPanel.Name = "loadingTrackPanel";
        loadingTrackPanel.Size = new Size(459, 4);
        loadingTrackPanel.TabIndex = 2;
        // 
        // loadingProgressPanel
        // 
        loadingProgressPanel.BackColor = Color.FromArgb(76, 151, 255);
        loadingProgressPanel.Dock = DockStyle.Left;
        loadingProgressPanel.Location = new Point(0, 0);
        loadingProgressPanel.Name = "loadingProgressPanel";
        loadingProgressPanel.Size = new Size(130, 4);
        loadingProgressPanel.TabIndex = 0;
        // 
        // subtitleLabel
        // 
        subtitleLabel.Dock = DockStyle.Top;
        subtitleLabel.Font = new Font("Segoe UI", 10F);
        subtitleLabel.ForeColor = Color.FromArgb(170, 180, 195);
        subtitleLabel.Location = new Point(0, 50);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(459, 30);
        subtitleLabel.TabIndex = 3;
        subtitleLabel.Text = "نظام إدارة المبيعات والمشتريات والمخزون";
        subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // brandLabel
        // 
        brandLabel.Dock = DockStyle.Top;
        brandLabel.Font = new Font("Segoe UI Semibold", 24F);
        brandLabel.ForeColor = Color.White;
        brandLabel.Location = new Point(0, 0);
        brandLabel.Name = "brandLabel";
        brandLabel.Size = new Size(459, 50);
        brandLabel.TabIndex = 4;
        brandLabel.Text = "StorePilot";
        brandLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // logoMarkLabel
        // 
        logoMarkLabel.BackColor = Color.FromArgb(42, 112, 222);
        logoMarkLabel.Font = new Font("Segoe UI Semibold", 24F);
        logoMarkLabel.ForeColor = Color.White;
        logoMarkLabel.Location = new Point(186, 119);
        logoMarkLabel.Name = "logoMarkLabel";
        logoMarkLabel.Size = new Size(74, 74);
        logoMarkLabel.TabIndex = 5;
        logoMarkLabel.Text = "SP";
        logoMarkLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LogoMarkPictureBox
        // 
        logoMarkPictureBox.Location = new Point(186, 119);
        logoMarkPictureBox.Name = "LogoMarkPictureBox";
        logoMarkPictureBox.Size = new Size(74, 74);
        logoMarkPictureBox.TabIndex = 6;
        logoMarkPictureBox.TabStop = false;
        // 
        // SplashForm
        // 
        BackColor = Color.FromArgb(20, 24, 32);
        ClientSize = new Size(539, 360);
        Controls.Add(backgroundPanel);
        FormBorderStyle = FormBorderStyle.None;
        Name = "SplashForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "StorePilot";
        backgroundPanel.ResumeLayout(false);
        contentPanel.ResumeLayout(false);
        loadingTrackPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoMarkPictureBox).EndInit();
        ResumeLayout(false);
    }

    private PictureBox logoMarkPictureBox;
}