using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Interfaces;
using StorePilot.Application.Mappings;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Services;

public class ProductGroupService : IProductGroupService
{
    private readonly IAppDbContext _context;
    private readonly ILogger<ProductGroupService> _logger;

    public ProductGroupService(
        IAppDbContext context, 
        ILogger<ProductGroupService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Result<IReadOnlyList<ProductGroupDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _context.ProductGroups
            .OrderByDescending(x => x.GroupId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var dtos = entities.Select(e => e.ToDto()).ToList();

        return Result<IReadOnlyList<ProductGroupDto>>.Success(dtos);
    }

    public async Task<Result<ProductGroupDto>> GetByIdAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        var item = await _context.ProductGroups.FindAsync(
            new object[] { groupId }, 
            cancellationToken);

        if (item is null)
            return Result<ProductGroupDto>.Failure(
                "مجموعة الصنف غير موجودة!");

        return Result<ProductGroupDto>.Success(item.ToDto());
    }

    public async Task<Result<bool>> ExistsAsync(
        int groupId,
        CancellationToken cancellationToken = default)
    {
        bool exists = await _context.ProductGroups.AnyAsync(
            x => x.GroupId == groupId,
            cancellationToken);

        return Result<bool>.Success(exists);
    }

    public async Task<Result<PagedResult<ProductGroupDto>>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(1, pageSize);

        var query = _context.ProductGroups
            .OrderByDescending(x => x.GroupId)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var value = search.Trim();
            query = (IOrderedQueryable<ProductGroup>)query
                .Where(x => x.Name.StartsWith(value));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var totalPages = totalCount == 0
            ? 0
            : (int)Math.Ceiling(totalCount / (double)pageSize);

        if (totalPages > 0 && pageNumber > totalPages)
            pageNumber = totalPages;

        var entities = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var dtos = entities.Select(e => e.ToDto()).ToList();

        var pagedResult = new PagedResult<ProductGroupDto>(
            dtos,
            totalCount,
            pageNumber,
            pageSize);

        return Result<PagedResult<ProductGroupDto>>.Success(pagedResult);
    }

    public async Task<Result> CreateAsync(
        CreateProductGroupDto dto,
        CancellationToken cancellationToken = default)
    {
        if(dto is null)
            return Result.Failure("بيانات المجموعة غير موجودة!");

        var name = dto.Name.Trim();

        bool exists = await _context.ProductGroups.AnyAsync(
            x => string.Equals(
                x.Name,
                name),
            cancellationToken);

        if (exists)
            return Result.Failure("هذه المجموعة موجودة بالفعل!");

        var item = dto.ToEntity();

        await _context.ProductGroups.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // تسجيل الحدث بنجاح داخل ملف الـ Log الخاص بالعميل
        _logger.LogInformation(
            "تم إنشاء مجموعة أصناف جديدة بنجاح باسم: {GroupName}",
            name);

        return Result.Success(
            "تمت عملية حفظ بيانات هذه المجموعة بنجاح.");
    }

    public async Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default)
    {
        if(dto is null)
            return Result.Failure("بيانات المجموعة غير موجودة!");

        var name = dto.Name.Trim();

        var item = await _context.ProductGroups.FindAsync(
            new object[] { groupId },
            cancellationToken);

        if (item is null)
            return Result.Failure("مجموعة الصنف غير موجودة!");

        bool isDuplicate = await _context.ProductGroups.AnyAsync(
            x => x.GroupId != groupId && string.Equals(x.Name,
            name),
            cancellationToken);

        if (isDuplicate)
            return Result.Failure("هذه المجموعة موجودة بالفعل!");

        item.UpdateFromDto(dto);

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "تم تحديث مجموعة الأصناف برقم {GroupId} بنجاح إلى الاسم:" +
            " {GroupName}",
            groupId,
            name);

        return Result.Success("تم تحديث بيانات المجموعة بنجاح.");
    }
}
