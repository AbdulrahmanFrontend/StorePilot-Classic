using StorePilot.Application.Dtos.ProductDtos;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Mappings;

public static class MappingProduct
{
    public static ProductDto ToDto(this Product product)
    {
        if (product is null)
            return null;

        return new ProductDto
           {
               ProductId = product.ProductId,
               ProductName = product.ProductName,
               Code = product.Code,
               Quantity = product.Quantity,
               MinQuantity = product.MinQuantity,
               PurchasePrice = product.PurchasePrice,
               SalePrice = product.SalePrice,
               UnitId = product.UnitId,
               GroupId = product.GroupId,
               Notes = product.Notes,
               CreatedAt = product.CreatedAt,
               Active = product.Active
           }; 
    }

    public static Product ToEntity(this CreateProductDto dto)
    {
        if (dto is null)
            return null;

        return new Product
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
    }

    public static void UpdateFromDto(this Product product ,UpdateProductDto dto)
    {
        if (product is null || dto is null)
            return;

        product.ProductName = dto.ProductName;
        product.Code = dto.Code;
        product.MinQuantity = dto.MinQuantity;
        product.PurchasePrice = dto.PurchasePrice;
        product.SalePrice = dto.SalePrice;
        product.GroupId = dto.GroupId;
        product.Notes = dto.Notes;
        product.Active = dto.Active;
    }
}
