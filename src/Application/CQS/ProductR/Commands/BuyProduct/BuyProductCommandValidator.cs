using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyProduct
{
    public class BuyProductCommandValidator : AbstractValidator<BuyProductCommandRequest>
    {
        public BuyProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ProductValidationMessages.IdControl);
        }
    }
}
