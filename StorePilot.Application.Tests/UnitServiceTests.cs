using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using StorePilot.Application.Dtos.UnitDtos;
using StorePilot.Application.Services;
using StorePilot.Domain.Entities;
using StorePilot.Infrastructure.Data; // نفترض أن الـ StorePilotDbContext موجود هنا
using FluentAssertions;
using StorePilot.Application.Validators.Units;

public class UnitServiceTests
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
    private Mock<ILogger<UnitService>> GetMockLogger() 
        => new Mock<ILogger<UnitService>>();

    private UnitService GetService(StorePilotDbContext context) => 
        new UnitService(
            context,
            GetMockLogger().Object,
            new CreateUnitDtoValidator(),
            new UpdateUnitDtoValidator());

    [Fact]
    public async Task GetByIdAsync_Should_Return_Unit_When_Id_Exists()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        var unit = new Unit { UnitName = "قطعة" };
        context.Units.Add(unit);
        await context.SaveChangesAsync(); // سيتم توليد UnitId تلقائياً (مثلاً 1)

        var service = GetService(context);

        // --- Act ---
        var result = await service.GetByIdAsync(unit.UnitId);

        // --- Assert ---
        result.Should().NotBeNull();
        result.UnitName.Should().Be("قطعة");
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
    public async Task ExistsAsync_Should_Return_True_When_Unit_Exists()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        var unit = new Unit { UnitName = "كرتونة" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act ---
        var result = await service.ExistsAsync(unit.UnitId);

        // --- Assert ---
        result.Should().BeTrue(); // العنصر موجود بالفعل
    }

    [Fact]
    public async Task ExistsAsync_Should_Return_False_When_Unit_Does_Not_Exist()
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
        // إدخال عدة وحدات لاختبار البحث والتقسيم
        context.Units.Add(new Unit { UnitName = "كيلوجرام" });
        context.Units.Add(new Unit { UnitName = "كيلومتر" });
        context.Units.Add(new Unit { UnitName = "قطعة" });
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act (البحث عن الوحدات التي تبدأ بكلمة "كيلو" بحجم صفحة 1 عناصر) ---
        var result = await service.GetPagesAsync(search: "كيلو", pageNumber: 1, pageSize: 1);

        // --- Assert ---
        result.PageNumber.Should().Be(1);
        result.PageSize.Should().Be(1);
        result.TotalCount.Should().Be(2);     // وجد عنصرين يمطابقان البحث
        result.TotalPages.Should().Be(2);    // طالما إجمالي العناصر 2 وحجم الصفحة 1، إذن لدينا صفحتان
        result.Items.Should().HaveCount(1);   // يجب أن يعود بعنصر واحد فقط في الصفحة الأولى
        result.Items[0].UnitName.Should().Be("كيلومتر"); // الأحدث يأتي أولاً بسبب OrderByDescending
    }

    [Fact]
    public async Task GetPagesAsync_Should_Return_All_Results_When_No_Search_Term_Is_Provided()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        // إدخال عدة وحدات لاختبار البحث والتقسيم
        context.Units.Add(new Unit { UnitName = "كيلوجرام" });
        context.Units.Add(new Unit { UnitName = "كيلومتر" });
        context.Units.Add(new Unit { UnitName = "قطعة" });
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act ---
        var result = await service.GetPagesAsync(search: null, pageNumber: 1, pageSize: 1);

        // --- Assert ---
        result.PageSize.Should().Be(1);
        result.PageNumber.Should().Be(1);
        result.TotalCount.Should().Be(3);     // وجد ثلاثة عناصر
        result.TotalPages.Should().Be(3);    // طالما إجمالي العناصر 3 وحجم الصفحة 1، إذن لدينا ثلاث صفحتان
        result.Items.Should().HaveCount(1);   // يجب أن يعود بعنصر واحد فقط في الصفحة الأولى
        result.Items[0].UnitName.Should().Be("قطعة"); // الأحدث يأتي أولاً بسبب OrderByDescending
    }

    [Fact]
    public async Task GetPagesAsync_Should_Return_No_Results_When_Search_Term_Does_Not_Match_Any_Units()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        // إدخال عدة وحدات لاختبار البحث والتقسيم
        context.Units.Add(new Unit { UnitName = "كيلوجرام" });
        context.Units.Add(new Unit { UnitName = "كيلومتر" });
        context.Units.Add(new Unit { UnitName = "قطعة" });
        await context.SaveChangesAsync();

        var service = GetService(context);

        // --- Act ---
        var result = await service.GetPagesAsync(search: "متر", pageNumber: 1, pageSize: 1);

        // --- Assert ---
        result.PageSize.Should().Be(1);
        result.PageNumber.Should().Be(1);
        result.TotalCount.Should().Be(0);     // لم يُجد أي عناصر
        result.TotalPages.Should().Be(0);    // طالما إجمالي العناصر 0 وحجم الصفحة 1، إذن لدينا صفحتان
        result.Items.Should().HaveCount(0);   // يجب أن يعود بعنصر واحد فقط في الصفحة الأولى
    }

    [Fact]
    public async Task CreateAsync_Should_Add_Unit_Successfully()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var dto = new CreateUnitDto("كيلوجرام");

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeTrue();
        result.Message.Should().Be("تمت عملية حفظ بيانات هذه الوحدة بنجاح.");

        // التحقق من أن العنصر أُضيف فعلياً لقاعدة البيانات الوهمية
        var dbCount = await context.Units.CountAsync();
        dbCount.Should().Be(1);

        var savedUnit = await context.Units.FirstOrDefaultAsync();
        savedUnit?.UnitName.Should().Be("كيلوجرام");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_CreateUnitDto_Is_Null()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        CreateUnitDto dto = null;

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("بيانات الوحدة غير موجودة!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Unit_Name_Is_NULL()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateUnitDto(null);

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Unit_Name_Is_Empty()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateUnitDto(string.Empty);

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Unit_Name_Is_Whitespace()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateUnitDto(" ");

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Unit_Name_Is_Larger_Than_20_Chars()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var service = GetService(GetInMemoryDbContext());

        var dto = new CreateUnitDto("أبتثجحخدذرزسشصضطظعغفق"); // 20 حروف

        // --- Act (التنفيذ) ---
        var result = await service.CreateAsync(dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة يجب ألا يتجاوز 20 حرفاً!");
    }

    [Fact]
    public async Task CreateAsync_Should_Fail_When_Unit_Name_Already_Exists()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        // إضافة وحدة مسبقاً لقاعدة البيانات
        context.Units.Add(new Unit { UnitName = "متر" });
        await context.SaveChangesAsync();

        var service = GetService(context);
        var duplicateDto = new CreateUnitDto("متر"); // نفس الاسم تماماً

        // --- Act ---
        var result = await service.CreateAsync(duplicateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("هذه الوحدة موجودة بالفعل!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Unit_Successfully()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var service = GetService(context);
        var updateDto = new UpdateUnitDto("صندوق جديد");

        // --- Act ---
        var result = await service.UpdateAsync(unit.UnitId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeTrue();

        var updatedEntity = await context.Units.FindAsync(unit.UnitId);
        updatedEntity?.UnitName.Should().Be("صندوق جديد");
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Unit_Successfully_When_Name_Is_Not_Updated()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        var logger = GetMockLogger();

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var service = GetService(context);
        var updateDto = new UpdateUnitDto("صندوق قديم");

        // --- Act ---
        var result = await service.UpdateAsync(unit.UnitId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeTrue();

        var updatedEntity = await context.Units.FindAsync(unit.UnitId);
        updatedEntity?.UnitName.Should().Be("صندوق قديم");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_UpdateUnitDto_Is_Null()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        var logger = GetMockLogger();

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var service = GetService(context);
        UpdateUnitDto updateDto = null;

        // --- Act ---
        var result = await service.UpdateAsync(unit.UnitId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("بيانات الوحدة غير موجودة!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Unit_Not_Found()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();
        int unitId = 999; // رقم غير موجود

        var unit = await context.Units.FindAsync(unitId); // رقم غير موجود

        var service = GetService(context);
        var updateDto = new UpdateUnitDto("صندوق جديد");

        // --- Act ---
        var result = await service.UpdateAsync(unitId, updateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("الوحدة غير موجودة!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Unit_Name_Is_NULL()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var dto = new UpdateUnitDto(null);

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(unit.UnitId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Unit_Name_Is_Empty()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var dto = new UpdateUnitDto(string.Empty);

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(unit.UnitId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Unit_Name_Is_Whitespace()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var dto = new UpdateUnitDto(" ");

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(unit.UnitId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Unit_Name_Is_Larger_Than_20_Chars()
    {
        // --- Arrange (الترتيب والتحضير) ---
        var context = GetInMemoryDbContext();
        var service = GetService(context);

        var unit = new Unit { UnitName = "صندوق قديم" };
        context.Units.Add(unit);
        await context.SaveChangesAsync();

        var dto = new UpdateUnitDto("أبتثجحخدذرزسشصضطظعغفق"); // 21 حرف

        // --- Act (التنفيذ) ---
        var result = await service.UpdateAsync(unit.UnitId, dto);

        // --- Assert (التحقق) ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("اسم الوحدة يجب ألا يتجاوز 20 حرفاً!");
    }

    [Fact]
    public async Task UpdateAsync_Should_Fail_When_Unit_Is_Dupplicate()
    {
        // --- Arrange ---
        var context = GetInMemoryDbContext();

        // إضافة وحدة مسبقاً لقاعدة البيانات
        context.Units.Add(new Unit { UnitName = "متر" });
        context.Units.Add(new Unit { UnitName = "قطعة" });
        await context.SaveChangesAsync();

        var service = GetService(context);
        var existsUnit = context.Units.First(); // الحصول على الوحدة الأولى (متر)
        var duplicateDto = new UpdateUnitDto("قطعة"); // نفس الاسم تماماً

        // --- Act ---
        var result = await service.UpdateAsync(
            existsUnit.UnitId, 
            duplicateDto);

        // --- Assert ---
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("هذه الوحدة موجودة بالفعل!");
    }
}
