using Application.Common.Repositories.ProductShopListRepo;
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
        public ProductShopListReadRepository(ProjShoppingListMsDbContext context) : base(context)
        {
        }
    }
}
