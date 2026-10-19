using StorePilot.Application.Common;
using StorePilot.Application.Dtos.UnitDtos;

namespace StorePilot.Application.Interfaces;

public interface IUnitService
{
    Task<PagedResult<UnitFilteredDto>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 50,
        CancellationToken cancellationToken = default);

    Task<UnitDto> GetByIdAsync(
        int unitId,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        int unitId,
        CancellationToken cancellationToken = default);

    Task<Result> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default);
}
