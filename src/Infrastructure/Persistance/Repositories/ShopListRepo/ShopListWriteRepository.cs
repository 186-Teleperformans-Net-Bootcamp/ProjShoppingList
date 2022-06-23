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


        public bool AddProductToListAsync(string id, Product product)
        {
            var list = _context.ShopLists.FirstOrDefault(f => f.Id == id);
            list?.Products.Add(product);
            _context.SaveChanges();
            return true;
        }

        public bool AddRangeProductToListAsync(string id, List<Product> products)
        {
            var list = _context.ShopLists.FirstOrDefault(f => f.Id == id);
            foreach (var product in products)
            {
                list?.Products.Add(product);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
