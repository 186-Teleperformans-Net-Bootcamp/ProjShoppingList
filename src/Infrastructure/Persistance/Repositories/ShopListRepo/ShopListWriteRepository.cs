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


        public bool AddProductToListAsync(string id, Product product,int amount=1)
        {
            var list = _context.ShopLists.FirstOrDefault(f => f.Id == id);
            ProductShopList productShopList = new()
            {
                Amount = amount,
                ShopListId = id,
                ProductId = product.Id,
            };
            list.ProductShopList.Add(productShopList);
            _context.SaveChanges();
            return true;
        }

        public bool AddRangeProductToListAsync(string id, List<ProductShopList> products)
        {
            var list = _context.ShopLists.FirstOrDefault(f => f.Id == id);
            foreach (var product in products)
            {
                ProductShopList productShopList = new()
                {
                    Amount = product.Amount,
                    ShopListId = id,
                    ProductId = product.Id,
                };
                list.ProductShopList.Add(productShopList);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
