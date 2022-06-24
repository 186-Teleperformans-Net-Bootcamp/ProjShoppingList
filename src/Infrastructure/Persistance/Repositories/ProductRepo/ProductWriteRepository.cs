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
        public ProductWriteRepository(ProjShoppingListMsDbContext context) : base(context) => _context = context;


        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updatedProduct = await Task.Run(() => _context.Products.SingleOrDefault(p => p.Id == product.Id));
            
            updatedProduct.Name = updatedProduct.Name == product.Name ? _ = updatedProduct.Name : updatedProduct.Name = product.Name;

            updatedProduct.Description = updatedProduct.Description == product.Description ? _ = updatedProduct.Description : updatedProduct.Description = product.Description;

            updatedProduct.Price = updatedProduct.Price == product.Price ? _ = updatedProduct.Price : updatedProduct.Price = product.Price;

            updatedProduct.StockAmount = updatedProduct.StockAmount == product.StockAmount ? _ = updatedProduct.StockAmount : updatedProduct.StockAmount = product.StockAmount;

            updatedProduct.CategoryId = updatedProduct.CategoryId == product.CategoryId ? _ = updatedProduct.CategoryId : updatedProduct.CategoryId = product.CategoryId;

            updatedProduct.IsActive = updatedProduct.IsActive == product.IsActive ? _ = updatedProduct.IsActive : updatedProduct.IsActive = product.IsActive;

            updatedProduct.Unit = updatedProduct.Unit == product.Unit ? _ = updatedProduct.Unit : updatedProduct.Unit = product.Unit;

            _context.SaveChanges();
            return true;
        }
    }
}
