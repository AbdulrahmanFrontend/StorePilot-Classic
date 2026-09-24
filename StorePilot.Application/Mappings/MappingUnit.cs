using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace StorePilot.Application.Mappings;

public static class MappingUnit
{
    public static UnitDto ToDto(this Unit unit)
        => new UnitDto(unit.UnitId, unit.Name, unit.CreatedAt);

    public static Unit ToEntity(this CreateUnitDto dto)
        => new Unit { Name = dto.Name };

    public static Unit ToEntity(this UpdateUnitDto dto, int unitId)
        => new Unit { UnitId = unitId, Name = dto.Name };
}
