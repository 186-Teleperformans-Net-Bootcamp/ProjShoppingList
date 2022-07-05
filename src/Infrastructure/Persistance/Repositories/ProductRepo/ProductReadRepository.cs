using Application.Common.Interfaces;
using Application.Common.Models;
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
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        private readonly ProjShoppingListMsDbContext _context;
        public ProductReadRepository(ProjShoppingListMsDbContext context) : base(context) => _context = context;

        public async Task<List<Product>> GetAllProductsInShopListAsync(string shopListId,PaginatedParameters paginatedParameters)
        {
            var list = _context.Products.Where(w => w.ShopListId == shopListId);
            var result = PaginatedList<Product>.ToPagedList(list, paginatedParameters.PageNumber, paginatedParameters.PageSize);
            return result;
        }
    }
}
