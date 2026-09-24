using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Dtos.UnitDtos;

namespace StorePilot.Application.Services.UnitServices;

public interface IUnitService
{
    Task<Result<IReadOnlyList<UnitDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<PagedResult<UnitDto>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<Result<UnitDto>> GetByIdAsync(
        int unitId,
        CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsAsync(
        int unitId,
        CancellationToken cancellationToken = default);

    Task<Result<int>> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default);
}
