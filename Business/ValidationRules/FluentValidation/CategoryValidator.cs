using Business.Constants.FluentValidationMessages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation;
public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty().WithMessage(CategoryMessages.NameNull);
        RuleFor(category => category.Name).MinimumLength(4).WithMessage(CategoryMessages.NameMinLenght);
        RuleFor(category => category.Name).MaximumLength(99).WithMessage(CategoryMessages.NameMaxLenght);

        RuleFor(category => category.Description).NotEmpty().WithMessage(CategoryMessages.DescriptionNull);
        RuleFor(category => category.Description).MinimumLength(4).WithMessage(CategoryMessages.DescriptionMinLenght);
        RuleFor(category => category.Description).MaximumLength(199).WithMessage(CategoryMessages.DescriptionMaxLenght);

        RuleFor(category => category.Status).NotEmpty().WithMessage(CategoryMessages.StatusNull);
    }
}
