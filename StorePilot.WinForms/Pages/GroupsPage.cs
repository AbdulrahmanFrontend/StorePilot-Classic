using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.WinForms.Controls;
using StorePilot.WinForms.Forms;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms.Pages;

public partial class GroupsPage : UserControl
{
    private readonly GroupsViewModel _viewModel;

    private bool _loading;

    public GroupsPage(
        GroupsViewModel viewModel)
    {
        InitializeComponent();

        _viewModel =
            viewModel;
    }

    private void ConfigurePage()
    {
        toolbar.Title =
            "مجموعات المنتجات";

        groupsGrid.Configure(
            "اسم المجموعة",
            "تاريخ الإنشاء");

        groupsGrid.Grid.Columns["idColumn"]!
            .DataPropertyName =
            "groupId";

        groupsGrid.Grid.Columns["nameColumn"]!
            .DataPropertyName =
            "Name";

        groupsGrid.Grid.Columns["createdAtColumn"]!
            .DataPropertyName =
            "CreatedAt";

        groupsGrid.Grid.DataSource =
            _viewModel.Items;

        ApplyTheme();
    }

    private async void GroupsPage_Load(
        object? sender,
        EventArgs e)
    {
        ConfigurePage();

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
                "إضافة مجموعة");

        if (form.ShowDialog(this) !=
            DialogResult.OK)
        {
            return;
        }

        var result =
            await _viewModel.CreateAsync(
                new CreateProductGroupDto(
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

    private async void GroupsGrid_CellDoubleClicked(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (groupsGrid.Grid.Rows[e.RowIndex]
            .DataBoundItem is not ProductGroupDto item)
        {
            return;
        }

        using var form =
            new EditNameForm(
                "تعديل المجموعة",
                item.Name);

        if (form.ShowDialog(this) !=
            DialogResult.OK)
        {
            return;
        }

        var result =
            await _viewModel.UpdateAsync(
                item.GroupId,
                new UpdateProductGroupDto(
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
                $"إجمالي المجموعات: {_viewModel.TotalCount}";
        }
        finally
        {
            _loading = false;
        }
    }

    public void ApplyTheme()
    {
        BackColor =
            AppTheme.Background;

        toolbar.ApplyTheme();
        groupsGrid.ApplyTheme();

        totalLabel.ForeColor =
            AppTheme.MutedText;
    }
}
