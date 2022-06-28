using Application.Common.Interfaces;
using Domain.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Contexts
{
    public class ProjShoppingListPostgreSqlDbContext : DbContext, IProjShoppingListAdminDbContext
    {
        public ProjShoppingListPostgreSqlDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<CompletedList> CompletedLists { get; set; }
    }
}
