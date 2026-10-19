using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Mappings;

public static class MappingProductGroup
{
    public static ProductGroupFilteredDto ToQueryDto(this ProductGroup productGroup)
        => new ProductGroupFilteredDto(
            productGroup.GroupId,
            productGroup.GroupName, 
            productGroup.CreatedAt);

    public static ProductGroupDto ToDto(this ProductGroup productGroup)
    {
        if (productGroup is null)
            return null;

        return new ProductGroupDto(
            productGroup.GroupId,
            productGroup.GroupName); 
    }

    public static ProductGroup ToEntity(this CreateProductGroupDto dto)
        => new ProductGroup { GroupName = dto.GroupName };

    public static void UpdateFromDto(
        this ProductGroup entity,
        UpdateProductGroupDto dto)
    {
        entity.GroupName = dto.GroupName;
    }
}
