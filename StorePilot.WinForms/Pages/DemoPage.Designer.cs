namespace StorePilot.WinForms.Pages;

partial class DemoPage
{
    private System.ComponentModel.IContainer components=null!;
    private StorePilot.WinForms.Controls.PageHeader header=null!;
    private Krypton.Toolkit.KryptonPanel panel=null!;
    private Krypton.Toolkit.KryptonLabel text=null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        header = new StorePilot.WinForms.Controls.PageHeader();
        panel = new Krypton.Toolkit.KryptonPanel();
        text = new Krypton.Toolkit.KryptonLabel();
        ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
        panel.SuspendLayout();
        SuspendLayout();
        // 
        // header
        // 
        header.BackColor = Color.FromArgb(246, 247, 249);
        header.Description = "الوصف";
        header.Dock = DockStyle.Top;
        header.Location = new Point(18, 18);
        header.Name = "header";
        header.RightToLeft = RightToLeft.Yes;
        header.Size = new Size(1150, 68);
        header.TabIndex = 1;
        header.Title = "العنوان";
        // 
        // panel
        // 
        panel.Controls.Add(text);
        panel.Dock = DockStyle.Fill;
        panel.Location = new Point(18, 86);
        panel.Name = "panel";
        panel.Padding = new Padding(24);
        panel.Size = new Size(1150, 413);
        panel.TabIndex = 0;
        // 
        // text
        // 
        text.Dock = DockStyle.Top;
        text.Location = new Point(24, 24);
        text.Name = "text";
        text.Size = new Size(1102, 24);
        text.TabIndex = 0;
        text.Values.Text = "هذه الصفحة جزء من الـ UI prototype. سيتم استبدال محتواها بالبيانات التجريبية التفصيلية قبل اعتماد العميل.";
        // 
        // DemoPage
        // 
        Controls.Add(panel);
        Controls.Add(header);
        Name = "DemoPage";
        Padding = new Padding(18);
        RightToLeft = RightToLeft.Yes;
        Size = new Size(1186, 517);
        ((System.ComponentModel.ISupportInitialize)panel).EndInit();
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ResumeLayout(false);
    }
}
