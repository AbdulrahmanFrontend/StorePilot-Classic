namespace StorePilot.Application.Dtos.UnitDtos;

public sealed record UnitFilteredDto(
    int UnitId,
    string UnitName,
    DateTime CreatedAt);
