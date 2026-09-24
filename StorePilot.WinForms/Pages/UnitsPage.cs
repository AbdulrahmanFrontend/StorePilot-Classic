using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.WinForms.Controls;
using StorePilot.WinForms.Forms;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms.Pages;

public partial class UnitsPage : UserControl
{
    private readonly UnitsViewModel _viewModel;

    private bool _loading;

    public UnitsPage(
        UnitsViewModel viewModel)
    {
        InitializeComponent();

        _viewModel =
            viewModel;

        ConfigurePage();
    }

    private void ConfigurePage()
    {
        toolbar.Title =
            "الوحدات";

        unitsGrid.Configure(
            "رقم الوحدة",
            "اسم الوحدة");

        unitsGrid.Grid.Columns["idColumn"]!
            .DataPropertyName =
            "UnitId";

        unitsGrid.Grid.Columns["nameColumn"]!
            .DataPropertyName =
            "Name";

        unitsGrid.Grid.DataSource =
            _viewModel.Items;

        ApplyTheme();
    }

    private async void UnitsPage_Load(
        object? sender,
        EventArgs e)
    {
        if (DesignMode)
            return;

        await LoadDataAsync();
    }

    private async void Toolbar_SearchRequested(
        object? sender,
        EventArgs e)
    {
        await LoadDataAsync(
            toolbar.SearchText,
            1,
            pagination.PageSize);
    }

    private async void Pagination_PageChanged(
        object? sender,
        EventArgs e)
    {
        await LoadDataAsync(
            toolbar.SearchText,
            pagination.CurrentPage,
            pagination.PageSize);
    }

    private async void Pagination_PageSizeChanged(
        object? sender,
        EventArgs e)
    {
        await LoadDataAsync(
            toolbar.SearchText,
            1,
            pagination.PageSize);
    }

    private async void Toolbar_AddClicked(
        object? sender,
        EventArgs e)
    {
        using var form =
            new EditNameForm(
                "إضافة وحدة");

        if (form.ShowDialog(this) !=
            DialogResult.OK)
        {
            return;
        }

        var result =
            await _viewModel.CreateAsync(
                new CreateUnitDto(
                    form.NameValue));

        if (!result.IsSuccess)
        {
            MessageBox.Show(
                result.ErrorMessage,
                "تعذر الحفظ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        await LoadDataAsync(
            toolbar.SearchText,
            pagination.CurrentPage,
            pagination.PageSize);
    }

    private async void UnitsGrid_CellDoubleClicked(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (unitsGrid.Grid.Rows[e.RowIndex]
            .DataBoundItem is not UnitDto item)
        {
            return;
        }

        using var form =
            new EditNameForm(
                "تعديل الوحدة",
                item.Name);

        if (form.ShowDialog(this) !=
            DialogResult.OK)
        {
            return;
        }

        var result =
            await _viewModel.UpdateAsync(
                item.UnitId,
                new UpdateUnitDto(
                    form.NameValue));

        if (!result.IsSuccess)
        {
            MessageBox.Show(
                result.ErrorMessage,
                "تعذر الحفظ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        await LoadDataAsync(
            toolbar.SearchText,
            pagination.CurrentPage,
            pagination.PageSize);
    }

    private async Task LoadDataAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10)
    {
        if (_loading)
            return;

        _loading = true;

        try
        {
            await _viewModel.LoadAsync(
                search,
                pageNumber,
                pageSize);

            pagination.SetPageState(
                _viewModel.PageNumber,
                _viewModel.TotalPages,
                _viewModel.PageSize);

            totalLabel.Text =
                $"إجمالي الوحدات: {_viewModel.TotalCount}";
        }
        finally
        {
            _loading = false;
        }
    }

    private void ApplyTheme()
    {
        BackColor =
            AppTheme.Background;

        toolbar.ApplyTheme();
        unitsGrid.ApplyTheme();

        totalLabel.ForeColor =
            AppTheme.MutedText;
    }
}
