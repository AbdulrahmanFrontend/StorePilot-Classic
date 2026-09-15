using Krypton.Toolkit;
using StorePilot.WinForms.Backup;
using StorePilot.WinForms.Dashboard;
using StorePilot.WinForms.Navigation;
using StorePilot.WinForms.Settings;
using StorePilot.WinForms.Theme;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StorePilot.WinForms;

public partial class MainShellForm : Form
{
    private NavigationService _navigationService = null!;
    private BackupService _backupService = null!;

    private Button? _activeNavigationButton;

    private readonly string _databasePath =
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "StorePilot",
            "StorePilot.db");

    public MainShellForm()
    {
        InitializeComponent();

        InitializeServices();
        InitializeShell();
        ConfigureNavigation();
        ApplyCurrentTheme();
    }

    private void InitializeServices()
    {
        _backupService =
            new BackupService(_databasePath, string.Empty);

        _navigationService =
            new NavigationService(contentHost);
    }

    private void InitializeShell()
    {
        Text = "StorePilot";

        StartPosition = FormStartPosition.CenterScreen;

        MinimumSize = new Size(1000, 650);

        WindowState = FormWindowState.Maximized;

        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;

        AppTheme.Apply(this);
    }

    private void ConfigureNavigation()
    {
        btnDashboard.Click += (_, _) =>
        {
            NavigateTo(
                "dashboard",
                btnDashboard,
                () => new DashboardPage());
        };

        btnProducts.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "products",
                btnProducts,
                "الأصناف");
        };

        btnCustomers.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "customers",
                btnCustomers,
                "العملاء");
        };

        btnSuppliers.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "suppliers",
                btnSuppliers,
                "الموردون");
        };

        btnSales.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "sales",
                btnSales,
                "المبيعات");
        };

        btnPurchases.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "purchases",
                btnPurchases,
                "المشتريات");
        };

        btnQuotations.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "quotations",
                btnQuotations,
                "فواتير التسعير");
        };

        btnReturns.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "returns",
                btnReturns,
                "المرتجعات");
        };

        btnPayments.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "payments",
                btnPayments,
                "الدفعات");
        };

        btnInventory.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "inventory",
                btnInventory,
                "حركات المخزون");
        };

        btnReports.Click += (_, _) =>
        {
            NavigateToPlaceholder(
                "reports",
                btnReports,
                "التقارير");
        };

        btnSettings.Click += (_, _) =>
        {
            NavigateTo(
                "settings",
                btnSettings,
                () => new SettingsPage(_backupService));
        };

        btnBackup.Click += BtnBackup_Click;

        btnTheme.Click += BtnTheme_Click;

        btnExit.Click += (_, _) => Close();

        Shown += (_, _) =>
        {
            NavigateTo(
                "dashboard",
                btnDashboard,
                () => new DashboardPage());
        };
    }

    private void NavigateTo<TPage>(
        string key,
        Button button,
        Func<TPage> factory)
        where TPage : UserControl
    {
        _navigationService.Navigate(key, factory);

        SetActiveNavigationButton(button);
    }

    private void NavigateToPlaceholder(
        string key,
        Button button,
        string title)
    {
        NavigateTo(
            key,
            button,
            () => new PlaceholderPage(title));
    }

    private void SetActiveNavigationButton(Button button)
    {
        if (_activeNavigationButton != null)
        {
            _activeNavigationButton.BackColor =
                AppTheme.Surface;

            _activeNavigationButton.ForeColor =
                AppTheme.Text;
        }

        _activeNavigationButton = button;

        button.BackColor = AppTheme.Accent;
        button.ForeColor = Color.White;
    }

    private async void BtnBackup_Click(
        object? sender,
        EventArgs e)
    {
        try
        {
            btnBackup.Enabled = false;

            string path =
                await _backupService.CreateBackupAsync($"Backup_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}");

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
            btnBackup.Enabled = true;
        }
    }

    private void BtnTheme_Click(
        object? sender,
        EventArgs e)
    {
        var newTheme =
            AppTheme.Current == ThemeMode.Light
                ? ThemeMode.Dark
                : ThemeMode.Light;

        AppTheme.Set(newTheme);

        ApplyCurrentTheme();

        AppTheme.Apply(this);
    }

    private void ApplyCurrentTheme()
    {
        AppTheme.Apply(this);

        if (_activeNavigationButton != null)
        {
            _activeNavigationButton.BackColor =
                AppTheme.Accent;

            _activeNavigationButton.ForeColor =
                Color.White;
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _navigationService.Clear();

        base.OnFormClosed(e);
    }
}