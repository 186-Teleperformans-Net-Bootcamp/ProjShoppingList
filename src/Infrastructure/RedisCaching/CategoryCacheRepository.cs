using Application.Common.Interfaces;
using Application.Common.Repositories.CategoryRepo;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RedisCaching
{
    public class CategoryCacheRepository : RedisCacheService<Category>, ICategoryCacheRepository
    {
        public CategoryCacheRepository(ProjShoppingListMsDbContext context, IDistributedCache distributedCache) : base(context, distributedCache)
        {
        }
    }
}
