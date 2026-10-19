using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;

namespace StorePilot.Application.Interfaces;

public interface IProductGroupService
{
    Task<PagedResult<ProductGroupFilteredDto>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 50,
        CancellationToken cancellationToken = default);

    Task<ProductGroupDto> GetByIdAsync(
        int groupId,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        int groupId,
        CancellationToken cancellationToken = default);

    Task<Result> CreateAsync(
        CreateProductGroupDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default);
}
