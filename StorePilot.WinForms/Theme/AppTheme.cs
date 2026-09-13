using Krypton.Toolkit;
using System.Drawing;

namespace StorePilot.WinForms.Theme
{
    public static class AppTheme
    {
        public static ThemeMode Current { get; private set; } = ThemeMode.Light;
        public static Color Background => Current == ThemeMode.Light ? Color.FromArgb(246, 247, 249) : Color.FromArgb(25, 28, 32);
        public static Color Surface => Current == ThemeMode.Light ? Color.White : Color.FromArgb(35, 39, 44);
        public static Color Sidebar => Current == ThemeMode.Light ? Color.FromArgb(29, 33, 39) : Color.FromArgb(20, 23, 27);
        public static Color Text => Current == ThemeMode.Light ? Color.FromArgb(31, 35, 40) : Color.FromArgb(238, 240, 242);
        public static Color SecondaryText => Current == ThemeMode.Light ? Color.FromArgb(103, 109, 118) : Color.FromArgb(174, 179, 187);
        public static Color Border => Current == ThemeMode.Light ? Color.FromArgb(220, 223, 228) : Color.FromArgb(61, 66, 73);
        public static Color Primary => Color.FromArgb(37, 99, 235);
        public static void Set(ThemeMode mode) => Current = mode;
        public static void Apply(Form form) { form.BackColor = Background; form.ForeColor = Text; form.Font = new Font("Segoe UI", 10F); form.RightToLeft = RightToLeft.Yes; form.RightToLeftLayout = true; }
    }
}
