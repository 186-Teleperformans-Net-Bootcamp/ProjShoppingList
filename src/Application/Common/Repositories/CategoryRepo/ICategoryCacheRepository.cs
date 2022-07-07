using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.CategoryRepo
{
    public interface ICategoryCacheRepository : IRedisCacheService<Category>
    {
    }
}
