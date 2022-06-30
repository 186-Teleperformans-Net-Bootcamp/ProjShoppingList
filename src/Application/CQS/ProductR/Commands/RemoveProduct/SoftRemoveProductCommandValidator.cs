using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.RemoveProduct
{
    public class SoftRemoveProductCommandValidator : AbstractValidator<SoftRemoveProductCommandRequest>
    {
        public SoftRemoveProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode(ProductValidationMessages.IdControl);
        }
    }
}
