using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StorePilot.WinForms.Backup;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms.Pages
{
    public partial class SettingsPage : UserControl
    {
        private readonly AppBrandSettingsStore _settingsStore;
        private readonly BackupService _backupService;
        private readonly Action _refreshShell;

        private readonly SettingsViewModel _viewModel;

        public SettingsPage(
            AppBrandSettingsStore settingsStore,
            Action refreshShell)
        {
            _settingsStore = settingsStore ??
                             throw new ArgumentNullException(nameof(settingsStore));

            _refreshShell = refreshShell;

            _backupService = new BackupService(
                Path.Combine(_settingsStore.RootPath, "Data", "StorePilot.db"),
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "StorePilot",
                    "Backups"));

            _viewModel = new SettingsViewModel();

            InitializeComponent();

            RightToLeft = RightToLeft.Yes;
            Load += SettingsPage_Load;
        }

        private void SettingsPage_Load(object? sender, EventArgs e)
        {
            LoadSettings();
            ApplyTheme();
        }

        private void LoadSettings()
        {
            var settings = _settingsStore.Load();

            _viewModel.StoreName = settings.StoreName;
            _viewModel.UserName = settings.UserName;
            _viewModel.Theme = settings.Theme;
            _viewModel.LogoFileName = settings.LogoFileName;
            _viewModel.LastBackupDirectory =
                settings.LastBackupDirectory;

            _viewModel.LastBackupFileName =
                settings.LastBackupFileName;

            storeNameTextBox.Text = _viewModel.StoreName ?? string.Empty;
            userNameTextBox.Text = _viewModel.UserName ?? string.Empty;

            themeComboBox.SelectedIndex = _viewModel.Theme == ThemeMode.Dark ? 1 : 0;

            LoadLogo();

            backupDirectoryLabel.Text =
                string.IsNullOrWhiteSpace(_viewModel.LastBackupDirectory)
                    ? "سيتم استخدام مجلد النسخ الاحتياطية الافتراضي."
                    : _viewModel.LastBackupDirectory;
        }

        private void LoadLogo()
        {
            logoPictureBox.Image?.Dispose();
            logoPictureBox.Image = null;

            var logoPath = _settingsStore.GetLogoPath();

            if (!File.Exists(logoPath))
            {
                logoFileNameLabel.Text = "لم يتم اختيار شعار.";
                return;
            }

            try
            {
                using (var stream = new FileStream(
                    logoPath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
                {
                    logoPictureBox.Image = new Bitmap(stream);
                }

                logoFileNameLabel.Text =
                    Path.GetFileName(logoPath);
            }
            catch
            {
                logoPictureBox.Image = null;
                logoFileNameLabel.Text = "تعذر تحميل الشعار.";
            }
        }

        private void ChooseLogoButton_Click(
            object sender,
            EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "اختيار شعار المحل";
                dialog.Filter =
                    "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif";

                dialog.Multiselect = false;

                if (dialog.ShowDialog(FindForm()) !=
                    DialogResult.OK)
                {
                    return;
                }

                try
                {
                    _settingsStore.ReplaceLogo(dialog.FileName);

                    LoadLogo();

                    MessageBox.Show(
                        FindForm(),
                        "تم حفظ شعار المحل بنجاح, سيتم إغلاق النظام لتطبيق التغييرات.",
                        "الإعدادات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.ParentForm?.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        FindForm(),
                        "تعذر حفظ الشعار:\n" + ex.Message,
                        "خطأ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveSettingsButton_Click(
            object sender,
            EventArgs e)
        {
            var storeName = storeNameTextBox.Text.Trim();
            var userName = userNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(storeName))
            {
                MessageBox.Show(
                    FindForm(),
                    "يرجى إدخال اسم المحل.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                storeNameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show(
                    FindForm(),
                    "يرجى إدخال اسم المستخدم.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                userNameTextBox.Focus();
                return;
            }

            var theme =
                themeComboBox.SelectedIndex == 1
                    ? ThemeMode.Dark
                    : ThemeMode.Light;

            var settings = _settingsStore.Load();

            settings.StoreName = storeName;
            settings.UserName = userName;
            settings.Theme = theme;
            settings.IsConfigured = true;

            _settingsStore.Save(settings);

            _viewModel.StoreName = settings.StoreName;
            _viewModel.UserName = settings.UserName;
            _viewModel.Theme = settings.Theme;

            ApplyTheme();

            _refreshShell?.Invoke();

            MessageBox.Show(
                FindForm(),
                "تم حفظ الإعدادات بنجاح, سيتم إغلاق النظام لتطبيق التغييرات.",
                "الإعدادات",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.ParentForm?.Close();
        }

        private async void BackupButton_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                var settings = _settingsStore.Load();

                var defaultDirectory =
                    string.IsNullOrWhiteSpace(settings.LastBackupDirectory)
                        ? _settingsStore.GetDefaultBackupDirectory()
                        : settings.LastBackupDirectory;

                Directory.CreateDirectory(defaultDirectory);

                var defaultFileName =
                    string.IsNullOrWhiteSpace(settings.LastBackupFileName)
                        ? "StorePilot-Backup.db"
                        : settings.LastBackupFileName;

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Title = "اختيار مكان النسخة الاحتياطية";
                    dialog.Filter =
                        "SQLite Database|*.db|All Files|*.*";

                    dialog.DefaultExt = "db";
                    dialog.AddExtension = true;

                    dialog.InitialDirectory = defaultDirectory;
                    dialog.FileName = defaultFileName;
                    dialog.OverwritePrompt = true;

                    if (dialog.ShowDialog(FindForm()) !=
                        DialogResult.OK)
                    {
                        return;
                    }

                    var destinationPath = dialog.FileName;

                    await _backupService.CreateBackupAsync(destinationPath);

                    settings.LastBackupDirectory =
                        Path.GetDirectoryName(destinationPath);

                    settings.LastBackupFileName =
                        Path.GetFileName(destinationPath);

                    _settingsStore.Save(settings);

                    backupDirectoryLabel.Text =
                        settings.LastBackupDirectory;

                    MessageBox.Show(
                        FindForm(),
                        "تم إنشاء النسخة الاحتياطية بنجاح.",
                        "النسخ الاحتياطي",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    FindForm(),
                    "تعذر إنشاء النسخة الاحتياطية:\n" + ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyTheme()
        {
            AppTheme.Apply(this);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            logoPictureBox.Image?.Dispose();
            logoPictureBox.Image = null;

            base.OnHandleDestroyed(e);
        }

        private void removeLogoButton_Click(object sender, EventArgs e)
        {
            _settingsStore.DeleteLogo();

            LoadLogo();

            MessageBox.Show(
                        FindForm(),
                        "تمت إزالة شعار المحل بنجاح, سيتم إغلاق النظام لتطبيق التغييرات.",
                        "الإعدادات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

            this.ParentForm?.Close();
        }
    }
}