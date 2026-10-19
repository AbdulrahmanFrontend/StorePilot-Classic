namespace StorePilot.Application.Dtos.ProductGroupDtos;

public sealed record ProductGroupFilteredDto(
    int GroupId,
    string GroupName,
    DateTime CreatedAt);
