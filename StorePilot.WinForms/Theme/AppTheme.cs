using System.Drawing;

namespace StorePilot.WinForms.Theme;

public static class AppTheme
{
    public static ThemeMode Current { get; private set; } = ThemeMode.Light;

    public static Color Background =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(20, 24, 32)
            : Color.FromArgb(247, 249, 252);

    public static Color Surface =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(30, 36, 46)
            : Color.White;

    public static Color Text =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(239, 242, 247)
            : Color.FromArgb(31, 41, 55);

    public static Color MutedText =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(160, 170, 185)
            : Color.FromArgb(107, 114, 128);

    public static Color Border =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(55, 65, 81)
            : Color.FromArgb(229, 231, 235);

    public static Color Accent =>
        Color.FromArgb(42, 112, 222);

    public static void Set(ThemeMode theme)
    {
        Current = theme;
    }

    public static void Apply(Control root)
    {
        root.BackColor = Background;
        root.ForeColor = Text;

        foreach (Control child in root.Controls)
        {
            if (child is Panel ||
                child is GroupBox ||
                child is TableLayoutPanel)
            {
                child.BackColor = Surface;
            }

            if (child is Label label)
            {
                label.ForeColor = Text;
            }

            if (child is TextBox textBox)
            {
                textBox.BackColor = Surface;
                textBox.ForeColor = Text;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            if (child is ComboBox comboBox)
            {
                comboBox.BackColor = Surface;
                comboBox.ForeColor = Text;
            }

            if (child is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Border;
            }

            if (child.HasChildren)
                Apply(child);
        }
    }
}
