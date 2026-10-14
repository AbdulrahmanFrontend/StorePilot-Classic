using System.ComponentModel;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Interfaces;

namespace StorePilot.WinForms.ViewModels;

public sealed class GroupsViewModel
{
    private readonly IProductGroupService _service;

    public BindingList<ProductGroupDto> Items { get; } = new();

    public int PageNumber { get; private set; } = 1;

    public int PageSize { get; private set; } = 50;

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
        var result = await _service.GetPagesAsync(
                search,
                pageNumber,
                pageSize,
                cancellationToken);

        PageNumber = result.Value == null ? 1 : result.Value.PageNumber;
        PageSize = result.Value == null ? 50 : result.Value.PageSize;
        TotalCount = result.Value == null ? 0 : result.Value.TotalCount;
        TotalPages = result.Value == null ? 1 : result.Value.TotalPages;

        Items.Clear();

        foreach (var item in result.Value?.Items ?? Array.Empty<ProductGroupDto>())
            Items.Add(item);
    }

    public async Task<Result> CreateAsync(
        CreateProductGroupDto dto,
        CancellationToken cancellationToken = default)
        => await _service.CreateAsync(dto, cancellationToken);

    public async Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default)
        => await _service.UpdateAsync(groupId, dto, cancellationToken);
}
