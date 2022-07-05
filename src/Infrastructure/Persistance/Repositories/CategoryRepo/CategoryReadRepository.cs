using Application.Common.Repositories.CategoryRepo;
using Domain.Entities;
using Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories.CategoryRepo
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(ProjShoppingListMsDbContext context) : base(context)
        {
        }
    }
}
