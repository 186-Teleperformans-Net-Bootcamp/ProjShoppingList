using Application.Common.Repositories.ShopListRepo;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories.ShopListRepo
{
    public class ShopListWriteRepository : WriteRepository<ShopList>, IShopListWriteRepository
    {
        public ShopListWriteRepository(ProjShoppingListMsDbContext context) : base(context)
        {
        }
    }
}
