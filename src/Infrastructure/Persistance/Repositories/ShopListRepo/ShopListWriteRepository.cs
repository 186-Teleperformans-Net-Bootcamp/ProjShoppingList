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
        private readonly ProjShoppingListMsDbContext _context;
        private readonly ProjShoppingListPostgreSqlDbContext _postgreContext;
        public ShopListWriteRepository(ProjShoppingListMsDbContext context, ProjShoppingListPostgreSqlDbContext postgreContext) : base(context) =>
            (_context, _postgreContext) = (context, postgreContext);

        public async Task<bool> AddShopListAdminAsync(ShopList shopList)
        {
            if (shopList!=null)
            {
                await _postgreContext.AddAsync(shopList);
                await _postgreContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CompleteAsync(string id)
        {
            var completedList = await Task.Run(() => _context.ShopLists.SingleOrDefault(s => s.Id == id));
            completedList.IsCompleted = true;
            _context.SaveChanges();
            return true;
        }
    }
}
