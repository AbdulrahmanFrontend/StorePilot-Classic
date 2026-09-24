using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Application.Services.ProductServices;

public interface IProductService
{
    Task<PagedResult<ProductDto>> GetAllAsync(
        string? search,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<Result<int>> CreateAsync(
        CreateProductDto dto,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(
        int productId,
        UpdateProductDto dto,
        CancellationToken cancellationToken = default);
}
