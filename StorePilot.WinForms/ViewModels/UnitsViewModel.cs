using System.ComponentModel;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Interfaces;

namespace StorePilot.WinForms.ViewModels;

public sealed class UnitsViewModel
{
    private readonly IUnitService _service;

    public BindingList<UnitDto> Items { get; } = new();

    public int PageNumber { get; private set; } = 1;

    public int PageSize { get; private set; } = 10;

    public int TotalCount { get; private set; }

    public int TotalPages { get; private set; }

    public UnitsViewModel(IUnitService service)
    {
        _service = service;
    }

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

    public Task<Result<int>> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        return _service.CreateAsync(
            dto,
            cancellationToken);
    }

    public Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        return _service.UpdateAsync(
            unitId,
            dto,
            cancellationToken);
    }
}
