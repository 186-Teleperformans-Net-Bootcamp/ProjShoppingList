using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        private readonly IProjShoppingListDbContext _context;
        public UpdateCategoryCommandValidator(IProjShoppingListDbContext context)
        {
          _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(CategoryValidationMessages.NameNotEmpty)
                .MaximumLength(200).MinimumLength(3).WithMessage(CategoryValidationMessages.NameMaxLength)
                .MustAsync(UniqueName).WithMessage(CategoryValidationMessages.NameUnique);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(CategoryValidationMessages.DescriptionNotEmpty)
                .MaximumLength(200).MinimumLength(3).WithMessage(CategoryValidationMessages.DescriptionMaxLength);
        }

        public async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {
            var control = _context.Categories.FirstOrDefault(f => f.Name == name);
            if (control == null)
            {
                return true;
            }
            return false;
        }
    }
}
