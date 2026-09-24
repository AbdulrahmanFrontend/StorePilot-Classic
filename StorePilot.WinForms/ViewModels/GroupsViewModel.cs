using System.ComponentModel;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Services.ProductGroupServices;

namespace StorePilot.WinForms.ViewModels;

public sealed class GroupsViewModel
{
    private readonly IProductGroupService _service;

    public BindingList<ProductGroupDto> Items { get; } = new();

    public int PageNumber { get; private set; } = 1;

    public int PageSize { get; private set; } = 10;

    public int TotalCount { get; private set; }

    public int TotalPages { get; private set; }

    public GroupsViewModel(IProductGroupService service)
    {
        _service = service;
    }

    public async Task<Result<bool>> ExistsAsync(
        int groupId,
        CancellationToken cancellationToken = default)
        => await _service.ExistsAsync(groupId, cancellationToken);

    public async Task LoadAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var result =
            await _service.GetPagesAsync(
                search,
                pageNumber,
                pageSize,
                cancellationToken);

        PageNumber = result.PageNumber;
        PageSize = result.PageSize;
        TotalCount = result.TotalCount;
        TotalPages = result.TotalPages;

        Items.Clear();

        foreach (var item in result.Items)
            Items.Add(item);
    }

    public async Task<Result<int>> CreateAsync(
        CreateProductGroupDto dto,
        CancellationToken cancellationToken = default)
        => await _service.CreateAsync(dto, cancellationToken);

    public async Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default)
        => await _service.UpdateAsync(groupId, dto, cancellationToken);
}
