using StorePilot.Application.Common;
using StorePilot.Application.Dtos.DashboardDtos;
using StorePilot.Application.Interfaces;

namespace StorePilot.WinForms.ViewModels;

public sealed class DashboardViewModel
{
    private readonly IDashboardService _dashboardService;

    public DashboardViewModel(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public Task<Result<DashboardDto>> GetDashboardDataAsync()
        => _dashboardService.GetDashboardDataAsync();
}