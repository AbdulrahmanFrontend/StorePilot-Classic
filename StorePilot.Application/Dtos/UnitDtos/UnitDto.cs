using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Application.Dtos.UnitDtos;

public sealed record UnitDto(
    int UnitId,
    string Name,
    DateTime CreatedAt);
