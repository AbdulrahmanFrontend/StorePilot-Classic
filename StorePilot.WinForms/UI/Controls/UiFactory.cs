using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.UI.Controls
{
    public static class UiFactory
    {
        public static KryptonPanel CreateSurface()
        {
            var panel = new KryptonPanel
            {
                Dock = DockStyle.Fill
            };
            panel.StateCommon.Color1 = AppTheme.Surface;
            return panel;
        }

        public static KryptonLabel CreateTitle(string text)
        {
            var label = new KryptonLabel { AutoSize = true };
            label.StateCommon.ShortText.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label.StateCommon.ShortText.Color1 = AppTheme.Text;
            label.Values.Text = text;
            return label;
        }

        public static KryptonLabel CreateSubtitle(string text)
        {
            var label = new KryptonLabel { AutoSize = true };
            label.StateCommon.ShortText.Font = new Font("Segoe UI", 9.5F);
            label.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;
            label.Values.Text = text;
            return label;
        }

        public static KryptonButton CreatePrimaryButton(string text)
        {
            var button = new KryptonButton
            {
                Height = 38,
                Width = 125
            };
            button.Values.Text = text;
            button.StateCommon.Back.Color1 = AppTheme.Primary;
            button.StateCommon.Back.Color2 = AppTheme.Primary;
            button.StateCommon.Content.ShortText.Color1 = Color.White;
            button.StateCommon.Border.DrawBorders = PaletteDrawBorders.None;
            return button;
        }

        public static KryptonButton CreateSecondaryButton(string text)
        {
            var button = new KryptonButton
            {
                Height = 38,
                Width = 110
            };
            button.Values.Text = text;
            button.StateCommon.Back.Color1 = AppTheme.Surface;
            button.StateCommon.Back.Color2 = AppTheme.Surface;
            button.StateCommon.Content.ShortText.Color1 = AppTheme.Text;
            return button;
        }
    }
}
