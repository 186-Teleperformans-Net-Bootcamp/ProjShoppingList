using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ShopListRepo
{
    public  interface IShopListReadRepository:IReadRepository<ShopList>
    {
        Task<List<ShopList>> GetAllWithPaginationAsync(string userId,PaginatedParameters paginatedParameters);
    }
}
