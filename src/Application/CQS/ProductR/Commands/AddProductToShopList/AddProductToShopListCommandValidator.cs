using Application.Common.Interfaces;
using Domain.Consts.Messages.ValidationMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.AddProductToShopList
{
    public class AddProductToShopListCommandValidator:AbstractValidator<AddProductToShopListCommandRequest>
    {
        public AddProductToShopListCommandValidator()
        {
            RuleFor(x => x.ShopListId)
                .NotEmpty().NotNull().WithMessage("Please enter correctly");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ProductValidationMessages.NameNotEmpty)
                .Length(3, 200).WithMessage(ProductValidationMessages.LengthName);
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage(ProductValidationMessages.MinPrice);
        }
    }
}
