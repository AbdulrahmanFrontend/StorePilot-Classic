using StorePilot.Application.Common;
using StorePilot.Application.Dtos.UnitDtos;

namespace StorePilot.Application.Services.UnitServices;

public interface IUnitService
{
    Task<PagedResult<UnitDto>> GetAllAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<Result<int>> CreateAsync(
        CreateUnitDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int unitId,
        UpdateUnitDto dto,
        CancellationToken cancellationToken = default);
}
