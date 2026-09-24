using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Services.ProductGroupServices;

namespace StorePilot.WinForms.Demo;

public sealed class DemoProductGroupService : IProductGroupService
{
    private readonly List<ProductGroupDto> _items =
    [
        new(1, "نواكل", DateTime.Now),
        new(2, "قطع بولي", DateTime.Now),
        new(3, "قطع ابيض", DateTime.Now),
        new(4, "مواسير بولي", DateTime.Now),
        new(5, "مواسير ابيض", DateTime.Now),
        new(6, "اطقم صيني", DateTime.Now),
        new(7, "نواكل صيني", DateTime.Now),
        new(8, "قطع ابيض صيني", DateTime.Now),
        new(9, "حدايد وبويات", DateTime.Now),
        new(10, "كهرباء", DateTime.Now),
        new(11, "موبايل قسط", DateTime.Now),
        new(12, "أجهزة كهربائية قسط", DateTime.Now),
        new(13, "مستلزمات قسط", DateTime.Now),
        new(14, "محابس", DateTime.Now),
        new(15, "خلاطات", DateTime.Now),
        new(16, "سيفونات", DateTime.Now),
        new(17, "أحواض", DateTime.Now),
        new(18, "بانيوهات", DateTime.Now),
        new(19, "وصلات", DateTime.Now),
        new(20, "كوع و تي", DateTime.Now),
        new(21, "جلب", DateTime.Now),
        new(22, "فلانشات", DateTime.Now),
        new(23, "محولات", DateTime.Now),
        new(24, "بلاعات", DateTime.Now),
        new(25, "خراطيم", DateTime.Now),
        new(26, "شطرطون", DateTime.Now),
        new(27, "سيليكون", DateTime.Now),
        new(28, "مواد عزل", DateTime.Now),
        new(29, "أدوات سباكة", DateTime.Now),
        new(30, "عدد يدوية", DateTime.Now)
    ];

    private int _nextId = 31;

    public Task<Result<IReadOnlyList<ProductGroupDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var items = _items
            .OrderBy(x => x.Name)
            .ToList()
            .AsReadOnly();
        return Task.FromResult(
            Result<IReadOnlyList<ProductGroupDto>>.Success(items));
    }

    public Task<Result<ProductGroupDto>> GetByIdAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        var item = _items.FirstOrDefault(
            x => x.GroupId == groupId);
        if (item is null)
        {
            return Task.FromResult(
                Result<ProductGroupDto>.Failure(
                    "مجموعة المنتج غير موجودة."));
        }
        return Task.FromResult(
            Result<ProductGroupDto>.Success(item));
    }

    public Task<Result<bool>> ExistsAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        var exists = _items.Any(
            x => x.GroupId == groupId);
        return Task.FromResult(
            Result<bool>.Success(exists));
    }

    public Task<PagedResult<ProductGroupDto>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(1, pageSize);

        IEnumerable<ProductGroupDto> query = _items;

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
            new PagedResult<ProductGroupDto>(
                items,
                totalCount,
                pageNumber,
                pageSize));
    }

    public Task<Result<int>> CreateAsync(
        CreateProductGroupDto dto,
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
                    "هذه المجموعة موجودة بالفعل."));
        }

        var item = new ProductGroupDto(
            _nextId++,
            name,
            DateTime.Now);

        _items.Add(item);

        return Task.FromResult(
            Result<int>.Success(item.GroupId));
    }

    public Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        var index = _items.FindIndex(
            x => x.GroupId == groupId);

        if (index < 0)
        {
            return Task.FromResult(
                Result.Failure(
                    "مجموعة المنتج غير موجودة."));
        }

        if (_items.Any(x =>
            x.GroupId != groupId &&
            string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(
                Result.Failure(
                    "هذه المجموعة موجودة بالفعل."));
        }

        _items[index] =
            new ProductGroupDto(
                groupId,
                name,
                DateTime.Now);

        return Task.FromResult(
            Result.Success());
    }
}
