namespace StorePilot.Application.Dtos.ProductDtos;

public sealed class ProductFilteredDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Code { get; set; }
    public decimal Quantity { get; set; }
    public decimal MinQuantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int UnitId { get; set; }
    public string UnitName { get; set; } = null!;
    public int GroupId { get; set; }
    public string GroupName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
}
