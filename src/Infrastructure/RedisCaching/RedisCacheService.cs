using Application.Common.Interfaces;
using Application.Common.Repositories;
using Domain.Common;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RedisCaching
{
    public class RedisCacheService<T> : IRedisCacheService<T> where T : BaseEditableEntity
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ProjShoppingListMsDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public RedisCacheService(ProjShoppingListMsDbContext context,IDistributedCache distributedCache)  
        {
            _distributedCache = distributedCache;
            _context = context;
        }


        public async Task<List<T>> GetAllCacheAsync(string cacheKey)
        {
            var cache = await _distributedCache.GetAsync(cacheKey);
            string json;
            List<T> cachedList;
            if (cache != null)
            {
                json = Encoding.UTF8.GetString(cache);
                cachedList = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                cachedList = await Table.ToListAsync();
                json = JsonConvert.SerializeObject(cachedList);
                cache= Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1)) 
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, cache, options);
            }
            return cachedList;
        }
    }
}
