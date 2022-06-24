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
        bool AddProductToListAsync(string id,Product product,int amount=1);
        bool AddRangeProductToListAsync(string id,List<ProductShopList> products);
    }
}
