using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using StorePilot.Application.Dtos.ProductGroupDtos;
using StorePilot.Application.Services;
using StorePilot.Application.Validators.ProductGroups;
using StorePilot.Domain.Entities;
using StorePilot.Infrastructure.Data;

public class ProductGroupServiceTests
{
    // دالة مساعدة لإنشاء قاعدة بيانات وهمية جديدة ونظيفة لكل اختبار (لضمان الاستقلالية)
    private StorePilotDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<StorePilotDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // اسم عشوائي لضمان عدم تداخل البيانات بين الاختبارات
            .Options;

        var context = new StorePilotDbContext(options);
        return context;
    }
    
    // دالة مساعدة لإنشاء Logger وهمي باستخدام Moq
    private Mock<ILogger<ProductGroupService>> GetMockLogger()
        => new Mock<ILogger<ProductGroupService>>();

    private ProductGroupService GetService(StorePilotDbContext context) =>
        new ProductGroupService(
            context,
            GetMockLogger().Object,
            new CreateProductGroupDtoValidator(),
            new UpdateProductGroupDtoValidator());

    [Fact]
    public async Task GetByIdAsync_Should_Return_Product_Group_When_Id_Exists()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        var productGroup = new ProductGroup { GroupName = "مجموعة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync(); // سيتم توليد ProductGroupId تلقائياً (مثلاً 1)

        var service = GetService(context);

        // --- Act ---
        var result = await service.GetByIdAsync(productGroup.GroupId);

        // --- Assert ---
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdAsync_Should_Fail_When_Id_Does_Not_Exist()
    {
        // --- Arrange ---
        var service = GetService(GetInMemoryDbContext());

        // --- Act ---
        var result = await service.GetByIdAsync(999); // رقم غير موجود

        // --- Assert ---
        result.Should().BeNull();
    }

    [Fact]
    public async Task ExistsAsync_Should_Return_True_When_Product_Group_Exists()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        var productGroup = new ProductGroup { GroupName = "مجموعة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act ---
        var result = await service.ExistsAsync(productGroup.GroupId);

        // --- Assert ---
        result.Should().BeTrue(); // العنصر موجود بالفعل
    }

    [Fact]
    public async Task ExistsAsync_Should_Return_False_When_Product_Group_Does_Not_Exist()
    {
        // --- Arrange ---
        var service = GetService(GetInMemoryDbContext());

        // --- Act ---
        var result = await service.ExistsAsync(9999); // رقم غير موجود

        // --- Assert ---
        result.Should().BeFalse(); // العنصر غير موجود
    }

    [Fact]
    public async Task GetPagesAsync_Should_Return_Filtered_And_Paged_Results_Correctly()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        // إدخال عدة مجموعات لاختبار البحث والتقسيم
        context.ProductGroups.Add(new ProductGroup { GroupName = "نواكل" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مواسير" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مستلزمات كهرباء" });
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act (البحث عن المجموعات التي تبدأ بكلمة "م" بحجم صفحة 1 عناصر) ---
        var result = await service.GetPagesAsync(search: "م", pageNumber: 1, pageSize: 1);

        // --- Assert ---
        result.TotalCount.Should().Be(2);     // وجد عنصرين يمطابقان البحث
        result.TotalPages.Should().Be(2);    // طالما إجمالي العناصر 2 وحجم الصفحة 1، إذن لدينا صفحتان
        result.Items.Should().HaveCount(1);   // يجب أن يعود بعنصر واحد فقط في الصفحة الأولى
        result.Items[0].GroupName.Should().Be("مستلزمات كهرباء"); // الأحدث يأتي أولاً بسبب OrderByDescending
    }

    [Fact]
    public async Task GetPagesAsync_Should_Return_All_Results_When_No_Search_Term_Is_Provided()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        // إدخال عدة مجموعات لاختبار البحث والتقسيم
        context.ProductGroups.Add(new ProductGroup { GroupName = "نواكل" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مواسير" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مستلزمات كهرباء" });
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act ---
        var result = await service.GetPagesAsync(search: null, pageNumber: 1, pageSize: 1);

        // --- Assert ---
        result.PageNumber.Should().Be(1);
        result.TotalCount.Should().Be(3);     // وجد ثلاثة عناصر
        result.TotalPages.Should().Be(3);    // طالما إجمالي العناصر 3 وحجم الصفحة 1، إذن لدينا ثلاث صفحتان
        result.Items.Should().HaveCount(1);   // يجب أن يعود بعنصر واحد فقط في الصفحة الأولى
        result.Items[0].GroupName.Should().Be("مستلزمات كهرباء"); // الأحدث يأتي أولاً بسبب OrderByDescending
    }

    [Fact]
    public async Task GetPagesAsync_Should_Return_No_Results_When_Search_Term_Does_Not_Match_Any_Product_Groups()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        // إدخال عدة مجموعات لاختبار البحث والتقسيم
        context.ProductGroups.Add(new ProductGroup { GroupName = "نواكل" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مواسير" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مستلزمات كهرباء" });
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act ---
        var result = await service.GetPagesAsync(search: "ت", pageNumber: 1, pageSize: 1);

        // --- Assert ---
        result.PageNumber.Should().Be(1);
        result.TotalCount.Should().Be(0);     // لم يُجد أي عناصر
        result.TotalPages.Should().Be(0);    // طالما إجمالي العناصر 0 وحجم الصفحة 1، إذن لدينا صفحتان
        result.Items.Should().HaveCount(0);   // يجب أن يعود بعنصر واحد فقط في الصفحة الأولى
    }

    [Fact]
    public async Task CreateAsync_Should_Add_Product_Group_Successfully()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var dto = new CreateProductGroupDto("نواكل");

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be("تمت عملية حفظ بيانات هذه المجموعة بنجاح.");

        // التحقق من أن العنصر أُضيف فعلياً لقاعدة البيانات الوهمية
        var dbCount = await context.ProductGroups.CountAsync();
        dbCount.Should().Be(1);

        var savedGroup = await context.ProductGroups.FirstOrDefaultAsync();
        savedGroup?.GroupName.Should().Be("نواكل");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_CreateProductGroupDto_Is_Null()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        CreateProductGroupDto dto = null;

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("بيانات المجموعة غير موجودة!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_ProductGroup_Name_Is_NULL()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateProductGroupDto(null);

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Product_Group_Name_Is_Empty()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateProductGroupDto(string.Empty);

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Product_Group_Name_Is_Whitespace()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateProductGroupDto(" ");

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_ProductGroup_Name_Is_Larger_Than_20_Chars()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateProductGroupDto("أبتثجحخدذرزسشصضطظعغفق"); // 20 حروف

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة يجب ألا يتجاوز 20 حرفاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_ProductGroup_Name_Already_Exists()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        // إضافة مجموعة منتجات مسبقاً لقاعدة البيانات
        context.ProductGroups.Add(new ProductGroup { GroupName = "مجموعة قديمة" });
        await context.SaveChangesAsync();

        var service = GetService(context);
        var duplicateDto = new CreateProductGroupDto("مجموعة قديمة"); // نفس الاسم تماماً

        // --- Act ---
        var result = await service.CreateAsync(duplicateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("هذه المجموعة موجودة بالفعل!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Product_Group_Successfully()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var service = GetService(context);
        var updateDto = new UpdateProductGroupDto("مجموعة جديدة");

        // --- Act ---
        var result = await service.UpdateAsync(productGroup.GroupId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeTrue();

        var updatedEntity = await context.ProductGroups.FindAsync(productGroup.GroupId);
        updatedEntity?.GroupName.Should().Be("مجموعة جديدة");
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Product_Group_Successfully_When_Name_Is_Not_Updated()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        var logger = GetMockLogger();

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var service = GetService(context);
        var updateDto = new UpdateProductGroupDto("مجموعة قديمة");

        // --- Act ---
        var result = await service.UpdateAsync(productGroup.GroupId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeTrue();

        var updatedEntity = await context.ProductGroups.FindAsync(productGroup.GroupId);
        updatedEntity?.GroupName.Should().Be("مجموعة قديمة");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_UpdateProductGroupDto_Is_Null()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        var logger = GetMockLogger();

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var service = GetService(context);
        UpdateProductGroupDto updateDto = null;

        // --- Act ---
        var result = await service.UpdateAsync(productGroup.GroupId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("بيانات المجموعة غير موجودة!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Product_Group_Not_Found()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        int groupId = 999; // رقم غير موجود

        var service = GetService(context);
        var updateDto = new UpdateProductGroupDto("مجموعة جديدة");

        // --- Act ---
        var result = await service.UpdateAsync(groupId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("المجموعة غير موجودة!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductGroup_Name_Is_NULL()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var dto = new UpdateProductGroupDto(null);

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(productGroup.GroupId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductGroup_Name_Is_Empty()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var dto = new UpdateProductGroupDto(string.Empty);

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(productGroup.GroupId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductGroup_Name_Is_Whitespace()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var dto = new UpdateProductGroupDto(" ");

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(productGroup.GroupId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductGroup_Name_Is_Larger_Than_20_Chars()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var productGroup = new ProductGroup { GroupName = "مجموعة قديمة" };
        context.ProductGroups.Add(productGroup);
        await context.SaveChangesAsync();

        var dto = new UpdateProductGroupDto("أبتثجحخدذرزسشصضطظعغفق"); // 21 حرف

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(productGroup.GroupId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم المجموعة يجب ألا يتجاوز 20 حرفاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_ProductGroup_Is_Dupplicate()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        // إضافة مجموعة مسبقة لقاعدة البيانات
        context.ProductGroups.Add(new ProductGroup { GroupName = "مجموعة قديمة" });
        context.ProductGroups.Add(new ProductGroup { GroupName = "مجموعة أخرى" });
        await context.SaveChangesAsync();

        var service = GetService(context);
        var existsProductGroup = context.ProductGroups.First(); // الحصول على المجموعة الأولى
        var duplicateDto = new UpdateProductGroupDto("مجموعة أخرى"); // نفس الاسم تماماً

        // --- Act ---
        var result = await service.UpdateAsync(
            existsProductGroup.GroupId,
            duplicateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("هذه المجموعة موجودة بالفعل!");
    }
}
