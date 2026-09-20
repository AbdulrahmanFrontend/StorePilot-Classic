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

        dashboardButton.Tag = ((byte)PageKey.Dashboard);
        customersButton.Tag = ((byte)PageKey.Customers);
        suppliersButton.Tag = ((byte)PageKey.Suppliers);
        productsButton.Tag = ((byte)PageKey.Products);
        quotationsButton.Tag = ((byte)PageKey.Quotations);
        returnsButton.Tag = ((byte)PageKey.SalesReturns);
        salesButton.Tag = ((byte)PageKey.Sales);
        purchasesButton.Tag = ((byte)PageKey.Purchases);
        reportsButton.Tag = ((byte)PageKey.Reports);
        settingsButton.Tag = ((byte)PageKey.Settings);
        paymentsButton.Tag = ((byte)PageKey.CustomerPayments);

        _navigationService?.Navigate(
            PageKey.Dashboard,
            () => new DashboardPage(_settingsStore));
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

    private void RefreshShell()
    {
        _viewModel.Reload();

        ApplySettingsToView();

        AppTheme.Apply(this);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        logoPictureBox.Image?.Dispose();

        _navigationService?.Clear();

        base.OnFormClosed(e);
    }

    private void NavigationButton_Click(object sender, EventArgs e)
    {
        if (sender is not Button button)
            return;

        var key = int.TryParse(button.Tag?.ToString(), out int parsedKey) ? parsedKey : 14;

            switch ((PageKey)key)
            {
                case PageKey.Dashboard:
                    _navigationService?.Navigate(
                        PageKey.Dashboard,
                        () => new DashboardPage(_settingsStore)); 
                    break;

                case PageKey.Settings:
                    _navigationService?.Navigate(
                        PageKey.Settings,
                        () => new SettingsPage(
                            _settingsStore,
                            RefreshShell));
                    break;
            }
    }
}