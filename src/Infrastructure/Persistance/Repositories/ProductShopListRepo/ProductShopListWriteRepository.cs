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
    public class ProductShopListWriteRepository : WriteRepository<ProductShopList>, IProductShopListWriteRepository
    {
        private readonly ProjShoppingListMsDbContext _context;
        public ProductShopListWriteRepository(ProjShoppingListMsDbContext context) : base(context) => _context = context;


        public async Task<bool> HardRemoveByProductIdAsync(string productId)
        {
            var removedList = await Task.Run(() => _context.ProductShopList.Where(w => w.ProductId == productId).ToList());
            _context.RemoveRange(removedList);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> HardRemoveByShopListIdAsync(string shopListId)
        {
            var removedList = await Task.Run(() => _context.ProductShopList.Where(w => w.ShopListId == shopListId));
            _context.RemoveRange(removedList);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> SoftRemoveByProductIdAsync(string productId)
        {
            var removedList = await Task.Run(() => _context.ProductShopList.Where(w => w.ProductId == productId).ToList());
            foreach (var removedItem in removedList)
            {
                removedItem.IsActive = false;
            }
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> SoftRemoveByShopListIdAsync(string shopListId)
        {
            var removedList = await Task.Run(() => _context.ProductShopList.Where(w => w.ShopListId == shopListId));
            foreach (var removedItem in removedList)
            {
                removedItem.IsActive = false;
            }
            _context.SaveChanges();
            return true;
        }
    }
}
