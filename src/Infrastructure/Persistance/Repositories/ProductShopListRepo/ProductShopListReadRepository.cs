using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Repositories.ProductShopListRepo;
using Domain.Consts.Messages;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories.ProductShopListRepo
{
    public class ProductShopListReadRepository : ReadRepository<ProductShopList>, IProductShopListReadRepository
    {
        private readonly IProjShoppingListDbContext _context;
        public ProductShopListReadRepository(ProjShoppingListMsDbContext context) : base(context) => _context = context;
       

        public async Task<List<ProductShopList>> GetAllByShopListIdAsync(string shopListId)
        {
           var result=_context.ProductShopList.Where(w => w.ShopListId == shopListId).ToList();
            if (result.Count>-1)
            {
                return result;
            }
            throw new NotFoundException(ErrorMessages.NotFoundProduct);
        }
    }
}
