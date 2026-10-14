using StorePilot.Domain.Enums;

namespace StorePilot.Application.Dtos.DashboardDtos;

public record RecentSaleItemDto(
    string InvoiceNumber,
    string CustomerName,
    decimal TotalAmount,
    PaymentStatus Status,
    DateTime SaleDate);  
