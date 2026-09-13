using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Pages;

public partial class SettingsPage : UserControl 
{
    readonly AppBrandSettingsStore store;
    string? logo;

    public SettingsPage(AppBrandSettingsStore store)
    {
        InitializeComponent();
        this.store = store;
        LoadSettings();
    }

    void LoadSettings()
    {
        var s = store.Load();
        shop.Text = s.ShopName;
        user.Text = s.UserDisplayName;
        theme.SelectedIndex = s.Theme == ThemeMode.Dark ? 1 : 0;
        logoInfo.Text =
            string.IsNullOrWhiteSpace(s.LogoPath) ?
            "الشعار الافتراضي"
            : Path.GetFileName(s.LogoPath);
    }

    void choose_Click(object? s,EventArgs e)
    {
        using var d = new OpenFileDialog
        {
            Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp"
        };

        if (d.ShowDialog(FindForm()) == DialogResult.OK)
        {
            logo = d.FileName;
            logoInfo.Text = Path.GetFileName(logo);
        }
    }

    void delete_Click(object? s,EventArgs e)
    {
        store.DeleteLogo();
        logo = null;
        logoInfo.Text = "الشعار الافتراضي";
    }

    void save_Click(object? s,EventArgs e)
    {
        var x = store.Load();
        x.ShopName = shop.Text.Trim();
        x.UserDisplayName = user.Text.Trim();
        x.Theme = theme.SelectedIndex == 1 ? ThemeMode.Dark : ThemeMode.Light;
        if (logo != null)
            x.LogoPath = store.CopyLogo(logo) ?? "";
        store.Save(x);
        AppTheme.Set(x.Theme);
        KryptonMessageBox.Show(
            "تم حفظ الإعدادات.",
            "StorePilot",
            KryptonMessageBoxButtons.OK,
            KryptonMessageBoxIcon.Information);
    }
}
