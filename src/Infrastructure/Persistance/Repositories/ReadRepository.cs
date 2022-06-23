using Application.Common.Interfaces;
using Application.Common.Repositories;
using Domain.Common;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ProjShoppingListMsDbContext _context;

        public ReadRepository(ProjShoppingListMsDbContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();


        public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();

        // I have to revize for validation 
        
        public async Task<T> GetByIdAsync(string id)
        {
            var result = await Table.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> condition)
        {
            var result = await Table.Where(condition).ToListAsync();
            return result;
        }
    }
}
