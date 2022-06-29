using Application.Common.Interfaces;
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
        private readonly IProjShoppingListDbContext _context;
        public AddProductToShopListCommandValidator()
        {
            RuleFor(x => x.ShopListId)
                .NotEmpty().NotNull().WithMessage("Please enter correctly");
            RuleFor()
        }
        public async Task<bool> UniqueId(string id, CancellationToken cancellationToken)
        {
            var control = _context.ShopLists.FirstOrDefault(f => f.Id == id);
            if (control != null)
            {
                return true;
            }
            return false;
        }
    }
}
