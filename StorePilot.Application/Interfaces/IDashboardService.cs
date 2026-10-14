using StorePilot.Application.Common;
using StorePilot.Application.Dtos.DashboardDtos;

namespace StorePilot.Application.Interfaces;

public interface IDashboardService
{
    Task<Result<DashboardDto>> GetDashboardDataAsync(CancellationToken cancellationToken = default);
}
