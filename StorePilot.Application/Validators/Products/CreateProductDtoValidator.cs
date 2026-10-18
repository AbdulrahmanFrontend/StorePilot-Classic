using FluentValidation;
using StorePilot.Application.Dtos.ProductDtos;

namespace StorePilot.Application.Validators.Products;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("اسم المنتج مطلوب ولا يمكن أن يكون فارغاً!")
            .MaximumLength(50).WithMessage("اسم المنتج يجب ألا يتجاوز 50 حرفاً!");

        RuleFor(p => p.Code)
            .MaximumLength(20).WithMessage("كود المنتج يجب ألا يتجاوز 20 حرفاً!");

        RuleFor(p => p.MinQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("الحد الأدنى للكمية يجب أن يكون أكبر من أو يساوي صفر!")
            .LessThanOrEqualTo(999999)
            .WithMessage("الحد الأدنى للكمية يجب ألا يتجاوز 999999!");

        RuleFor(p => p.SalePrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("سعر البيع يجب أن يكون أكبر من أو يساوي صفر!")
            .LessThanOrEqualTo(999999)
            .WithMessage("سعر البيع يجب ألا يتجاوز 999999!");

        RuleFor(p => p.PurchasePrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("سعر الشراء يجب أن يكون أكبر من أو يساوي صفر!")
            .LessThanOrEqualTo(999999)
            .WithMessage("سعر الشراء يجب ألا يتجاوز 999999!");

        RuleFor(p => p.Notes)
            .MaximumLength(200).WithMessage("الملاحظات يجب ألا تتجاوز 200 حرفاً!");
    }
}
