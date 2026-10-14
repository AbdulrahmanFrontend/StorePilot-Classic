namespace StorePilot.Application.Dtos.DashboardDtos;

public record LowStockItemDto(
    string ProductName, 
    int CurrentStock, 
    int MinimumStock);
