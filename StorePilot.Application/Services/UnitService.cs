using Microsoft.EntityFrameworkCore;
using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Interfaces;
using StorePilot.Application.Mappings;
using StorePilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

    public UnitService(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<IReadOnlyList<UnitDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _context.Units
            .OrderByDescending(x => x.UnitId)
            .AsNoTracking()
            .ToListAsync();

            var dtos = new List<UnitDto>();
            entities.ForEach(e => dtos.Add(e.ToDto()));

            return await Task.FromResult(
                Result<IReadOnlyList<UnitDto>>.Success(dtos));
        }
        catch
        {
            return await Task.FromResult(
                Result<IReadOnlyList<UnitDto>>.Failure(
                    "فشلت عملية الحصول على جميع وحدات القياس!"));
        }
    }

    public async Task<Result<UnitDto>> GetByIdAsync(
        int unitId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var item = await _context.Units.FindAsync(unitId);

            if (item is null)
                return await Task.FromResult(
                    Result<UnitDto>.Failure(
                        "وحدة قياس الصنف غير موجودة!"));

            return await Task.FromResult(
                Result<UnitDto>.Success(item.ToDto()));
        }
        catch
        {
            return await Task.FromResult(
                Result<UnitDto>.Failure(
                    "فشلت عملية الحصول على وحدة قياس الصنف!"));
        }
    }

    public async Task<Result<bool>> ExistsAsync(
        int unitId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            bool exists = await _context.Units.AnyAsync(
            x => x.UnitId == unitId);

            return await Task.FromResult(
                Result<bool>.Success(exists));
        }
        catch
        {
            return await Task.FromResult(
                Result<bool>.Failure("فشلت عملية التأكد من وجود وحدة القياس!"));
        }
    }

    public async Task<Result<PagedResult<UnitDto>>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(0, pageSize);

        try
        {
            var query = _context.Units
            .OrderByDescending(x => x.UnitId);

            var totalCount = await query.CountAsync();

            var totalPages = totalCount == 0
                ? 0
                : (int)Math.Ceiling(
                    totalCount / (double)pageSize);

            if (totalPages > 0 && pageNumber > totalPages)
                pageNumber = totalPages;

            IEnumerable<Unit> entities;

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

            var dtos = new List<UnitDto>();

            foreach (Unit unit in entities)
                dtos.Add(unit.ToDto());

            return await Task.FromResult(
                Result<PagedResult<UnitDto>>.Success(
                    new PagedResult<UnitDto>(
                    dtos,
                    totalCount,
                    pageNumber,
                    pageSize)));
        }
        catch
        {
            return await Task.FromResult(
                Result<PagedResult<UnitDto>>.Failure(
                    "فشلت عملية الحصول على وحدات القياس!"));
        }
    }

    public async Task<Result> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        try
        {
            if (await _context.Units.AnyAsync(x =>
            string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase)))
            {
                return await Task.FromResult(
                    Result.Failure(
                        "وحدة القياس هذه موجودة بالفعل."));
            }

            var item = dto.ToEntity();

            await _context.Units.AddAsync(item);

            int rowsAffected = await _context.SaveChangesAsync(cancellationToken);

            if (rowsAffected > 0)
                return await Task.FromResult(
                    Result.Success("تمت عملية حفظ بيانات وحدة القياس هذه بنجاح."));

            return await Task.FromResult(
                Result.Failure("لم يتم حفظ بيانات وحدة القياس هذه في النظام!"));
        }
        catch
        {
            return await Task.FromResult(
                Result.Failure("فشلت عملية حفظ بيانات وحدة القياس هذه في النظام!"));
        }
    }

    public async Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default)
    {
        var name = dto.Name.Trim();

        try
        {
            var item = await _context.Units.FindAsync(unitId);

            if (item is null)
            {
                return await Task.FromResult(
                    Result.Failure(
                        "وحدة قياس الصنف غير موجودة."));
            }

            if (await _context.Units.AnyAsync(x =>
                x.UnitId != unitId &&
                string.Equals(
                    x.Name,
                    name,
                    StringComparison.OrdinalIgnoreCase)))
            {
                return await Task.FromResult(
                    Result.Failure(
                        "وحدة القياس هذه موجودة بالفعل."));
            }

            item = dto.ToEntity(unitId);

            int rowsAffected = await _context.SaveChangesAsync(cancellationToken);

            if (rowsAffected > 0)
                return await Task.FromResult(
                    Result.Success());

            return await Task.FromResult(
                    Result.Failure("لم يتم حفظ بيانات وحدة القياس!"));
        }
        catch
        {
            return await Task.FromResult(
                    Result.Failure("فشلت عملية حفظ بيانات وحدة القياس!"));
        }
    }
}
