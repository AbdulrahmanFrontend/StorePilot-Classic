using Microsoft.EntityFrameworkCore;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Interfaces;
using StorePilot.Application.Mappings;
using StorePilot.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StorePilot.Application.Services;

public class ProductGroupService : IProductGroupService
{
    //private readonly List<ProductGroupDto> _items =
    //[
    //    new(1, "نواكل", DateTime.Now),
    //    new(2, "قطع بولي", DateTime.Now),
    //    new(3, "قطع ابيض", DateTime.Now),
    //    new(4, "مواسير بولي", DateTime.Now),
    //    new(5, "مواسير ابيض", DateTime.Now),
    //    new(6, "اطقم صيني", DateTime.Now),
    //    new(7, "نواكل صيني", DateTime.Now),
    //    new(8, "قطع ابيض صيني", DateTime.Now),
    //    new(9, "حدايد وبويات", DateTime.Now),
    //    new(10, "كهرباء", DateTime.Now),
    //    new(11, "موبايل قسط", DateTime.Now),
    //    new(12, "أجهزة كهربائية قسط", DateTime.Now),
    //    new(13, "مستلزمات قسط", DateTime.Now),
    //    new(14, "محابس", DateTime.Now),
    //    new(15, "خلاطات", DateTime.Now),
    //    new(16, "سيفونات", DateTime.Now),
    //    new(17, "أحواض", DateTime.Now),
    //    new(18, "بانيوهات", DateTime.Now),
    //    new(19, "وصلات", DateTime.Now),
    //    new(20, "كوع و تي", DateTime.Now),
    //    new(21, "جلب", DateTime.Now),
    //    new(22, "فلانشات", DateTime.Now),
    //    new(23, "محولات", DateTime.Now),
    //    new(24, "بلاعات", DateTime.Now),
    //    new(25, "خراطيم", DateTime.Now),
    //    new(26, "شطرطون", DateTime.Now),
    //    new(27, "سيليكون", DateTime.Now),
    //    new(28, "مواد عزل", DateTime.Now),
    //    new(29, "أدوات سباكة", DateTime.Now),
    //    new(30, "عدد يدوية", DateTime.Now)
    //];

    //private int _nextId = 31;

    private readonly IAppDbContext _context;

    public ProductGroupService(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<IReadOnlyList<ProductGroupDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _context.ProductGroups
            .OrderByDescending(x => x.GroupId)
            .AsNoTracking()
            .ToListAsync();

            var dtos = new List<ProductGroupDto>();
            entities.ForEach(e => dtos.Add(e.ToDto()));

            return await Task.FromResult(
                Result<IReadOnlyList<ProductGroupDto>>.Success(dtos));
        }
        catch
        {
            return await Task.FromResult(
                Result<IReadOnlyList<ProductGroupDto>>.Failure(
                    "فشلت عملية الحصول على جميع المجموعات!"));
        }
    }

    public async Task<Result<ProductGroupDto>> GetByIdAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var item = await _context.ProductGroups.FindAsync(groupId);

            if (item is null)
                return await Task.FromResult(
                    Result<ProductGroupDto>.Failure(
                        "مجموعة المنتج غير الصنف!"));

            return await Task.FromResult(
                Result<ProductGroupDto>.Success(item.ToDto()));
        }
        catch
        {
            return await Task.FromResult(
                Result<ProductGroupDto>.Failure(
                    "فشلت عملية الحصول على مجموعة الصنف!"));
        }
    }

    public async Task<Result<bool>> ExistsAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            bool exists = await _context.ProductGroups.AnyAsync(
            x => x.GroupId == groupId);

            return await Task.FromResult(
                Result<bool>.Success(exists));
        }
        catch
        {
            return await Task.FromResult(
                Result<bool>.Failure("فشلت عملية التأكد من وجود هذه المجموعة!"));
        }
    }

    public async Task<Result<PagedResult<ProductGroupDto>>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(0, pageSize);

        try
        {
            var query = _context.ProductGroups
            .OrderByDescending(x => x.GroupId);

            var totalCount = await query.CountAsync();

            var totalPages = totalCount == 0
                ? 0
                : (int)Math.Ceiling(
                    totalCount / (double)pageSize);

            if (totalPages > 0 && pageNumber > totalPages)
                pageNumber = totalPages;

            IEnumerable<ProductGroup> entities;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var value = search.Trim();

                entities = await query.Where(x =>
                    x.Name.StartsWith(
                        value,
                        StringComparison.OrdinalIgnoreCase))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            else
                entities = await query.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            var dtos = new List<ProductGroupDto>();

            foreach (ProductGroup group in entities)
                dtos.Add(group.ToDto());

            return await Task.FromResult(
                Result<PagedResult<ProductGroupDto>>.Success(
                    new PagedResult<ProductGroupDto>(
                    dtos,
                    totalCount,
                    pageNumber,
                    pageSize)));
        }
        catch
        {
            return await Task.FromResult(
                Result<PagedResult<ProductGroupDto>>.Failure(
                    "فشلت عملية الحصول على المجموعات!"));
        }
    }

    public async Task<Result> CreateAsync(
        CreateProductGroupDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        try
        {
            if (await _context.ProductGroups.AnyAsync(x =>
            string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase)))
            {
                return await Task.FromResult(
                    Result.Failure(
                        "هذه المجموعة موجودة بالفعل."));
            }

            var item = dto.ToEntity();

            await _context.ProductGroups.AddAsync(item);

            int rowsAffected = await _context.SaveChangesAsync(cancellationToken);

            if (rowsAffected > 0)
                return await Task.FromResult(
                    Result.Success("تمت عملية حفظ بيانات هذه المجموعة بنجاح."));

            return await Task.FromResult(
                Result.Failure("لم يتم حفظ بيانات هذه المجموعة للنظام!"));
        }
        catch
        {
            return await Task.FromResult(
                Result.Failure("فشلت عملية حفظ بيانات هذه المجموعة للنظام!"));
        }
    }

    public async Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        try
        {
            var item = await _context.ProductGroups.FindAsync(groupId);

            if (item is null)
            {
                return await Task.FromResult(
                    Result.Failure(
                        "مجموعة الصنف غير موجودة."));
            }

            if (await _context.ProductGroups.AnyAsync(x =>
                x.GroupId != groupId &&
                string.Equals(
                    x.Name,
                    name,
                    StringComparison.OrdinalIgnoreCase)))
            {
                return await Task.FromResult(
                    Result.Failure(
                        "هذه المجموعة موجودة بالفعل."));
            }

            item = dto.ToEntity(groupId);

            int rowsAffected = await _context.SaveChangesAsync(cancellationToken);

            if (rowsAffected > 0)
                return await Task.FromResult(
                    Result.Success());

            return await Task.FromResult(
                    Result.Failure("لم يتم حفظ بيانات هذه المجموعة!"));
        }
        catch
        {
            return await Task.FromResult(
                    Result.Failure("فشلت عملية حفظ بيانات هذه المجموعة!"));
        }
    }
}
