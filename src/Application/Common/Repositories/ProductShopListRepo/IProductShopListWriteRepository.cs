using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ProductShopListRepo
{
    public interface IProductShopListWriteRepository:IWriteRepository<ProductShopList>
    {
        Task<bool> HardRemoveByProductIdAsync(string productId);
        Task<bool> SoftRemoveByProductIdAsync(string productId);
        Task<bool> HardRemoveByShopListIdAsync(string shopListId);
        Task<bool> SoftRemoveByShopListIdAsync(string shopListId);
    }
}
