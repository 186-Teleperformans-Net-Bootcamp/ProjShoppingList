using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.UpdateShopList
{
    public class UpdateShopListCommandValidator : AbstractValidator<UpdateShopListCommandRequest>
    {
        public UpdateShopListCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode(ShopListValidationMessages.IdControl);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ShopListValidationMessages.TitleNotEmpty)
                .Length(3, 200).WithMessage(ShopListValidationMessages.TitleLength);

        }
    }
}
