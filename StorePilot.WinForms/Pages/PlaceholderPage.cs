using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.UI.Controls;

namespace StorePilot.WinForms.Pages
{
    public sealed class PlaceholderPage : UserControl
    {
        public PlaceholderPage(string title)
        {
            Dock = DockStyle.Fill;
            BackColor = AppTheme.Background;

            var panel = new KryptonPanel { Dock = DockStyle.Fill };
            panel.StateCommon.Color1 = AppTheme.Surface;

            var label = UiFactory.CreateTitle(title);
            label.Location = new Point(40, 40);

            var note = UiFactory.CreateSubtitle(
                "هذه الوحدة موجودة في التصميم الأولي وسيتم تنفيذ منطقها في المرحلة التالية.");
            note.Location = new Point(42, 82);

            panel.Controls.Add(note);
            panel.Controls.Add(label);
            Controls.Add(panel);
        }
    }
}
