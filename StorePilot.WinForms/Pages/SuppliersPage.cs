using StorePilot.WinForms.Controls;
using StorePilot.WinForms.Foundation;

namespace StorePilot.WinForms.Pages;

public partial class SuppliersPage : UserControl
{
    readonly DemoDataStore data = DemoDataStore.Instance;
    public SuppliersPage()
    {
        InitializeComponent();
        RefreshGrid();
        pagination.PageChanged += (_, _) => RefreshGrid();
        search.TextChanged += (_, _) =>
        {
            pagination.Reset();
            RefreshGrid();
        };
    }

    void RefreshGrid()
    {
        var q = data.Suppliers.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search.Text))
        {
            var t = search.Text.Trim();
            q = q.Where(x => x.Name
            .Contains(t, StringComparison.OrdinalIgnoreCase) || x.Phone.Contains(t));
        }

        var all = q.ToList();
        pagination.TotalItems = all.Count;
        grid.DataSource = all
            .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Select(x => new
            {
                الاسم = x.Name,
                الهاتف = x.Phone,
                العنوان = x.Address,
                الإجمالي = x.Total.ToString("N2"),
                المدفوع = x.Paid.ToString("N2"),
                الرصيد = x.Balance.ToString("N2")
            })
            .ToList();
    }
}
