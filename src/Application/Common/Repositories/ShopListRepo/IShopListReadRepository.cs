using Application.Common.Interfaces;
using Application.Common.Models;
using Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination;
using Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory;
using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ShopListRepo
{
    public  interface IShopListReadRepository:IReadRepository<ShopList>, IRedisCacheService<ShopList>
    {
        Task<List<ShopList>> GetAllShopListsByUserIdAsync(string userId,PaginatedParameters paginatedParameters);
        Task<List<ShopList>> GetAllUsersShopListsByCategoryIdAsync(string categoryId,string userId, PaginatedParameters paginatedParameters);
        List<GetAllShopListsQueryResponse> ConvertToResponse(List<ShopListDto> list);
        List<GetAllUsersShopListsByCategoryQueryResponse> ConvertToResponse(string overloader,List<ShopListDto> list);
        Task<ShopList> GetAllWithProductsAsync(Expression<Func<ShopList, bool>> predicate = null, params Expression<Func<ShopList, object>>[] includeProperties);
    }
}
