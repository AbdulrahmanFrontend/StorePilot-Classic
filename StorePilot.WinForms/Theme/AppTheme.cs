using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms.Theme;

public static class AppTheme
{
    public static ThemeMode Current { get; private set; }
        = ThemeMode.Light;

    public static Color Background =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(20, 24, 32)
            : Color.FromArgb(247, 249, 252);

    public static Color Surface =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(30, 36, 46)
            : Color.White;

    public static Color SurfaceSecondary =>
        Current == ThemeMode.Dark
            ? Color.FromArgb(37, 44, 56)
            : Color.FromArgb(241, 245, 249);

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

    public static Color AccentHover =>
        Color.FromArgb(76, 151, 255);

    public static Color Success =>
        Color.FromArgb(22, 163, 74);

    public static Color Warning =>
        Color.FromArgb(217, 119, 6);

    public static Color Danger =>
        Color.FromArgb(220, 38, 38);

    public static void Set(ThemeMode theme)
    {
        Current = theme;
    }

    public static void Apply(Control root)
    {
        if (root == null)
            return;

        ApplyControl(root);
    }

    private static void ApplyControl(Control control)
    {
        control.BackColor = Background;
        control.ForeColor = Text;

        foreach (Control child in control.Controls)
        {
            ApplyChild(child);
        }
    }

    private static void ApplyChild(Control control)
    {
        if (control is TableLayoutPanel)
        {
            control.BackColor = Background;
            control.ForeColor = Text;
        }
        else if (control is GroupBox)
        {
            control.BackColor = Surface;
            control.ForeColor = Text;
        }
        else if (control is Panel)
        {
            control.BackColor = Surface;
            control.ForeColor = Text;
        }
        else if (control is Label label)
        {
            label.ForeColor = Text;
        }
        else if (control is TextBox textBox)
        {
            textBox.BackColor = Surface;
            textBox.ForeColor = Text;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }
        else if (control is RichTextBox richTextBox)
        {
            richTextBox.BackColor = Surface;
            richTextBox.ForeColor = Text;
        }
        else if (control is ComboBox comboBox)
        {
            comboBox.BackColor = Surface;
            comboBox.ForeColor = Text;
        }
        else if (control is CheckBox checkBox)
        {
            checkBox.ForeColor = Text;
        }
        else if (control is RadioButton radioButton)
        {
            radioButton.ForeColor = Text;
        }
        else if (control is Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Border;
            button.BackColor = SurfaceSecondary;
            button.ForeColor = Text;
        }

        if (control.HasChildren)
        {
            foreach (Control child in control.Controls)
            {
                ApplyChild(child);
            }
        }
    }
}
