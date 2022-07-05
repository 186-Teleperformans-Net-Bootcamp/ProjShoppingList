using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyAllProducts
{
    public class BuyAllProductsCommandValidator : AbstractValidator<BuyAllProductsCommandRequest>
    {
        public BuyAllProductsCommandValidator()
        {

            RuleFor(x => x.ShopListId)
                .NotEmpty().WithMessage(ProductValidationMessages.ShopListIdControl);
        }
    }
}
