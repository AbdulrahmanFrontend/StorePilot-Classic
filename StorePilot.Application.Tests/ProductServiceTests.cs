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
        result?.Result.IsSuccess.Should().BeTrue();
        result?.Result.Message.Should().Be($"تم إنشاء المنتج بنجاح: {dto.ProductName}.");

        context.Products.Any().Should().BeTrue();
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_CreateProductDto_Is_NULL()
    {
        // -- Arrange --
        var service = GetService(GetInMemoryDbContext());

        // -- Act --
        var result = service.CreateAsync(null);

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("بيانات المنتج غير موجودة!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_ProductName_Is_NULL_Or_Empty_White_Space()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string productName = "";
        Random rnd = new Random();
        var randomValue = rnd.Next(1, 4); // Generates a random number between 1 and 3

        switch (randomValue)
        {
            case 1:
                productName = "";
                break;
            case 2:
                productName = null;
                break;
            case 3:
                productName = "   ";
                break;
        }

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(productName, null, 0, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("اسم المنتج مطلوب ولا يمكن أن يكون فارغاً!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_ProductName_Is_Larger_Than_50_Chars()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string productName = new string('a', 51); // Creates a string with 51 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(productName, null, 0, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("اسم المنتج يجب ألا يتجاوز 50 حرفاً!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Code_Is_Larger_Than_20_Chars()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, word, 0, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("كود المنتج يجب ألا يتجاوز 20 حرفاً!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_MinQuantity_Is_Less_Than_0()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, -1, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الحد الأدنى للكمية يجب أن يكون أكبر من أو يساوي صفر!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_MinQuantity_Is_Larger_Than_999999()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 1000000, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الحد الأدنى للكمية يجب ألا يتجاوز 999999!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_PurchasePrice_Is_Negative()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, -1, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر الشراء يجب أن يكون أكبر من أو يساوي صفر!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_PurchasePrice_Is_Larger_Than_999999()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, 1000000, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر الشراء يجب ألا يتجاوز 999999!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_SalePrice_Is_Negative()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, 0, -1, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر البيع يجب أن يكون أكبر من أو يساوي صفر!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_SalePrice_Is_Larger_Than_999999()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, 0, 1000000, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر البيع يجب ألا يتجاوز 999999!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Notes_Is_Larger_Than_200_Chars()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, 0, 0, 1, 1, new string('a', 201)));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الملاحظات يجب ألا تتجاوز 200 حرفاً!");

        context.Products.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_ProductGroup_Is_Not_Found()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("المجموعة المحددة غير موجودة!");

        context.Products.Any().Should().Be(false);
        context.ProductGroups.Any().Should().Be(false);
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Unit_Is_Not_Found()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await context.ProductGroups.AddAsync(new CreateProductGroupDto("مجموعة").ToEntity());
        await context.SaveChangesAsync();

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.CreateAsync(new CreateProductDto(word, null, 0, 0, 0, 1, 1, null));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الوحدة المحددة غير موجودة!");

        context.Products.Any().Should().Be(false);
        context.Units.Any().Should().Be(false);
    }

    private async Task SeedProductAsync(StorePilotDbContext context)
    {
        var group = new CreateProductGroupDto("مجموعة");
        await context.ProductGroups.AddAsync(group.ToEntity());

        var unit = new CreateUnitDto("متر");
        await context.Units.AddAsync(unit.ToEntity());

        await context.SaveChangesAsync();

        await context.Products.AddAsync(new CreateProductDto("ماسورة", null, 0, 0, 0, 1, 1, null).ToEntity());
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Product_Successfully()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var dto = new UpdateProductDto("ماسورة", null, 0, 0, 0, 1, null, false);

        var service = GetService(context);

        // -- Act --
        var result = service.UpdateAsync(1, dto);

        // -- Assert --
        result?.Result.IsSuccess.Should().BeTrue();
        result?.Result.Message.Should().Be($"تم تحديث المنتج بنجاح: {dto.ProductName}.");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Product_Is_Not_Found()
    {
        // -- Arrange --
        var service = GetService(GetInMemoryDbContext());

        // -- Act --
        var result = service.UpdateAsync(1, null);

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("المنتج المحدد غير موجود!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_UpdateProductDto_Is_NULL()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        // -- Act --
        var result = service.UpdateAsync(1, null);

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("بيانات المنتج غير موجودة!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductName_Is_NULL_Or_Empty_White_Space()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string productName = "";
        Random rnd = new Random();
        var randomValue = rnd.Next(1, 4); // Generates a random number between 1 and 3

        switch (randomValue)
        {
            case 1:
                productName = "";
                break;
            case 2:
                productName = null;
                break;
            case 3:
                productName = "   ";
                break;
        }

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(productName, null, 0, 0, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("اسم المنتج مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductName_Is_Larger_Than_50_Chars()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string productName = new string('a', 51); // Creates a string with 51 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(productName, null, 0, 0, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("اسم المنتج يجب ألا يتجاوز 50 حرفاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Code_Is_Larger_Than_20_Chars()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, word, 0, 0, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("كود المنتج يجب ألا يتجاوز 20 حرفاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_MinQuantity_Is_Less_Than_0()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, -1, 0, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الحد الأدنى للكمية يجب أن يكون أكبر من أو يساوي صفر!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_MinQuantity_Is_Larger_Than_999999()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 1000000, 0, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الحد الأدنى للكمية يجب ألا يتجاوز 999999!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_PurchasePrice_Is_Negative()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 0, -1, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر الشراء يجب أن يكون أكبر من أو يساوي صفر!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_PurchasePrice_Is_Larger_Than_999999()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 0, 1000000, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر الشراء يجب ألا يتجاوز 999999!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_SalePrice_Is_Negative()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 0, 0, -1, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر البيع يجب أن يكون أكبر من أو يساوي صفر!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_SalePrice_Is_Larger_Than_999999()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 0, 0, 1000000, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("سعر البيع يجب ألا يتجاوز 999999!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Notes_Is_Larger_Than_200_Chars()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await SeedProductAsync(context);

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 0, 0, 0, 1, new string('a', 201), true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("الملاحظات يجب ألا تتجاوز 200 حرفاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductGroup_Is_Not_Found()
    {
        // -- Arrange --
        var context = GetInMemoryDbContext();

        await context.Units.AddAsync(new CreateUnitDto("متر").ToEntity());
        await context.SaveChangesAsync();

        await context.Products.AddAsync(new CreateProductDto("ماسورة", null, 0, 0, 0, 1, 1, null).ToEntity());
        await context.SaveChangesAsync();

        var service = GetService(context);

        string word = new string('a', 21); // Creates a string with 21 characters

        // -- Act --
        var result = service.UpdateAsync(1, new UpdateProductDto(word, null, 0, 0, 0, 1, null, true));

        // -- Assert --
        result?.Result.IsSuccess.Should().BeFalse();
        result?.Result.Message.Should().Be("المجموعة المحددة غير موجودة!");
    }
}
