using StorePilot.WinForms.Controls;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Pages;

public partial class ProductsPage : UserControl
{
    readonly DemoDataStore data = DemoDataStore.Instance;

    public ProductsPage()
    {
        InitializeComponent();
    }

    void RefreshGrid()
    {
        var q = data.Products.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search.Text))
        {
            var t = search.Text.Trim();
            q = q.Where(x => x.Name.Contains(
                t,
                StringComparison.OrdinalIgnoreCase)
            || x.Code.Contains(t, StringComparison.OrdinalIgnoreCase));
        }

        var all = q.ToList();
        grid.DataSource = all
            .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Select(x => new
            {
                الكود = x.Code,
                الصنف = x.Name,
                المجموعة = x.Group,
                الوحدة = x.Unit,
                الكمية = x.Quantity,
                الحد_الأدنى = x.MinQuantity,
                سعر_البيع = x.SalePrice.ToString("N2"),
                الحالة = x.Active ? "نشط" : "غير نشط"
            })
            .ToList();
    }

    private void ProductsPage_Load(object sender, EventArgs e)
    {
        pagination.TotalItems = data.Products.ToList().Count;
        RefreshGrid();
        pagination.PageChanged += (_, _) => RefreshGrid();
        search.TextChanged += (_, _) =>
        {
            RefreshGrid();
            pagination.Reset();
        };
    }
}
