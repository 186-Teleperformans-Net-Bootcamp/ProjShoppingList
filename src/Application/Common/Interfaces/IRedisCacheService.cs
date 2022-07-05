using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRedisCacheService<T> where T : BaseEditableEntity
    {
        Task<List<T>> GetAllCacheAsync(string cacheKey);
        DbSet<T> Table { get; }
    }
}
