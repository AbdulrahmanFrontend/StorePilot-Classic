using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Navigation;
using StorePilot.WinForms.Pages;
using StorePilot.WinForms.Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms.Forms
{
    /// <summary>
    /// الإطار الرئيسي للنظام.
    ///
    /// الفكرة المهمة:
    /// لا نفتح Form جديد لكل شاشة.
    /// نعرض UserControl داخل contentHost.
    /// هذا يجعل التنقل أسرع وأسهل في الإدارة.
    /// </summary>
    public partial class MainShellForm : KryptonForm
    {
        private NavigationService _navigation;
        private AppBrandSettingsStore _appBrandSettingsStore;

        public MainShellForm(AppBrandSettingsStore appBrandSettingsStore)
        {
            InitializeComponent();

            _appBrandSettingsStore = appBrandSettingsStore;

            _navigation = new NavigationService(contentHost);

            ConfigureNavigationButtons();
            RefreshBranding();
            ApplyTheme();

            ShowHome();
        }

        private void ShowHome()
        {
            _navigation.RegisterAndShow(
                new NavigationItem("home", "الرئيسية", () => new DashboardPage()));

            HighlightNavigation("home");
        }

        private void ConfigureNavigationButtons()
        {
            AddNavigationButton("home", "الرئيسية", () => new DashboardPage());

            AddNavigationButton("sales", "المبيعات", () => new PlaceholderPage("المبيعات"));
            AddNavigationButton("purchases", "المشتريات", () => new PlaceholderPage("المشتريات"));

            AddNavigationButton("products", "المنتجات", () => new ProductsPage());
            AddNavigationButton("customers", "العملاء", () => new CustomersPage());
            AddNavigationButton("suppliers", "الموردون", () => new SuppliersPage());

            AddNavigationButton("groups", "المجموعات", () => new GroupsPage());
            AddNavigationButton("units", "الوحدات", () => new UnitsPage());
            AddNavigationButton("payments", "طرق الدفع", () => new PaymentMethodsPage());

            AddNavigationButton("stock", "المخزون", () => new PlaceholderPage("المخزون"));
            AddNavigationButton("cash", "النقدية", () => new PlaceholderPage("النقدية"));
            AddNavigationButton("reports", "التقارير", () => new PlaceholderPage("التقارير"));
        }

        private void AddNavigationButton(string key, string text,
            Func<UserControl> pageFactory)
        {
            KryptonButton button = CreateNavButton(text);
            button.Tag = key;
            button.Click += delegate
            {
                _navigation.RegisterAndShow(
                    new NavigationItem(key, text, pageFactory));
                HighlightNavigation(key);
            };

            sidebarFlow.Controls.Add(button);
        }

        private KryptonButton CreateNavButton(string text)
        {
            var button = new KryptonButton();

            button.Width = 205;
            button.Height = 42;
            button.Margin = new Padding(8, 4, 8, 4);
            button.Dock = DockStyle.Top;
            button.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button.StateCommon.Back.Color1 = AppTheme.Sidebar;
            button.StateCommon.Back.Color2 = AppTheme.Sidebar;
            button.StateCommon.Border.DrawBorders = PaletteDrawBorders.None;
            button.StateCommon.Content.ShortText.Color1 = Color.White;
            button.StateCommon.Content.ShortText.Font =
                new Font("Segoe UI", 10.5F, FontStyle.Regular);
            button.Values.Text = text;

            return button;
        }

        private void HighlightNavigation(string key)
        {
            foreach (KryptonButton btn in sidebarFlow.Controls.OfType<KryptonButton>())
            {
                if (btn == null)
                    continue;

                bool selected = string.Equals(
                    Convert.ToString(btn.Tag),
                    key,
                    StringComparison.OrdinalIgnoreCase);

                btn.StateCommon.Back.Color1 = selected
                    ? Color.FromArgb(55, 61, 70)
                    : AppTheme.Sidebar;

                btn.StateCommon.Back.Color2 = btn.StateCommon.Back.Color1;
            }
        }

        private void RefreshBranding()
        {
            AppBrandSettings settings = _appBrandSettingsStore.Load();

            shopNameLabel.Text = string.IsNullOrWhiteSpace(settings.ShopName)
                ? "StorePilot"
                : settings.ShopName;

            userNameLabel.Text = string.IsNullOrWhiteSpace(settings.UserDisplayName)
                ? "المستخدم"
                : settings.UserDisplayName;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (ShopSettingsForm form = new ShopSettingsForm(_appBrandSettingsStore))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshBranding();
                }
            }
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            AppTheme.Toggle();
            ApplyTheme();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            _navigation.RegisterAndShow(
                new NavigationItem("home", "الرئيسية", () => new HomePage()));

            HighlightNavigation("home");
        }

        private void ApplyTheme()
        {
            BackColor = AppTheme.Background;
            sidebarFlow.BackColor = AppTheme.Sidebar;
            headerTableLayoutPanel.BackColor = AppTheme.Surface;
            contentHost.BackColor = AppTheme.Background;

            shopNameLabel.StateCommon.ShortText.Color1 = AppTheme.Text;
            userNameLabel.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;

            foreach (var btn in sidebarFlow.Controls.OfType<KryptonButton>())
            {
                if (btn == null)
                    continue;

                btn.StateCommon.Back.Color1 = AppTheme.Sidebar;
                btn.StateCommon.Back.Color2 = AppTheme.Sidebar;
            }

            foreach (var page in contentHost.Controls.OfType<DashboardPage>())
            {
                page.ApplyTheme();
            }

            HighlightNavigation(_navigation.CurrentKey ?? "home");
        }
    }
}
