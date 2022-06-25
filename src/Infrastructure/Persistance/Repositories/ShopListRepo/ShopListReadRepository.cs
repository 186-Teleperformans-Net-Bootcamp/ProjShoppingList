using Application.Common.Models;
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
    public class ShopListReadRepository : ReadRepository<ShopList>, IShopListReadRepository
    {
        public ShopListReadRepository(ProjShoppingListMsDbContext context) : base(context)
        {
        }

        public Task<PaginatedList<ShopList>> GetAllAsync(PaginatedParameters paginatedParameters)
        {
            throw new NotImplementedException();
        }
    }
}
