namespace StorePilot.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string? Code { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Quantity { get; set; } = 0;

    public decimal MinQuantity { get; set; } = 0;

    public decimal SalePrice { get; set; } = 0;

    public decimal PurchasePrice { get; set; } = 0;

    public int UnitId { get; set; }

    public int GroupId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Notes { get; set; }

    public bool Active { get; set; } = true;


    // Navigation Properties

    public Unit Unit { get; set; } = null!;

    public ProductGroup Group { get; set; } = null!;
}
