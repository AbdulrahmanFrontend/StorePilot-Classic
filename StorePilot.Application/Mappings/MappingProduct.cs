using StorePilot.Application.Dtos.ProductDtos;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Mappings;

public static class MappingProduct
{
    public static ProductDto ToDto(this Product product)
        => new ProductDto(product.ProductId, product.ProductName, product.Code, 
            product.Quantity, product.MinQuantity, product.PurchasePrice, product.SalePrice,
            product.UnitId, product.GroupId, product.Notes, product.CreatedAt, 
            product.Active);

    public static Product ToEntity(this CreateProductDto dto)
        => new Product
        {
            ProductName = dto.ProductName,
            Code = dto.Code,
            MinQuantity = dto.MinQuantity,
            PurchasePrice = dto.PurchasePrice,
            SalePrice = dto.SalePrice,
            UnitId = dto.UnitId,
            GroupId = dto.GroupId,
            Notes = dto.Notes
        };

    public static Product ToEntity(this UpdateProductDto dto, int productId)
        => new Product
        {
            ProductId = productId,
            ProductName = dto.ProductName,
            Code = dto.Code,
            MinQuantity = dto.MinQuantity,
            PurchasePrice = dto.PurchasePrice,
            SalePrice = dto.SalePrice,
            GroupId = dto.GroupId,
            Notes = dto.Notes,
            Active = dto.Active
        };
}
