using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Forms
{
    public partial class ShopSetupForm : KryptonForm
    {
        private readonly AppBrandSettingsStore _settingsStore;
        private AppBrandSettings _settings;

        public ShopSetupForm(AppBrandSettingsStore settingsStore)
        {
            InitializeComponent();

            _settingsStore = settingsStore ?? throw new ArgumentNullException(nameof(settingsStore));
            _settings = _settingsStore.Load();

            AppTheme.ApplyBase(this);

            txtShopName.Text = _settings.ShopName;
            txtUserName.Text = _settings.UserDisplayName;

            RefreshLogoPreview();
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "اختيار شعار المحل";
                dialog.Filter =
                    "Images|*.png;*.jpg;*.jpeg;*.bmp|PNG|*.png|JPEG|*.jpg;*.jpeg|Bitmap|*.bmp";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _settings.LogoFileName = _settingsStore.ReplaceLogo(dialog.FileName);
                    RefreshLogoPreview();
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(
                        this,
                        "تعذر حفظ صورة الشعار.\r\n\r\n" + ex.Message,
                        "خطأ",
                        KryptonMessageBoxButtons.OK,
                        KryptonMessageBoxIcon.Error);
                }
            }
        }

        private void btnRemoveLogo_Click(object sender, EventArgs e)
        {
            _settingsStore.DeleteStoredLogo();
            _settings.LogoFileName = string.Empty;

            RefreshLogoPreview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var shopName = txtShopName.Text.Trim();
            var userName = txtUserName.Text.Trim();

            if (shopName.Length == 0)
            {
                ShowValidation("يرجى إدخال اسم المحل.", txtShopName);
                return;
            }

            if (userName.Length == 0)
            {
                ShowValidation("يرجى إدخال اسم المستخدم.", txtUserName);
                return;
            }

            _settings.ShopName = shopName;
            _settings.UserDisplayName = userName;

            _settingsStore.Save(_settings);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowValidation(string message, Control control)
        {
            KryptonMessageBox.Show(
                this,
                message,
                "بيانات غير مكتملة",
                KryptonMessageBoxButtons.OK,
                KryptonMessageBoxIcon.Warning);

            control.Focus();
        }

        private void RefreshLogoPreview()
        {
            if (picLogo.Image != null)
            {
                var old = picLogo.Image;
                picLogo.Image = null;
                old.Dispose();
            }

            var path = _settingsStore.GetLogoPath(_settings.LogoFileName);

            if (!string.IsNullOrWhiteSpace(path))
            {
                using (var source = Image.FromFile(path))
                {
                    // Clone the image so the source file is not kept locked.
                    picLogo.Image = new Bitmap(source);
                }
            }
            else
            {
                picLogo.Image = BrandingImageHelper.CreateDefaultLogo(
                    string.IsNullOrWhiteSpace(txtShopName.Text)
                        ? "StorePilot"
                        : txtShopName.Text,
                    180);
            }
        }

        private void txtShopName_TextChanged(object sender, EventArgs e)
        {
            // If no custom logo exists, changing the shop name should also update
            // the fallback logo preview immediately.
            if (string.IsNullOrWhiteSpace(_settings.LogoFileName))
                RefreshLogoPreview();
        }
    }
}
