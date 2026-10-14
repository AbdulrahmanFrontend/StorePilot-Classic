namespace StorePilot.Application.Dtos.ProductDtos;

public sealed record CreateProductDto(string ProductName, string? Code,
    decimal MinQuantity, decimal PurchasePrice, decimal SalePrice, int UnitId,
    int GroupId, string? Notes);
