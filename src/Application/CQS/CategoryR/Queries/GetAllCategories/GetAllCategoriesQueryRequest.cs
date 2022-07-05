using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
