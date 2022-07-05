using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.RemoveShopList
{
    public class RemoveShopListCommandValidator : AbstractValidator<RemoveShopListCommandRequest>
    {
        public RemoveShopListCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode(ShopListValidationMessages.IdControl);
        }
    }
}
