using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEditableEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> models);
        Task<bool> UpdateAsync(T entity);
        bool Update(T model);
        Task<bool> HardRemoveAsync(T model);
        Task<bool> HardRemoveAsync(string id);
        Task<bool> SoftRemoveAsync(T model);
        Task<bool> SoftRemoveAsync(string id);
        bool Remove(T model);
        bool RemoveRange(List<T> models);
        Task<int> SaveAsync();
    }
}
