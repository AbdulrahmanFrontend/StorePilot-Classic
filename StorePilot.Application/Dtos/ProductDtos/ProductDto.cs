namespace StorePilot.Application.Dtos.ProductDtos;

public sealed record ProductDto(int ProductId, string ProductName, string? Code, 
    decimal Quantity, decimal MinQuantity, decimal PurchasePrice, decimal SalePrice,
    int UnitId, int GroupId, string? Notes, DateTime CreatedAt, bool Active);
