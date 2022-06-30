using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.CompleteShopList
{
    public class CompleteShopListCommandValidator : AbstractValidator<CompleteShopListCommandRequest>
    {
        public CompleteShopListCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode(ShopListValidationMessages.IdControl);
        }
    }
}
