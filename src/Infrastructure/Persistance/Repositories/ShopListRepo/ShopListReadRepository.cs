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
        private readonly ProjShoppingListMsDbContext _context;
        public ShopListReadRepository(ProjShoppingListMsDbContext context) : base(context) => _context = context;

        public async Task<List<ShopList>> GetAllWithPaginationAsync(string userId, PaginatedParameters paginatedParameters)
        {
            var result = PaginatedList<ShopList>.ToPagedList(_context.ShopLists.Where(w => w.UserId == userId), paginatedParameters.PageNumber, paginatedParameters.PageSize);
            return result;
        }
    }
}
