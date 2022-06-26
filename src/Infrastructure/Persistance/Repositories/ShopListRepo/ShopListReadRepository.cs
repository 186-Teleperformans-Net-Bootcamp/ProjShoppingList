using Application.Common.Models;
using Application.Common.Repositories.ShopListRepo;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                cachedList =  _context.ShopLists.OrderBy(o=>o.UserId).ToList();
                json = JsonConvert.SerializeObject(cachedList);
                cache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1))
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, cache, options);
            }
            return cachedList;
        }

        public async Task<List<ShopList>> GetAllWithPaginationAsync(string userId, PaginatedParameters paginatedParameters)
        {
            var result = PaginatedList<ShopList>.ToPagedList(_context.ShopLists.Where(w => w.UserId == userId), paginatedParameters.PageNumber, paginatedParameters.PageSize);
            return result;
        }
    }
}
