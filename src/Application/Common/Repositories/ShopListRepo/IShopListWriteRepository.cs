using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ShopListRepo
{
    public interface IShopListWriteRepository : IWriteRepository<ShopList>
    {
        Task<bool> CompleteAsync(string id);
        Task<bool> AddShopListAdminAsync(ShopList shopList);
    }
}
