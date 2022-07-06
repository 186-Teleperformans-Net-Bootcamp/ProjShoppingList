using Application.Common.Interfaces;
using Application.Common.Repositories.ProductRepo;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories.ProductRepo
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        private readonly ProjShoppingListMsDbContext _context;
        private readonly MongoDbService _mongoDbService;
        public ProductWriteRepository(ProjShoppingListMsDbContext context, MongoDbService mongoDbService) : base(context, mongoDbService)
        {
            _context = context;
            _mongoDbService = mongoDbService;
        }

        public async Task<bool> BuyAllProductsByShopListIdAsync(string shopListId)
        {
            var products= await Task.Run(()=> _context.Products.Where(p => p.ShopListId == shopListId).ToList());
            if (products.Count>-1)
            {
                foreach (var product in products)
                {
                    product.IsBuy = true;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> BuyProductById(string productId)
        {
            var product = await Task.Run(() => _context.Products.SingleOrDefault(s => s.Id == productId));
            if (product!=null)
            {
                product.IsBuy = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updatedProduct = await Task.Run(() => _context.Products.SingleOrDefault(p => p.Id == product.Id));
            
            updatedProduct.Name = updatedProduct.Name == product.Name ? _ = updatedProduct.Name : updatedProduct.Name = product.Name;

            updatedProduct.Price = updatedProduct.Price == product.Price ? _ = updatedProduct.Price : updatedProduct.Price = product.Price;

            updatedProduct.IsActive = updatedProduct.IsActive == product.IsActive ? _ = updatedProduct.IsActive : updatedProduct.IsActive = product.IsActive;

            updatedProduct.Unit = updatedProduct.Unit == product.Unit ? _ = updatedProduct.Unit : updatedProduct.Unit = product.Unit;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
