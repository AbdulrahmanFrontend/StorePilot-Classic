using ReaLTaiizor.Controls;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Forms;

public partial class FirstRunSetupForm : Form
{
    private readonly AppBrandSettingsStore _settingsStore;

    private string? _pendingLogoPath;

    private bool _pendingLogoDeletion;

    public FirstRunSetupForm(
        AppBrandSettingsStore settingsStore)
    {
        _settingsStore = settingsStore;

        InitializeComponent();

        UpdatePreview();

        ApplyCurrentTheme();
    }

    private void ApplyCurrentTheme()
    {
        AppTheme.Apply(this);

        previewPanel.BackColor =
            AppTheme.Background;

        logoPreview.BackColor =
            AppTheme.Background;

        saveButton.BackColor =
            AppTheme.Accent;

        saveButton.ForeColor =
            Color.White;

        cancelButton.BackColor =
            AppTheme.Surface;

        cancelButton.ForeColor =
            AppTheme.Text;
    }

    private void UpdatePreview()
    {
        previewStoreLabel.Text =
            string.IsNullOrWhiteSpace(storeNameTextBox.Text)
                ? "اسم المحل"
                : storeNameTextBox.Text.Trim();

        previewUserLabel.Text =
            string.IsNullOrWhiteSpace(userNameTextBox.Text)
                ? "اسم المستخدم"
                : userNameTextBox.Text.Trim();
    }

    private void storeNameTextBox_TextChanged(
        object sender,
        EventArgs e)
    {
        UpdatePreview();
    }

    private void userNameTextBox_TextChanged(
        object sender,
        EventArgs e)
    {
        UpdatePreview();
    }

    private void chooseLogoButton_Click(
        object sender,
        EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Image files|*.png;*.jpg;*.jpeg;*.bmp",

            Title = "اختيار شعار المحل"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        _pendingLogoPath = dialog.FileName;

        _pendingLogoDeletion = false;

        using var sourceImage =
            Image.FromFile(dialog.FileName);

        logoPreview.Image?.Dispose();

        logoPreview.Image =
            new Bitmap(sourceImage);

        logoPreview.Text = string.Empty;
    }

    private void removeLogoButton_Click(
        object sender,
        EventArgs e)
    {
        _pendingLogoPath = null;

        _pendingLogoDeletion = true;

        logoPreview.Image?.Dispose();

        logoPreview.Image = null;

        logoPreview.Text = "بدون شعار";
    }

    private void themeRadioButton_CheckedChanged(
        object sender,
        EventArgs e)
    {
        if (!lightThemeRadioButton.Checked &&
            !darkThemeRadioButton.Checked)
        {
            return;
        }

        AppTheme.Set(
            lightThemeRadioButton.Checked
                ? ThemeMode.Light
                : ThemeMode.Dark);

        ApplyCurrentTheme();
    }

    private void saveButton_Click(
        object sender,
        EventArgs e)
    {
        var storeName =
            storeNameTextBox.Text.Trim();

        var userName =
            userNameTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(storeName))
        {
            MessageBox.Show(
                this,
                "أدخل اسم المحل.",
                "بيانات ناقصة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            storeNameTextBox.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(userName))
        {
            MessageBox.Show(
                this,
                "أدخل اسم المستخدم.",
                "بيانات ناقصة",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            userNameTextBox.Focus();

            return;
        }

        var confirmation = MessageBox.Show(
            this,
            "سيتم حفظ بيانات المحل وتطبيق المظهر والشعار. هل تريد المتابعة؟",
            "تأكيد الحفظ",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmation != DialogResult.Yes)
            return;

        try
        {
            if (_pendingLogoDeletion)
            {
                _settingsStore.DeleteLogo();
            }
            else if (!string.IsNullOrWhiteSpace(_pendingLogoPath))
            {
                _settingsStore.ReplaceLogo(
                    _pendingLogoPath);
            }

            var logoPath =
                _settingsStore.GetLogoPath();

            var settings = new AppBrandSettings
            {
                StoreName = storeName,

                UserName = userName,

                Theme = lightThemeRadioButton.Checked
                    ? ThemeMode.Light
                    : ThemeMode.Dark,

                LogoFileName = logoPath is null
                    ? null
                    : Path.GetFileName(logoPath),

                IsConfigured = true
            };

            _settingsStore.Save(settings);

            AppTheme.Set(settings.Theme);

            DialogResult = DialogResult.OK;

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                ex.Message,
                "تعذر حفظ الإعدادات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void cancelButton_Click(
        object sender,
        EventArgs e)
    {
        var confirmation = MessageBox.Show(
            this,
            "لم يتم حفظ الإعدادات. هل تريد الخروج؟",
            "تأكيد الخروج",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmation == DialogResult.Yes)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //        logoPreview.Image?.Dispose();

    //    base.Dispose(disposing);
    //}
}