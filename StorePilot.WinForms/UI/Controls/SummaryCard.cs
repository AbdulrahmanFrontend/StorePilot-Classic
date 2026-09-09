using System.Drawing;
using Krypton.Toolkit;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.UI.Controls
{
    public sealed class SummaryCard : KryptonPanel
    {
        private readonly KryptonLabel _value;
        private readonly KryptonLabel _caption;

        public SummaryCard(string caption, string value)
        {
            Height = 105;
            Dock = System.Windows.Forms.DockStyle.Fill;
            Margin = new System.Windows.Forms.Padding(6);
            StateCommon.Color1 = AppTheme.Surface;
            StateCommon.Color2 = AppTheme.Surface;

            _caption = new KryptonLabel { AutoSize = true };
            _caption.Location = new Point(18, 17);
            _caption.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;
            _caption.Values.Text = caption;

            _value = new KryptonLabel { AutoSize = true };
            _value.Location = new Point(18, 43);
            _value.StateCommon.ShortText.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            _value.StateCommon.ShortText.Color1 = AppTheme.Text;
            _value.Values.Text = value;

            Controls.Add(_value);
            Controls.Add(_caption);
        }

        public void SetValue(string value)
        {
            _value.Values.Text = value;
        }

        public void ApplyTheme()
        {
            StateCommon.Color1 = AppTheme.Surface;
            StateCommon.Color2 = AppTheme.Surface;
            _caption.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;
            _value.StateCommon.ShortText.Color1 = AppTheme.Text;
        }
    }
}
