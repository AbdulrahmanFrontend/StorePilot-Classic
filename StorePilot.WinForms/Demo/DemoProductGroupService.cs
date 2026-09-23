using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Services.ProductGroupServices;

namespace StorePilot.WinForms.Demo;

public sealed class DemoProductGroupService : IProductGroupService
{
    private readonly List<ProductGroupDto> _items =
    [
        new(1, "نواكل"),
        new(2, "قطع بولي"),
        new(3, "قطع ابيض"),
        new(4, "مواسير بولي"),
        new(5, "مواسير ابيض"),
        new(6, "اطقم صيني"),
        new(7, "نواكل صيني"),
        new(8, "قطع ابيض صيني"),
        new(9, "حدايد وبويات"),
        new(10, "كهرباء"),
        new(11, "موبايل قسط"),
        new(12, "أجهزة كهربائية قسط"),
        new(13, "مستلزمات قسط"),

        new(14, "محابس"),
        new(15, "خلاطات"),
        new(16, "سيفونات"),
        new(17, "أحواض"),
        new(18, "بانيوهات"),
        new(19, "وصلات"),
        new(20, "كوع و تي"),
        new(21, "جلب"),
        new(22, "فلانشات"),
        new(23, "محولات"),
        new(24, "بلاعات"),
        new(25, "خراطيم"),
        new(26, "شطرطون"),
        new(27, "سيليكون"),
        new(28, "مواد عزل"),
        new(29, "أدوات سباكة"),
        new(30, "عدد يدوية")
    ];

    private int _nextId = 31;

    public Task<PagedResult<ProductGroupDto>> GetAllAsync(
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
            name);

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
                name);

        return Task.FromResult(
            Result.Success());
    }
}
