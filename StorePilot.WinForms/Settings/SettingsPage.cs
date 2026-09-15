using Krypton.Toolkit;
using StorePilot.WinForms.Backup;
using StorePilot.WinForms.Theme;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.WinForms.Settings;

public sealed class SettingsPage : UserControl
{
    private readonly BackupService _backupService;
    private readonly SettingsViewModel _viewModel;

    private TextBox _storeNameTextBox = null!;
    private TextBox _storePhoneTextBox = null!;
    private TextBox _storeAddressTextBox = null!;

    private ComboBox _themeComboBox = null!;
    private CheckBox _autoBackupCheckBox = null!;
    private NumericUpDown _backupIntervalNumeric = null!;

    private Button _saveButton = null!;
    private Button _backupButton = null!;

    public SettingsPage(BackupService backupService)
    {
        _backupService = backupService;
        _viewModel = new SettingsViewModel();

        InitializeComponent();
        BuildPage();
        LoadViewModel();

        AppTheme.Apply(this);
    }

    private void InitializeComponent()
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Padding = new Padding(20);
        BackColor = AppTheme.Background;
    }

    private void BuildPage()
    {
        var mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 1,
            RowCount = 4
        };

        Controls.Add(mainLayout);

        var header = new Label
        {
            Text = "الإعدادات",
            Dock = DockStyle.Top,
            Height = 55,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold)
        };

        mainLayout.Controls.Add(header);

        mainLayout.Controls.Add(
            CreateStoreSettingsSection(),
            0,
            1);

        mainLayout.Controls.Add(
            CreateAppearanceSection(),
            0,
            2);

        mainLayout.Controls.Add(
            CreateBackupSection(),
            0,
            3);
    }

    private Control CreateStoreSettingsSection()
    {
        var group = CreateGroup("بيانات المحل");

        var layout = CreateFormLayout();

        _storeNameTextBox = new TextBox();
        _storePhoneTextBox = new TextBox();
        _storeAddressTextBox = new TextBox();

        AddFormRow(layout, "اسم المحل", _storeNameTextBox);
        AddFormRow(layout, "رقم الهاتف", _storePhoneTextBox);
        AddFormRow(layout, "العنوان", _storeAddressTextBox);

        _saveButton = new Button
        {
            Text = "حفظ الإعدادات",
            AutoSize = true,
            Height = 38,
            FlatStyle = FlatStyle.Flat
        };

        _saveButton.Click += SaveButton_Click;

        AddFormRow(layout, "", _saveButton);

        group.Controls.Add(layout);

        return group;
    }

    private Control CreateAppearanceSection()
    {
        var group = CreateGroup("المظهر");

        var layout = CreateFormLayout();

        _themeComboBox = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 220
        };

        _themeComboBox.Items.Add("الوضع الفاتح");
        _themeComboBox.Items.Add("الوضع الداكن");

        _themeComboBox.SelectedIndexChanged += ThemeComboBox_SelectedIndexChanged;

        AddFormRow(layout, "المظهر", _themeComboBox);

        group.Controls.Add(layout);

        return group;
    }

    private Control CreateBackupSection()
    {
        var group = CreateGroup("النسخ الاحتياطي");

        var layout = CreateFormLayout();

        _autoBackupCheckBox = new CheckBox
        {
            Text = "تفعيل النسخ الاحتياطي التلقائي",
            AutoSize = true
        };

        _backupIntervalNumeric = new NumericUpDown
        {
            Minimum = 1,
            Maximum = 30,
            Width = 100
        };

        _backupButton = new Button
        {
            Text = "إنشاء نسخة احتياطية الآن",
            AutoSize = true,
            Height = 38,
            FlatStyle = FlatStyle.Flat
        };

        _backupButton.Click += BackupButton_Click;

        AddFormRow(layout, "النسخ التلقائي", _autoBackupCheckBox);
        AddFormRow(layout, "الفترة بالأيام", _backupIntervalNumeric);
        AddFormRow(layout, "", _backupButton);

        group.Controls.Add(layout);

        return group;
    }

    private KryptonPanel CreateGroup(string title)
    {
        var group = new KryptonPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            Padding = new Padding(20),
            Margin = new Padding(0, 0, 0, 20)
        };

        group.StateCommon.Color1 = AppTheme.Surface;
        group.StateCommon.Color2 = AppTheme.Surface;

        var titleLabel = new Label
        {
            Text = title,
            Dock = DockStyle.Top,
            Height = 35,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
        };

        group.Controls.Add(titleLabel);

        return group;
    }

    private TableLayoutPanel CreateFormLayout()
    {
        return new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 2,
            RowCount = 0,
            Padding = new Padding(0, 10, 0, 0)
        };
    }

    private void AddFormRow(
        TableLayoutPanel layout,
        string labelText,
        Control control)
    {
        int row = layout.RowCount;

        layout.RowCount++;

        layout.RowStyles.Add(
            new RowStyle(SizeType.AutoSize));

        layout.ColumnStyles.Clear();

        layout.ColumnStyles.Add(
            new ColumnStyle(SizeType.Absolute, 140F));

        layout.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 100F));

        var label = new Label
        {
            Text = labelText,
            AutoSize = true,
            Anchor = AnchorStyles.Left,
            Margin = new Padding(0, 8, 10, 8)
        };

        control.Anchor =
            AnchorStyles.Left |
            AnchorStyles.Right;

        control.Margin =
            new Padding(0, 5, 0, 5);

        layout.Controls.Add(label, 0, row);
        layout.Controls.Add(control, 1, row);
    }

    private void LoadViewModel()
    {
        _storeNameTextBox.Text = _viewModel.StoreName;
        _storePhoneTextBox.Text = _viewModel.StorePhone;
        _storeAddressTextBox.Text = _viewModel.StoreAddress;

        _themeComboBox.SelectedIndex =
            _viewModel.Theme == ThemeMode.Light ? 0 : 1;

        _autoBackupCheckBox.Checked =
            _viewModel.EnableAutoBackup;

        _backupIntervalNumeric.Value =
            _viewModel.BackupIntervalDays;
    }

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        _viewModel.StoreName =
            _storeNameTextBox.Text.Trim();

        _viewModel.StorePhone =
            _storePhoneTextBox.Text.Trim();

        _viewModel.StoreAddress =
            _storeAddressTextBox.Text.Trim();

        _viewModel.EnableAutoBackup =
            _autoBackupCheckBox.Checked;

        _viewModel.BackupIntervalDays =
            (int)_backupIntervalNumeric.Value;

        MessageBox.Show(
            "تم حفظ الإعدادات التجريبية بنجاح.",
            "StorePilot",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void ThemeComboBox_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        var mode =
            _themeComboBox.SelectedIndex == 1
                ? ThemeMode.Dark
                : ThemeMode.Light;

        _viewModel.Theme = mode;

        AppTheme.Set(mode);

        AppTheme.Apply(FindForm() as Control ?? this);

        Invalidate(true);
    }

    private async void BackupButton_Click(
        object? sender,
        EventArgs e)
    {
        try
        {
            _backupButton.Enabled = false;

            string path = await 
                _backupService
                .CreateBackupAsync(
                $"Backup_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.db");

            MessageBox.Show(
                $"تم إنشاء النسخة الاحتياطية بنجاح:\n{path}",
                "StorePilot",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "فشل النسخ الاحتياطي",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            _backupButton.Enabled = true;
        }
    }
}