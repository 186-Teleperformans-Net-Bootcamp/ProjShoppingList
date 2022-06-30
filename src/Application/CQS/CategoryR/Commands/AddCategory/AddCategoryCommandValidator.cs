using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Commands.AddCategory
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommandRequest>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(CategoryValidationMessages.NameNotEmpty)
                .MaximumLength(200).MinimumLength(3).WithMessage(CategoryValidationMessages.NameMaxLength);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(CategoryValidationMessages.DescriptionNotEmpty)
                .MaximumLength(200).MinimumLength(3).WithMessage(CategoryValidationMessages.DescriptionMaxLength);
        }
        
    }
}
