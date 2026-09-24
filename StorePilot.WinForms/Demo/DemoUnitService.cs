using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Services.UnitServices;

namespace StorePilot.WinForms.Demo;

public sealed class DemoUnitService : IUnitService
{
    private readonly List<UnitDto> _items =
    [
        new(1, "قطعة"),
        new(2, "متر"),
        new(3, "كرتونة"),
        new(4, "كيلوجرام"),
        new(5, "علبة"),
        new(6, "لفة"),
        new(7, "طقم"),
        new(8, "كيلو"),
        new(9, "زوج"),
        new(10, "رول"),
        new(11, "عبوة"),
        new(12, "شوال"),
        new(13, "كيس"),
        new(14, "صندوق"),
        new(15, "حبة"),
        new(16, "جركن"),
        new(17, "لوح"),
        new(18, "متر مربع"),
        new(19, "متر طولي"),
        new(20, "دستة")
    ];

    private int _nextId = 21;

    public Task<Result<IReadOnlyList<UnitDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var items = _items
            .OrderBy(x => x.Name)
            .ToList()
            .AsReadOnly();
        return Task.FromResult(
            Result<IReadOnlyList<UnitDto>>.Success(items));
    }

    public Task<Result<UnitDto>> GetByIdAsync(
        int unitId,
        CancellationToken cancellationToken = default)
    {
        var item = _items.FirstOrDefault(
            x => x.UnitId == unitId);
        if (item is null)
        {
            return Task.FromResult(
                Result<UnitDto>.Failure(
                    "الوحدة غير موجودة."));
        }
        return Task.FromResult(
            Result<UnitDto>.Success(item));
    }

    public Task<Result<bool>> ExistsAsync(
        int unitId,
        CancellationToken cancellationToken = default)
    {
        var exists = _items.Any(
            x => x.UnitId == unitId);
        return Task.FromResult(
            Result<bool>.Success(exists));
    }

    public Task<PagedResult<UnitDto>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(1, pageSize);

        IEnumerable<UnitDto> query = _items;

        if (!string.IsNullOrWhiteSpace(search))
        {
            var value = search.Trim();

            query = query.Where(x =>
                x.Name.Contains(
                    value,
                    StringComparison.OrdinalIgnoreCase));
        }

        var orderedItems = query
            .OrderBy(x => x.Name)
            .ToList();

        var totalCount = orderedItems.Count;

        var items = orderedItems
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var totalPages = totalCount == 0
            ? 0
            : (int)Math.Ceiling(
                totalCount / (double)pageSize);

        if (totalPages > 0 && pageNumber > totalPages)
        {
            pageNumber = totalPages;

            items = orderedItems
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        return Task.FromResult(
            new PagedResult<UnitDto>(
                items,
                totalCount,
                pageNumber,
                pageSize));
    }

    public Task<Result<int>> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        if (_items.Any(x =>
            string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(
                Result<int>.Failure(
                    "هذه الوحدة موجودة بالفعل."));
        }

        var item = new UnitDto(
            _nextId++,
            name);

        _items.Add(item);

        return Task.FromResult(
            Result<int>.Success(item.UnitId));
    }

    public Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        var index = _items.FindIndex(
            x => x.UnitId == unitId);

        if (index < 0)
        {
            return Task.FromResult(
                Result.Failure(
                    "الوحدة غير موجودة."));
        }

        if (_items.Any(x =>
            x.UnitId != unitId &&
            string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(
                Result.Failure(
                    "هذه الوحدة موجودة بالفعل."));
        }

        _items[index] =
            new UnitDto(unitId, name);

        return Task.FromResult(
            Result.Success());
    }
}
