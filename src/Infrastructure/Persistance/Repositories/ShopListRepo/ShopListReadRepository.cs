using Application.Common.Models;
using Application.Common.Repositories.ShopListRepo;
using Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination;
using Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories.ShopListRepo
{
    public class ShopListReadRepository : ReadRepository<ShopList>, IShopListReadRepository
    {
        private readonly ProjShoppingListMsDbContext _context;
        private readonly IDistributedCache _distributedCache;
        public ShopListReadRepository(ProjShoppingListMsDbContext context, IDistributedCache distributedCache) : base(context)
        {
            _distributedCache = distributedCache;
            _context = context;
        }

        public List<GetAllShopListsQueryResponse> ConvertToResponse(List<ShopListDto> list)
        {
            var convertedList = new List<GetAllShopListsQueryResponse>();
            foreach (var item in list)
            {
                var categoryName = _context.Categories.SingleOrDefault(f => f.Id == item.CategoryId).Name;
                convertedList.Add(new GetAllShopListsQueryResponse { Title = item.Title, CategoryName = categoryName, Description = item.Description });
            }
            return convertedList;
        }

        public List<GetAllUsersShopListsByCategoryQueryResponse> ConvertToResponse(string overloader = "", List<ShopListDto> list = null)
        {
            var convertedList = new List<GetAllUsersShopListsByCategoryQueryResponse>();
            foreach (var item in list)
            {
                var categoryName = _context.Categories.SingleOrDefault(f => f.Id == item.CategoryId).Name;
                convertedList.Add(new GetAllUsersShopListsByCategoryQueryResponse { Title = item.Title, CategoryName = categoryName, Description = item.Description });
            }
            return convertedList;
        }

        public async Task<List<ShopList>> GetAllCacheAsync(string cacheKey)
        {
            var cache = await _distributedCache.GetAsync(cacheKey);
            string json;
            List<ShopList> cachedList;
            if (cache != null)
            {
                json = Encoding.UTF8.GetString(cache);
                cachedList = JsonConvert.DeserializeObject<List<ShopList>>(json);
            }
            else
            {
                cachedList = _context.ShopLists.OrderBy(o => o.UserId).ToList();
                json = JsonConvert.SerializeObject(cachedList);
                cache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1))
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, cache, options);
            }
            return cachedList;
        }

        public async Task<List<ShopList>> GetAllShopListsByUserIdAsync(string userId, PaginatedParameters paginatedParameters)
        {
            var result = PaginatedList<ShopList>.ToPagedList(_context.ShopLists.Where(w => w.UserId == userId), paginatedParameters.PageNumber, paginatedParameters.PageSize);
            return result;
        }

        public async Task<List<ShopList>> GetAllUsersShopListsByCategoryIdAsync(string categoryId, string userId, PaginatedParameters paginatedParameters)
        {
            var result = PaginatedList<ShopList>.ToPagedList(_context.ShopLists.Where(w => w.UserId == userId && w.CategoryId == categoryId), paginatedParameters.PageNumber, paginatedParameters.PageSize);
            return result;
        }

        public async Task<ShopList> GetAllWithProductsAsync(Expression<Func<ShopList, bool>> predicate = null, params Expression<Func<ShopList, object>>[] includeProperties)
        {
            IQueryable<ShopList> query = null;
            if (predicate != null)
            {
                query = _context.ShopLists.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync();
        }
    }
}
