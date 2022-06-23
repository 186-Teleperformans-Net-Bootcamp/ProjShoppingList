using Application.Common.Interfaces;
using Application.Common.Repositories.CategoryRepo;
using Application.Common.Repositories.ProductRepo;
using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Repositories.CategoryRepo;
using Infrastructure.Persistance.Repositories.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjShoppingListMsDbContext _context;
        private ProductReadRepository _productReadRepository;
        private ProductWriteRepository _productWriteRepository;
        private CategoryReadRepository _categoryReadRepository;
        private CategoryWriteRepository _categoryWriteRepository;

        public UnitOfWork(ProjShoppingListMsDbContext context)
        {
            _context = context;
        }

        public IProductReadRepository ProductReadRepository => _productReadRepository ?? (_productReadRepository = new ProductReadRepository(_context));

        public IProductWriteRepository ProductWriteRepository => _productWriteRepository ?? (_productWriteRepository = new ProductWriteRepository(_context));

        public ICategoryReadRepository CategoryReadRepository => _categoryReadRepository ?? (_categoryReadRepository = new CategoryReadRepository(_context));

        public ICategoryWriteRepository CategoryWriteRepository => _categoryWriteRepository ?? (_categoryWriteRepository = new CategoryWriteRepository(_context));  

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
