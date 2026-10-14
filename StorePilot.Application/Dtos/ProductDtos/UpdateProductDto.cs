namespace StorePilot.Application.Dtos.ProductDtos;

public sealed record UpdateProductDto(string ProductName, string? Code, 
    decimal MinQuantity, decimal PurchasePrice, decimal SalePrice, int GroupId,
    string? Notes, bool Active);
