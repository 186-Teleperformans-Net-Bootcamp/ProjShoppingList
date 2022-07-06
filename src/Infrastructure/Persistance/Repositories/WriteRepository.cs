using Application.Common.Interfaces;
using Application.Common.Repositories;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.MongoDbEntities;
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
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEditableEntity
    {
        private readonly ProjShoppingListMsDbContext _context;
        private readonly IMongoDbService _mongoDbService;

        public WriteRepository(ProjShoppingListMsDbContext context, IMongoDbService mongoDbService) => (_context,_mongoDbService)=(context,mongoDbService);


        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
            await Logger(entity, "update");
            return true;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await _context.AddRangeAsync(models);
            _context.SaveChanges();
            return true;
        }

        public bool Remove(T model)
        {
            _context.Remove(model);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> HardRemoveAsync(T model)
        {
            var result = await Task.Run(() => _context.Remove(model));
            return true;
        }

        public async Task<bool> HardRemoveAsync(string id)
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

        public async Task<bool> SoftRemoveAsync(T model)
        {
            var entity = await Table.FirstOrDefaultAsync(f => f.Id == model.Id);
            if (entity != null)
            {
                entity.IsActive = false;
                await SaveAsync();
                await Logger(entity, "update");
                return true;
            }
            else return false;
        }

        public async Task<bool> SoftRemoveAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(f => f.Id == id);
            if (entity != null)
            {
                entity.IsActive = false;
                _context.SaveChanges();
                await Logger(entity, "update");
                return true;
            }
            else return false;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            _context.SaveChanges();
            if (entityEntry != null)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Task.Run(() => Table.Update(entity));
            await _context.SaveChangesAsync();
            if (entityEntry.Entity != null)
            {
                await Logger(entity, "update");
                return true;
            }
            return false;
        }

        public async Task Logger(T entity, string operation)
        {
            Log log = new Log
            {
                Operation = operation,
                OperationDate = DateTime.Now,
                Type = entity.GetType().ToString(),
            };
            if (entity is ShopList)
            {
                log.UserId = ((ShopList)(object)entity).UserId;
            }
            await _mongoDbService.CreateAsync(log);
        }
    }
}
