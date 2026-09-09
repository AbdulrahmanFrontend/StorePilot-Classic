using Krypton.Toolkit;
using System.Drawing;

namespace StorePilot.WinForms.Theme
{
    /// <summary>
    /// نظام ألوان مركزي بسيط.
    /// الهدف ألا نضع ألواناً عشوائية داخل كل Form.
    /// </summary>
    public static class AppTheme
    {
        public static AppThemeMode CurrentMode { get; private set; } = AppThemeMode.Light;

        public static Color Background => CurrentMode == AppThemeMode.Light
            ? Color.FromArgb(245, 246, 248)
            : Color.FromArgb(30, 32, 36);

        public static Color Surface => CurrentMode == AppThemeMode.Light
            ? Color.White
            : Color.FromArgb(42, 45, 50);

        public static Color Sidebar => CurrentMode == AppThemeMode.Light
            ? Color.FromArgb(32, 36, 42)
            : Color.FromArgb(22, 24, 28);

        public static Color Text => CurrentMode == AppThemeMode.Light
            ? Color.FromArgb(35, 38, 42)
            : Color.FromArgb(235, 236, 238);

        public static Color SecondaryText => CurrentMode == AppThemeMode.Light
            ? Color.FromArgb(105, 110, 118)
            : Color.FromArgb(175, 178, 184);

        public static Color Border => CurrentMode == AppThemeMode.Light
            ? Color.FromArgb(225, 228, 232)
            : Color.FromArgb(65, 69, 76);

        public static Color Primary => Color.FromArgb(46, 115, 185);
        public static Color Success => Color.FromArgb(44, 140, 92);
        public static Color Warning => Color.FromArgb(190, 135, 35);
        public static Color Danger => Color.FromArgb(190, 65, 65);

        public static void Toggle()
        {
            CurrentMode = CurrentMode == AppThemeMode.Light
                ? AppThemeMode.Dark
                : AppThemeMode.Light;
        }

        public static void ApplyBase(Form form)
        {
            form.BackColor = Background;
            form.Font = new Font("Segoe UI", 10F);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.RightToLeft = RightToLeft.Yes;
            form.RightToLeftLayout = true;
        }

        public static void ApplyLabel(KryptonLabel label, bool secondary = false)
        {
            label.StateCommon.ShortText.Color1 = secondary ? SecondaryText : Text;
        }
    }
}
