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
        public ShopListWriteRepository(ProjShoppingListMsDbContext context) : base(context) => _context = context;


        public async Task<bool> CompleteAsync(string id)
        {
            var completedList = await Task.Run(() => _context.ShopLists.SingleOrDefault(s => s.Id == id));
            completedList.IsCompleted = true;
            _context.SaveChanges();
            return true;
        }
    }
}
