using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Interfaces;
using StorePilot.Application.Mappings;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Services;

public class UnitService : IUnitService
{
    //private readonly List<UnitDto> _items =
    //[
    //    new(1, "قطعة", DateTime.Now),
    //    new(2, "متر", DateTime.Now),
    //    new(3, "كرتونة", DateTime.Now),
    //    new(4, "كيلوجرام", DateTime.Now),
    //    new(5, "علبة", DateTime.Now),
    //    new(6, "لفة", DateTime.Now),
    //    new(7, "طقم", DateTime.Now),
    //    new(8, "كيلو", DateTime.Now),
    //    new(9, "زوج", DateTime.Now),
    //    new(10, "رول", DateTime.Now),
    //    new(11, "عبوة", DateTime.Now),
    //    new(12, "شوال", DateTime.Now),
    //    new(13, "كيس", DateTime.Now),
    //    new(14, "صندوق", DateTime.Now),
    //    new(15, "حبة", DateTime.Now),
    //    new(16, "جركن", DateTime.Now),
    //    new(17, "لوح", DateTime.Now),
    //    new(18, "متر مربع", DateTime.Now),
    //    new(19, "متر طولي", DateTime.Now),
    //    new(20, "دستة", DateTime.Now)
    //];

    private readonly IAppDbContext _context;
    private readonly ILogger<UnitService> _logger;
    private readonly IValidator<CreateUnitDto> _createValidator;
    private readonly IValidator<UpdateUnitDto> _updateValidator; // جديد

    public UnitService(
        IAppDbContext context,
        ILogger<UnitService> logger,
        IValidator<CreateUnitDto> createValidator,
        IValidator<UpdateUnitDto> updateValidator) // استقباله عبر الـ DI
    {
        _context = context;
        _logger = logger;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<UnitDto> GetByIdAsync(
        int unitId,
        CancellationToken cancellationToken = default)
    {
        var item = await _context.Units.FindAsync(
            new object[] { unitId },
            cancellationToken);

        return item.ToDto();
    }

    public async Task<bool> ExistsAsync(
        int unitId,
        CancellationToken cancellationToken = default)
    {
        bool exists = await _context.Units.AnyAsync(
            x => x.UnitId == unitId,
            cancellationToken);

        return exists;
    }

    public async Task<PagedResult<UnitFilteredDto>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 50,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(1, pageSize);

        var query = _context.Units
            .OrderByDescending(x => x.UnitId)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var value = search.Trim();
            query = (IOrderedQueryable<Unit>)query
                .Where(x => x.UnitName.StartsWith(value)).AsNoTracking();
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
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var dtos = entities.Select(e => e.ToQueryDto()).ToList();

        var pagedResult = new PagedResult<UnitFilteredDto>(
            dtos,
            totalCount,
            pageNumber,
            pageSize);

        return pagedResult;
    }

    public async Task<Result> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        if(dto is null)
        {
            _logger.LogWarning("محاولة إنشاء وحدة جديدة بدون بيانات!");
            return Result.Failure("بيانات الوحدة غير موجودة!");
        }

        var validationResult = await _createValidator
            .ValidateAsync(dto, cancellationToken);

        if (!validationResult.IsValid)
        {
            string errorMessage = validationResult.Errors.First().ErrorMessage;

            _logger.LogWarning(
                "فشل التحقق من صحة بيانات الوحدة الجديدة: {Error}",
                errorMessage);
            return Result.Failure(errorMessage);
        }

        var name = dto.UnitName.Trim();

        bool exists = await _context.Units.AnyAsync(
            x => string.Equals(
                x.UnitName,
                name),
            cancellationToken);

        if (exists)
        {
            _logger.LogWarning(
                "محاولة إنشاء وحدة جديدة باسم موجود بالفعل: {UnitName}",
                name);
            return Result.Failure("هذه الوحدة موجودة بالفعل!");
        }

        var item = dto.ToEntity();

        await _context.Units.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        // تسجيل الحدث بنجاح داخل ملف الـ Log الخاص بالعميل
        _logger.LogInformation(
            "تم إنشاء وحدة جديدة بنجاح باسم: {UnitName}",
            name);

        return Result.Success(
            "تمت عملية حفظ بيانات هذه الوحدة بنجاح.");
    }

    public async Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        if(dto is null)
        {
            _logger.LogWarning(
                "محاولة تحديث بيانات الوحدة برقم {UnitId} ب��ون بيانات!",
                unitId);
            return Result.Failure("بيانات الوحدة غير موجودة!");
        }

        var validationResult = await _updateValidator
            .ValidateAsync(dto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            string errorMessage = validationResult.Errors.First().ErrorMessage;

            _logger.LogWarning(
                "فشل التحقق من صحة بيانات الوحدة برقم {UnitId}: {Error}",
                unitId,
                errorMessage);
            return Result.Failure(errorMessage);
        }

        var name = dto.UnitName.Trim();

        var item = await _context.Units.FindAsync(
            new object[] { unitId },
            cancellationToken);

        if (item is null)
        {
            _logger.LogWarning(
                "محاولة تحديث بيانات الوحدة برقم {UnitId} غير موجودة!",
                unitId);
            return Result.Failure("الوحدة غير موجودة!");
        }

        bool isDuplicate = await _context.Units.AnyAsync(
            x => x.UnitId != unitId && string.Equals(x.UnitName,
            name),
            cancellationToken);

        if (isDuplicate)
        {
            _logger.LogWarning(
                "محاولة تحديث بيانات الوحدة برقم {UnitId}, الإسم موجود بالفعل: {UnitName}",
                unitId,
                name);
            return Result.Failure("هذه الوحدة موجودة بالفعل!");
        }

        item.UpdateFromDto(dto);

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "تم تحديث الوحدة برقم {UnitId} بنجاح إلى الاسم:" +
            " {UnitName}",
            unitId,
            name);

        return Result.Success("تم تحديث بيانات الوحدة بنجاح.");
    }
}
