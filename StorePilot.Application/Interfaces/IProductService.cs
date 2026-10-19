using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductDtos;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Dtos.UnitDtos;

namespace StorePilot.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ProductGroupDto>> GetAllGroups(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UnitDto>> GetAllUnits(
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        int productId,
        CancellationToken cancellationToken = default);

    Task<Result> CreateAsync(
        CreateProductDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int productId,
        UpdateProductDto dto,
        CancellationToken cancellationToken = default);

    Task<PagedResult<ProductDto>> GetFilteredAsync(
        ProductsQueryDto queryDto, 
        CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(
        int productId,
        CancellationToken cancellationToken = default);
}
