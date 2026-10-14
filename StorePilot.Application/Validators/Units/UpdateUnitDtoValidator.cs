using FluentValidation;
using StorePilot.Application.Dtos.UnitDtos;

namespace StorePilot.Application.Validators.Units;

public class UpdateUnitDtoValidator : AbstractValidator<UpdateUnitDto>
{
    public UpdateUnitDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.UnitName)
            .NotEmpty().WithMessage("اسم الوحدة مطلوب ولا يمكن أن يكون فارغاً!")
            .MaximumLength(20).WithMessage("اسم الوحدة يجب ألا يتجاوز 20 حرفاً!");
    }
}
