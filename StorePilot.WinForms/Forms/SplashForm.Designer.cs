namespace StorePilot.WinForms.Forms;

partial class SplashForm
{
    private System.ComponentModel.IContainer components = null!;

    private Krypton.Toolkit.KryptonPanel panel = null!;

    private Label logo = null!,
        title = null!,
        subtitle = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panel = new Krypton.Toolkit.KryptonPanel();
        subtitle = new Label();
        title = new Label();
        logo = new Label();
        ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
        panel.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(subtitle);
        panel.Controls.Add(title);
        panel.Controls.Add(logo);
        panel.Dock = DockStyle.Fill;
        panel.Location = new Point(0, 0);
        panel.Name = "panel";
        panel.Size = new Size(500, 280);
        panel.TabIndex = 0;
        // 
        // subtitle
        // 
        subtitle.Dock = DockStyle.Top;
        subtitle.Location = new Point(0, 140);
        subtitle.Name = "subtitle";
        subtitle.Size = new Size(500, 35);
        subtitle.TabIndex = 0;
        subtitle.Text = "نظام إدارة مخازن";
        subtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // title
        // 
        title.Dock = DockStyle.Top;
        title.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
        title.Location = new Point(0, 90);
        title.Name = "title";
        title.Size = new Size(500, 50);
        title.TabIndex = 1;
        title.Text = "StorePilot";
        title.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // logo
        // 
        logo.Dock = DockStyle.Top;
        logo.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold);
        logo.Location = new Point(0, 0);
        logo.Name = "logo";
        logo.Size = new Size(500, 90);
        logo.TabIndex = 2;
        logo.Text = "SP";
        logo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // SplashForm
        // 
        ClientSize = new Size(500, 280);
        Controls.Add(panel);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        Name = "SplashForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        ((System.ComponentModel.ISupportInitialize)panel).EndInit();
        panel.ResumeLayout(false);
        ResumeLayout(false);
    }
}