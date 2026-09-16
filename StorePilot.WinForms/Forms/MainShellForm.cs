using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Navigation;
using StorePilot.WinForms.Pages;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms.Forms;

public partial class MainShellForm : Form
{
    private readonly AppBrandSettingsStore _settingsStore;
    private readonly MainShellViewModel _viewModel;

    private NavigationService? _navigationService;

    public MainShellForm(
        AppBrandSettingsStore settingsStore)
    {
        _settingsStore = settingsStore;

        _viewModel = new MainShellViewModel(
            settingsStore);

        InitializeComponent();

        InitializeNavigation();

        ApplySettingsToView();

        AppTheme.Apply(this);
    }

    private void InitializeNavigation()
    {
        _navigationService = new NavigationService(
            contentHostPanel);
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        NavigateToDashboard();
    }

    private void ApplySettingsToView()
    {
        storeNameLabel.Text = _viewModel.StoreName;

        topBarStoreNameLabel.Text = _viewModel.StoreName;

        userNameLabel.Text = _viewModel.UserName;

        welcomeUserLabel.Text =
            $"مرحباً، {_viewModel.UserName}";

        userInitialLabel.Text =
            GetUserInitial(_viewModel.UserName);

        LoadLogo();
    }

    private static string GetUserInitial(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            return "م";

        return userName.Trim()[0].ToString();
    }

    private void LoadLogo()
    {
        logoPictureBox.Image?.Dispose();
        logoPictureBox.Image = null;

        string? logoPath = _viewModel.LogoPath;

        if (string.IsNullOrWhiteSpace(logoPath) ||
            !File.Exists(logoPath))
        {
            logoPictureBox.Visible = false;
            logoMarkLabel.Visible = true;

            return;
        }

        try
        {
            using var stream = new FileStream(
                logoPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);

            using var image = Image.FromStream(stream);

            logoPictureBox.Image = new Bitmap(image);

            logoPictureBox.Visible = true;
            logoMarkLabel.Visible = false;
        }
        catch
        {
            logoPictureBox.Visible = false;
            logoMarkLabel.Visible = true;
        }
    }

    private void NavigateToDashboard()
    {
        _navigationService?.Navigate(
            PageKey.Dashboard,
            () => new DashboardPage(
                _settingsStore));
    }

    private void NavigateToSettings()
    {
        _navigationService?.Navigate(
            PageKey.Settings,
            () => new SettingsPage(
                _settingsStore,
                RefreshShell));
    }

    private void RefreshShell()
    {
        _viewModel.Reload();

        ApplySettingsToView();

        AppTheme.Apply(this);
    }

    private void dashboardButton_Click(
        object? sender,
        EventArgs e)
    {
        NavigateToDashboard();
    }

    private void settingsButton_Click(
        object? sender,
        EventArgs e)
    {
        NavigateToSettings();
    }

    private void productsButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("المنتجات");
    }

    private void customersButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("العملاء");
    }

    private void suppliersButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("الموردون");
    }

    private void salesButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("المبيعات");
    }

    private void purchasesButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("المشتريات");
    }

    private void quotationsButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("عروض الأسعار");
    }

    private void returnsButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("المرتجعات");
    }

    private void paymentsButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("المدفوعات");
    }

    private void inventoryButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("المخزون");
    }

    private void reportsButton_Click(
        object? sender,
        EventArgs e)
    {
        ShowComingSoon("التقارير");
    }

    private void ShowComingSoon(string featureName)
    {
        MessageBox.Show(
            $"سيتم إضافة شاشة {featureName} في مرحلة لاحقة.",
            "StorePilot",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        logoPictureBox.Image?.Dispose();

        _navigationService?.Clear();

        base.OnFormClosed(e);
    }
}