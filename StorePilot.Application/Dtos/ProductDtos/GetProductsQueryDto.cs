namespace StorePilot.Application.Dtos.ProductDtos;

public sealed record GetProductsQueryDto(
    string? SearchTerm,    // للبحث بالاسم أو الكود (يبدأ بـ StartsWith)
    int? GroupId,          // فلترة بالمجموعة
    bool? Active,          // تفعيل / غير تفعيل / الكل (لو null يجلب الكل)
    int PageNumber = 1,    // رقم الصفحة الحالية
    int PageSize = 50      // عدد العناصر في الصفحة
);
