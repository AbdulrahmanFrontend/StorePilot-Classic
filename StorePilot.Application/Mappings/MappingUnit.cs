using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Mappings;

public static class MappingUnit
{
    public static UnitFilteredDto ToQueryDto(this Unit unit)
        => new UnitFilteredDto(unit.UnitId, unit.UnitName, unit.CreatedAt);

    public static UnitDto ToDto(this Unit unit)
    {
        if (unit is null)
            return null;

        return new UnitDto(unit.UnitId, unit.UnitName); 
    }

    public static Unit ToEntity(this CreateUnitDto dto)
        => new Unit { UnitName = dto.UnitName };

    public static void UpdateFromDto(
        this Unit entity,
        UpdateUnitDto dto)
    {
        entity.UnitName = dto.UnitName;
    }
}
