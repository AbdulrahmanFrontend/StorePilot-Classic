using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Application.Mappings;

public static class MappingProductGroup
{
    public static ProductGroupDto ToDto(this ProductGroup productGroup)
        => new ProductGroupDto(
            productGroup.GroupId,
            productGroup.Name, 
            productGroup.CreatedAt);

    public static ProductGroup ToEntity(this CreateProductGroupDto dto)
        => new ProductGroup { Name = dto.Name };

    public static ProductGroup ToEntity(this UpdateProductGroupDto dto, int groupId)
        => new ProductGroup { GroupId = groupId, Name = dto.Name };
}
