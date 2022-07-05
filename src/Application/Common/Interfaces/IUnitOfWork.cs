using Application.Common.Repositories.CategoryRepo;
using Application.Common.Repositories.ProductRepo;
using Application.Common.Repositories.ShopListRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }
        ICategoryReadRepository CategoryReadRepository { get; }
        ICategoryWriteRepository CategoryWriteRepository { get; }
        IShopListReadRepository ShopListReadRepository { get; }
        IShopListWriteRepository ShopListWriteRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
