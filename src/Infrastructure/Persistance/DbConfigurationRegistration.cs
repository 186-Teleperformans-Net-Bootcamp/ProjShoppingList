using Infrastructure.Identity;
using Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public static class DbConfigurationRegistration
    {
        public static void AddDbServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ProjShoppingListMsDbContext>(options => options.UseSqlServer(configuration["SQLSERVER:ConnectionStrings"]));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjShoppingListMsDbContext>().AddDefaultTokenProviders();
        }
    }
}
