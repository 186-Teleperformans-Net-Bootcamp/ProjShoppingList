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
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        private readonly MongoDbService _mongoDbService;
        public CategoryWriteRepository(ProjShoppingListMsDbContext context, MongoDbService mongoDbService) : base(context,mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }
    }
}
