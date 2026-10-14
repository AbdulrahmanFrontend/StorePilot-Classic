namespace StorePilot.Application.Dtos.DashboardDtos;

public record DashboardDto(
    decimal TodaySales,
    decimal TodayPurchases,
    decimal TotalDebts,
    int ProductsCount,
    int LowStockCount,
    List<LowStockItemDto> LowStockItems,
    List<RecentSaleItemDto> RecentSalesItems);
