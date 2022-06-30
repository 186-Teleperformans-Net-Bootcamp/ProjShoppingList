using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddShopList
{
    public class AddShopListCommandValidator : AbstractValidator<AddShopListCommandRequest>
    {
        public AddShopListCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ShopListValidationMessages.TitleNotEmpty)
                .Length(3, 200).WithMessage(ShopListValidationMessages.TitleLength);
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithErrorCode(ShopListValidationMessages.CategoryIdControl);
        }
    }
}
