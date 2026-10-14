using FluentValidation;
using StorePilot.Application.Dtos.ProductGroupDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Application.Validators.ProductGroups;

public class UpdateProductGroupDtoValidator : AbstractValidator<UpdateProductGroupDto>
{
    public UpdateProductGroupDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم المجموعة مطلوب ولا يمكن أن يكون فارغاً!")
            .MaximumLength(20).WithMessage("اسم المجموعة يجب ألا يتجاوز 20 حرفاً!");
    }
}
