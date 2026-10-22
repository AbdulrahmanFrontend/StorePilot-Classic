using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductDtos;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Interfaces;
using StorePilot.Application.Mappings;

namespace StorePilot.Application.Services;

public class ProductService : IProductService
{
    private readonly IAppDbContext _context;
    private readonly ILogger<ProductService> _logger;
    private readonly IValidator<CreateProductDto> _createValidator;
    private readonly IValidator<UpdateProductDto> _updateValidator;

    public ProductService(
        IAppDbContext context,
        ILogger<ProductService> logger,
        IValidator<CreateProductDto> createValidator, 
        IValidator<UpdateProductDto> updateValidator)
    {
        _context = context;
        _logger = logger;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<IReadOnlyList<ProductGroupDto>> GetAllGroupsAsync(
        CancellationToken cancellationToken = default)
    {
        var groups = await _context.ProductGroups
            .Select(g => g.ToDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return groups;
    }

    public async Task<IReadOnlyList<UnitDto>> GetAllUnitsAsync(
        CancellationToken cancellationToken = default)
    {
        var units = await _context.Units
            .Select(u => u.ToDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return units;
    }

    private async Task<Result> ValidationResult(
        CreateProductDto dto,
        CancellationToken cancellationToken)
    {
        if (dto is null)
        {
            _logger.LogWarning("بيانات إنشاء المنتج غير موجودة!");
            return Result.Failure("بيانات المنتج غير موجودة!");
        }

        var validationResult = await _createValidator.ValidateAsync(dto, cancellationToken);

        if (!validationResult.IsValid)
        {
            string errorMessage = validationResult.Errors.First().ErrorMessage;

            _logger.LogWarning(
                "فشل التحقق من صحة بيانات إنشاء المنتج: {Errors}", 
                errorMessage);
            return Result.Failure(errorMessage);
        }

        bool exists = await _context.Products
            .AnyAsync(p => p.ProductName == dto.ProductName, cancellationToken);

        if (exists)
        {
            _logger.LogWarning(
                "محاولة إنشاء منتج باسم موجود بالفعل: {ProductName}",
                dto.ProductName);
            return Result.Failure("هذا المنتج موجود بالفعل!");
        }

        exists = !string.IsNullOrWhiteSpace(dto.Code) && await _context.Products
            .AnyAsync(p => p.Code == dto.Code, cancellationToken);

        if (exists)
        {
            _logger.LogWarning("محاولة إنشاء منتج بكود موجود بالفعل: {Code}", dto.Code);
            return Result.Failure("هذا الكود موجود بالفعل!");
        }

        exists = await _context.ProductGroups
            .AnyAsync(g => g.GroupId == dto.GroupId, cancellationToken);

        if (!exists)
        {
            _logger.LogWarning(
                "محاولة إنشاء منتج لمجموعة غير موجودة: {GroupId}", 
                dto.GroupId);
            return Result.Failure("المجموعة المحددة غير موجودة!");
        }

        exists = await _context.Units
            .AnyAsync(u => u.UnitId == dto.UnitId, cancellationToken);

        if (!exists)
        {
            _logger.LogWarning("محاولة إنشاء منتج بوحدة غير موجودة: {UnitId}", dto.UnitId);
            return Result.Failure("الوحدة المحددة غير موجودة!");
        }

        return Result.Success();
    }

    public async Task<Result> CreateAsync(
        CreateProductDto dto,
        CancellationToken cancellationToken = default)
    {
        var result = await ValidationResult(dto, cancellationToken);

        if (!result.IsSuccess)
            return result;

        var product = dto.ToEntity();

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("تم إنشاء المنتج بنجاح: {ProductId}", product.ProductId);

        return Result.Success($"تم إنشاء المنتج بنجاح: {product.ProductName}.");
    }

    public async Task<Result> DeleteAsync(
        int productId, 
        CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FindAsync(productId, cancellationToken);

        if (product is null)
        {
            _logger.LogWarning("محاولة حذف منتج غير موجود: {ProductId}", productId);
            return Result.Failure("المنتج المطلوب حذفه غير موجود!");
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("تم حذف المنتج بنجاح: {ProductId}", productId);

        return Result.Success("تم حذف المنتج بنجاح.");
    }

    public async Task<bool> ExistsAsync(
        int productId, 
        CancellationToken cancellationToken = default)
    {
        bool exists = await _context.Products.AnyAsync(
            p => p.ProductId == productId, 
            cancellationToken);

        return exists;
    }

    public async Task<ProductDto> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken = default)
    {
        var product = _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken)
            .Result;

        return product.ToDto();
    }

    public async Task<PagedResult<ProductFilteredDto>> GetFilteredAsync(
        ProductsQueryDto queryDto,
        CancellationToken cancellationToken = default)
    {
        if (queryDto is null)
            return null;

        // 1. نبدأ بـ IQueryable الأساسي
        var query = _context.Products.AsQueryable().AsNoTracking();

        // 2. تطبيق فلتر الحالة (تفعيل / غير تفعيل / الكل)
        if (queryDto.Active.HasValue)
            query = query.Where(p => p.Active == queryDto.Active.Value);

        // 3. تطبيق فلتر المجموعة إذا تم تحديده
        if (queryDto.GroupId.HasValue)
            query = query.Where(p => p.GroupId == queryDto.GroupId.Value);

        // 4. تطبيق البحث النصي (بالاسم أو بالكود - تبدأ بـ StartsWith لاستغلال الفهارس)
        if (!string.IsNullOrWhiteSpace(queryDto.SearchTerm))
        {
            var term = queryDto.SearchTerm.Trim();
            query = query
                .Where(
                p => p.ProductName.StartsWith(term) 
                || (p.Code != null && p.Code.StartsWith(term)));
        }

        // 5. الأهم: حساب العدد الإجمالي للسجلات المطابقة للبحث *قبل* الـ Skip و Take
        var totalCount = await query.CountAsync(cancellationToken);

        // 6. الترتيب التنازلي حسب الـ ID (الأحدث يظهر أولاً)
        query = query.OrderByDescending(p => p.ProductId);

        // 7. تطبيق الـ Pagination لجلب عناصر الصفحة الحالية فقط
        var skip = (queryDto.PageNumber - 1) * queryDto.PageSize;

        var items = await query
            .Skip(skip)
            .Take(queryDto.PageSize)
            .Include(p => p.Group) // إذا كنت بحاجة إلى تضمين بيانات المجموعة
            .Select(p => new ProductFilteredDto 
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Code = p.Code,
                Quantity = p.Quantity,
                MinQuantity = p.MinQuantity,
                PurchasePrice = p.PurchasePrice,
                SalePrice = p.SalePrice,
                UnitId = p.UnitId,
                UnitName = p.Unit.UnitName, // تضمين اسم الوحدة
                GroupId = p.GroupId,
                GroupName = p.Group.GroupName, // تضمين اسم المجموعة
                CreatedAt = p.CreatedAt,
                Active = p.Active
            })
            .ToListAsync(cancellationToken);

        // 8. إرجاع النتيجة مغلفة في الـ PagedResult الجاهز لديك
        return new PagedResult<ProductFilteredDto>(
            items,
            totalCount, 
            queryDto.PageNumber,
            queryDto.PageSize);
    }

    private async Task<Result> ValidationResult(
        int productId,
        UpdateProductDto dto,
        CancellationToken cancellationToken)
    {
        if (dto is null)
        {
            _logger.LogWarning("بيانات التحديث للمنتج غير موجودة: {ProductId}", productId);
            return Result.Failure("بيانات المنتج غير موجودة!");
        }

        var validationResult = await _updateValidator.ValidateAsync(dto, cancellationToken);

        if (!validationResult.IsValid)
        {
            string errorMessage = validationResult.Errors.First().ErrorMessage;

            _logger.LogWarning("فشل التحقق من صحة بيانات المنتج: {Errors}", errorMessage);
            return Result.Failure(errorMessage);
        }

        bool exists = await _context.Products.AnyAsync(
            p => p.ProductName == dto.ProductName && p.ProductId != productId,
            cancellationToken);

        if (exists)
        {
            _logger.LogWarning(
                "محاولة تحديث منتج باسم موجود بالفعل: {ProductName}",
                dto.ProductName);
            return Result.Failure("هذا المنتج موجود بالفعل!");
        }

        exists = !string.IsNullOrWhiteSpace(dto.Code) && await _context.Products
            .AnyAsync(p => p.Code == dto.Code && p.ProductId != productId,
            cancellationToken);

        if (exists)
        {
            _logger.LogWarning("محاولة تحديث منتج بكود موجود بالفعل: {Code}", dto.Code);
            return Result.Failure("هذا الكود موجود بالفعل!");
        }

        exists = await _context.ProductGroups
            .AnyAsync(g => g.GroupId == dto.GroupId, cancellationToken);

        if (!exists)
        {
            _logger.LogWarning(
                "محاولة تحديث منتج لمجموعة غير موجودة: {GroupId}",
                dto.GroupId);
            return Result.Failure("المجموعة المحددة غير موجودة!");
        }

        return Result.Success();
    }

    public async Task<Result> UpdateAsync(
        int productId,
        UpdateProductDto dto,
        CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FindAsync(productId, cancellationToken);

        if (product is null)
        {
            _logger.LogWarning("محاولة تحديث منتج غير موجود: {ProductId}", productId);
            return Result.Failure("المنتج المحدد غير موجود!");
        }

        var result = await ValidationResult(productId, dto, cancellationToken);

        if (!result.IsSuccess)
            return result;

        product.UpdateFromDto(dto);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("تم تحديث المنتج بنجاح: {ProductId}", product.ProductId);

        return Result.Success($"تم تحديث المنتج بنجاح: {product.ProductName}.");
    }
}
