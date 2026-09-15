using StorePilot.WinForms.Theme;
using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms;

public sealed class PlaceholderPage : UserControl
{
    public PlaceholderPage(string title)
    {
        Dock = DockStyle.Fill;
        Padding = new Padding(30);

        var label = new Label
        {
            Text = title,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 22F, FontStyle.Bold)
        };

        Controls.Add(label);

        AppTheme.Apply(this);
    }
}