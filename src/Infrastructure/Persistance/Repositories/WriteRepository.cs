using Application.Common.Repositories;
using Domain.Common;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ProjShoppingListMsDbContext _context;

        public WriteRepository(ProjShoppingListMsDbContext context) => _context = context;


        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await _context.AddRangeAsync(models);
            _context.SaveChanges();
            return true;
        }

        public Task<bool> Any()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            _context.Remove(model);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveAsync(T model)
        {
            var result = await Task.Run(() => _context.Remove(model));
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? entity = await Table.FirstOrDefaultAsync(f => f.Id == id);
            return Remove(entity);
        }

        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry=Table.Update(model);
            return entityEntry.State==EntityState.Modified;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Task.Run(() => Table.Update(entity));
            return entityEntry.State == EntityState.Modified;
        }
    }
}
