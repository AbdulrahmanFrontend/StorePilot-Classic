using StorePilot.Infrastructure.Storage;
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
    private readonly IPageFactory _pageFactory;
    private NavigationService? _navigationService;

    public MainShellForm(
        AppBrandSettingsStore settingsStore,
        IPageFactory pageFactory)
    {
        _settingsStore = settingsStore;
        _pageFactory = pageFactory;

        _viewModel = new MainShellViewModel(settingsStore);

        InitializeComponent();
    }

    private void InitializeNavigation()
    {
        _navigationService = new NavigationService(
            contentHostPanel,
            _pageFactory);
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        dashboardButton.Tag = ((byte)PageKey.Dashboard);
        groupsButton.Tag = ((byte)PageKey.ProductGroups);
        unitsButton.Tag = ((byte)PageKey.Units);
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

        _navigationService?.Navigate<DashboardPage>(PageKey.Dashboard);
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

        AppTheme.Set(_viewModel.Settings.Theme);

        AppTheme.Apply(this);
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
                _navigationService?.Navigate<DashboardPage>(PageKey.Dashboard);
                (_navigationService?.GetCurrentPage() as DashboardPage)?.LoadSettings();
                break;

            case PageKey.ProductGroups:
                _navigationService?.Navigate<GroupsPage>(PageKey.ProductGroups);
                (_navigationService?.GetCurrentPage() as GroupsPage)?.ApplyTheme();
                break;

            case PageKey.Units:
                _navigationService?.Navigate<UnitsPage>(PageKey.Units);
                (_navigationService?.GetCurrentPage() as UnitsPage)?.ApplyTheme();
                break;

            case PageKey.Settings:
                _navigationService?.Navigate<SettingsPage>(PageKey.Settings);
                var settingsPage = _navigationService?.GetCurrentPage() as SettingsPage;
                settingsPage?.refreshShell = RefreshShell;
                break;
        }
    }

    private void MainShellForm_Load(object sender, EventArgs e)
    {
        InitializeNavigation();
        ApplySettingsToView();
    }
}
