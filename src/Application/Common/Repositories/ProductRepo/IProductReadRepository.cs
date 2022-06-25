using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ProductRepo
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        Task<List<Product>> GetAllWithPaginationAsync(PaginatedParameters paginatedParameters);

    }
}
