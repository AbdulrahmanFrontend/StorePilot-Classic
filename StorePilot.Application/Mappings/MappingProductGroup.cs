using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Mappings;

public static class MappingProductGroup
{
    public static ProductGroupDto ToDto(this ProductGroup productGroup)
        => new ProductGroupDto(
            productGroup.GroupId,
            productGroup.GroupName, 
            productGroup.CreatedAt);

    public static ProductGroup ToEntity(this CreateProductGroupDto dto)
        => new ProductGroup { GroupName = dto.Name };

    public static void UpdateFromDto(
        this ProductGroup entity,
        UpdateProductGroupDto dto)
    {
        entity.GroupName = dto.Name;
    }
}
