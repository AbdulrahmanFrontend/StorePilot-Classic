using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Navigation;
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
                new NavigationItem(
                    "home",
                    "الرئيسية",
                    () => new HomePage()));

            HighlightNavigation("home");
        }

        private void ConfigureNavigationButtons()
        {
            // في الخطوات القادمة سنضيف Products, Customers, Sales...
            // إلى هذه القائمة دون تغيير بنية الـ Shell.
            AddNavigationButton("home", "الرئيسية", () =>
                new HomePage());

            AddPlaceholderButton("products", "المنتجات");
            AddPlaceholderButton("customers", "العملاء");
            AddPlaceholderButton("suppliers", "الموردون");
            AddPlaceholderButton("sales", "المبيعات");
            AddPlaceholderButton("purchases", "المشتريات");
            AddPlaceholderButton("quotations", "عروض الأسعار");
            AddPlaceholderButton("returns", "المرتجعات");
            AddPlaceholderButton("payments", "المدفوعات والديون");
            AddPlaceholderButton("inventory", "حركات المخزون");
            AddPlaceholderButton("reports", "التقارير");
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

        private void AddPlaceholderButton(string key, string text)
        {
            KryptonButton button = CreateNavButton(text);
            button.Tag = key;
            button.Click += delegate
            {
                ShowPlaceholder(text);
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
            foreach (Control control in sidebarFlow.Controls)
            {
                KryptonButton button = control as KryptonButton;
                if (button == null)
                    continue;

                bool selected = string.Equals(
                    Convert.ToString(button.Tag),
                    key,
                    StringComparison.OrdinalIgnoreCase);

                button.StateCommon.Back.Color1 = selected
                    ? Color.FromArgb(55, 61, 70)
                    : AppTheme.Sidebar;

                button.StateCommon.Back.Color2 = button.StateCommon.Back.Color1;
            }
        }

        private void ShowPlaceholder(string title)
        {
            //contentHost.Controls.Clear();

            KryptonPanel panel = new KryptonPanel();
            panel.Dock = DockStyle.Fill;
            panel.StateCommon.Color1 = AppTheme.Surface;

            KryptonLabel label = new KryptonLabel();
            label.AutoSize = true;
            label.Location = new Point(48, 48);
            label.StateCommon.ShortText.Font =
                new Font("Segoe UI", 20F, FontStyle.Bold);
            label.StateCommon.ShortText.Color1 = AppTheme.Text;
            label.Values.Text = title;

            KryptonLabel note = new KryptonLabel();
            note.AutoSize = true;
            note.Location = new Point(52, 95);
            note.StateCommon.ShortText.Font =
                new Font("Segoe UI", 10.5F);
            note.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;
            note.Values.Text =
                "هذه الوحدة موجودة في الـ Navigation فقط حالياً، " +
                "وسيتم تنفيذها في خطوات لاحقة.";

            panel.Controls.Add(note);
            panel.Controls.Add(label);
            contentHost.Controls.Add(panel);
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
            sidebarPanel.StateCommon.Color1 = AppTheme.Sidebar;
            headerPanel.StateCommon.Color1 = AppTheme.Surface;
            contentHost.BackColor = AppTheme.Background;

            shopNameLabel.StateCommon.ShortText.Color1 = AppTheme.Text;
            userNameLabel.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;

            foreach (Control control in sidebarFlow.Controls)
            {
                KryptonButton button = control as KryptonButton;
                if (button == null)
                    continue;

                button.StateCommon.Back.Color1 = AppTheme.Sidebar;
                button.StateCommon.Back.Color2 = AppTheme.Sidebar;
            }

            HighlightNavigation(_navigation.CurrentKey ?? "home");
        }
    }
}
