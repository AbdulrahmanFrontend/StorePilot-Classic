using StorePilot.Application.Common;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Services.ProductGroupServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.ViewModels;

public sealed class AddEditGroupViewModel
{
    private readonly IProductGroupService _service;

    public AddEditGroupViewModel(IProductGroupService service)
    {
        _service = service;
    }

    public async Task<Result<ProductGroupDto>> GetByIdAsync(
        int groupId,
        CancellationToken cancellationToken = default)
        => await _service.GetByIdAsync(groupId, cancellationToken);

    public async Task<Result<int>> CreateAsync(
        CreateProductGroupDto dto,
        CancellationToken cancellationToken = default)
        => await _service.CreateAsync(dto, cancellationToken);

    public async Task<Result> UpdateAsync(
        int groupId,
        UpdateProductGroupDto dto,
        CancellationToken cancellationToken = default)
        => await _service.UpdateAsync(groupId, dto, cancellationToken);
}
