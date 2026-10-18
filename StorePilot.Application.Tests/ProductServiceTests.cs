using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using StorePilot.Application.Dtos.ProductDtos;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Mappings;
using StorePilot.Application.Services;
using StorePilot.Application.Validators.Products;
using StorePilot.Infrastructure.Data;

public class ProductServiceTests
{
    private StorePilotDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<StorePilotDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new StorePilotDbContext(options);
    }

    private Mock<ILogger<ProductService>> GetMockLogger()
        => new Mock<ILogger<ProductService>>();

    private ProductService GetService(StorePilotDbContext context)
        => new ProductService(
            context, 
            GetMockLogger().Object,
            new CreateProductDtoValidator(), 
            new UpdateProductDtoValidator());

    [Fact]
    public async Task CreateAsync_Should_Add_Product_Successfully()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        var group = new CreateProductGroupDto("مجموعة");
        await context.ProductGroups.AddAsync(group.ToEntity());

        var unit = new CreateUnitDto("متر");
        await context.Units.AddAsync(unit.ToEntity());

        await context.SaveChangesAsync();

        var dto = new CreateProductDto("ماسورة", null, 0, 0, 0, 1, 1, null);

        var service = GetService(context);

        // -- Act --
        var result = service.CreateAsync(dto);

        // -- Assert --
        result.Result.IsSuccess.Should().BeTrue();
        result.Result.Message.Should().Be($"تم إنشاء المنتج بنجاح: {dto.ProductName}.");

        var count = await context.Products.CountAsync();
        count.Should().Be(1);
    }
}
