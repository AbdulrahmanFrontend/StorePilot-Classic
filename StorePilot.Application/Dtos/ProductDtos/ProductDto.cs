namespace StorePilot.Application.Dtos.ProductDtos;

public sealed class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Code { get; set; }
    public decimal Quantity { get; set; }
    public decimal MinQuantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int UnitId { get; set; }
    public int GroupId { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
}