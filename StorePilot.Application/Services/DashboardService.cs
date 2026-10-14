using StorePilot.Application.Common;
using StorePilot.Application.Dtos.DashboardDtos;
using StorePilot.Application.Interfaces;

namespace StorePilot.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IAppDbContext _context;

    public DashboardService(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DashboardDto>> GetDashboardDataAsync(
        CancellationToken cancellationToken = default)
    {
        // Initialize other properties as needed
        decimal TodaySales = 0;
        decimal TodayPurchases = 0;
        decimal TotalDebts = 0;
        int ProductsCount = 0;
        int LowStockCount = 0;
        List<LowStockItemDto> LowStockItems = new List<LowStockItemDto>();
        List<RecentSaleItemDto> RecentSalesItems = new List<RecentSaleItemDto>();

        var dashboardDto = new DashboardDto(
            TodaySales,
            TodayPurchases,
            TotalDebts,
            ProductsCount,
            LowStockCount,
            LowStockItems,
            RecentSalesItems
        );

        return Result<DashboardDto>.Success(dashboardDto);
    }
}
