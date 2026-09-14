using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Navigation;
using StorePilot.WinForms.Pages;
using StorePilot.WinForms.Theme;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms.Forms;

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
    readonly AppBrandSettingsStore store;
    readonly NavigationService nav;
    readonly Dictionary<int, KryptonButton> buttons = new();

    public MainShellForm(AppBrandSettingsStore store)
    {
        InitializeComponent();
        this.store = store;
        nav = new NavigationService(contentHost);
        AppTheme.Apply(this);
        ApplyTheme();
        BuildNavigation();
        RefreshBranding();
        Shown += (_, _) => Home();
    }

    void BuildNavigation()
    {
        Add(0, "الرئيسية", () => new DashboardPage());
        Add(1, "الأصناف", () => new ProductsPage());
        Add(2, "العملاء", () => new CustomersPage());
        Add(3, "الموردون", () => new SuppliersPage());
        Add(4, "المبيعات", () =>
        new DemoPage("المبيعات", "فواتير البيع، البحث، الفلاتر، تفاصيل الفاتورة."));
        Add(5, "المشتريات", () =>
        new DemoPage("المشتريات", "فواتير الشراء والمدفوعات المرتبطة بها."));
        Add(6, "عروض الأسعار", () =>
        new DemoPage("عروض الأسعار", "عروض الأسعار قبل تحويلها إلى عملية بيع."));
        Add(7, "المرتجعات", () =>
        new DemoPage("المرتجعات", "مرتجعات البيع والشراء."));
        Add(8, "المدفوعات", () =>
        new DemoPage("المدفوعات", "دفعات العملاء والموردين."));
        Add(9, "المخزون", () =>
        new DemoPage("المخزون", "الأرصدة وحركات المخزون والتنبيهات."));
        Add(10, "النقدية", () =>
        new DemoPage("النقدية", "المعاملات النقدية والرصيد."));
        Add(11, "التقارير", () =>
        new DemoPage("التقارير", "التقارير والملخصات التشغيلية."));
    }

    void Add(int key, string text, Func<UserControl> factory)
    {
        var b = new KryptonButton
        {
            Text = text,
            Width = 190,
            Height = 42,
            Tag = key,
            Cursor = Cursors.Hand
        };

        b.StateCommon.Back.Color1 = AppTheme.Sidebar;

        b.Click += (_, _) =>
        {
            nav.Show(new NavigationItem(text, factory));
            Highlight(1);
        };

        sidebarFlow.Controls.Add(b);
        buttons[key] = b;
    }

    void Home()
    {
        nav.Show(new NavigationItem("الرئيسية", () => new DashboardPage()));
        Highlight(0);
    }

    void Highlight(int key)
    {
        foreach (var x in buttons)
            x.Value.StateCommon.Back.Color1 =
                x.Key == key ?
                AppTheme.Primary
                : AppTheme.Sidebar;
    }

    void RefreshBranding()
    {
        var s = store.Load();

        shopLabel.Text =
            string.IsNullOrWhiteSpace(s.ShopName) ?
            "StorePilot" :
            s.ShopName;

        userLabel.Text =
            string.IsNullOrWhiteSpace(s.UserDisplayName) ?
            "المستخدم" :
            s.UserDisplayName;

        AppTheme.Set(s.Theme);
        AppTheme.Apply(this);
        ApplyTheme();
    }

    void settings_Click(object? s, EventArgs e)
    {
        nav.Show(new NavigationItem("الإعدادات", () => new SettingsPage(store)));
    }

    void ApplyTheme()
    {
        BackColor = AppTheme.Background;
        sidebar.StateCommon.Color1 = AppTheme.Sidebar;
        header.StateCommon.Color1 = AppTheme.Surface;
        content.StateCommon.Color1 = AppTheme.Background;
        shopLabel.StateCommon.ShortText.Color1 = AppTheme.Text;
        userLabel.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;
        foreach (var b in buttons)
            b.Value.StateCommon.Back.Color1 = AppTheme.Sidebar;

        sidebar.StateCommon.Color1 = AppTheme.Sidebar;
        header.StateCommon.Color1 = AppTheme.Surface;
        content.StateCommon.Color1 = AppTheme.Background;
    }

    private void backup_Click(object sender, EventArgs e)
    {

    }
}
