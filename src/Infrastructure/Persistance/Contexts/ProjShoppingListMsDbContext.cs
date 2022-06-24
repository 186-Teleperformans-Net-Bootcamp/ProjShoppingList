using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Contexts
{
    public class ProjShoppingListMsDbContext : IdentityDbContext<AppUser, AppRole, string>, IProjShoppingListDbContext
    {
        public ProjShoppingListMsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<ProductShopList> ProductShopList { get; set; }

        //INTERCEPTORS
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEditableEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.ModifiedDate = DateTime.UtcNow
                };

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEditableEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        data.Entity.ModifiedDate = DateTime.UtcNow;

                        break;
                    default:
                        break;
                }

            }
            return base.SaveChanges();
        }
        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEditableEntity>();

            foreach (var data in datas)
            {
                data.Entity.Id = Guid.NewGuid().ToString();
            }
            return base.AddAsync(entity, cancellationToken);
        }
    }
}
