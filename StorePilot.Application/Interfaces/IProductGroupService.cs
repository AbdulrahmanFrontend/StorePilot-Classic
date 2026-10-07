using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;

namespace StorePilot.Application.Interfaces;

public interface IProductGroupService
{
    Task<Result<IReadOnlyList<ProductGroupDto>>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Result<PagedResult<ProductGroupDto>>> GetPagesAsync(
        string? search = null,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<Result<ProductGroupDto>> GetByIdAsync(
        int groupId,
        CancellationToken cancellationToken = default);

    Task<Result<bool>> ExistsAsync(
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
