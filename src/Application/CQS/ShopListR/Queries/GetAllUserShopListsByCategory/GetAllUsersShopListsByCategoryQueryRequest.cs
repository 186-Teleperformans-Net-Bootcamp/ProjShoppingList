using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory
{
    public class GetAllUsersShopListsByCategoryQueryRequest: IRequest<PaginatedList<GetAllUsersShopListsByCategoryQueryResponse>>
    {
        public string UserId { get; set; }
        public string CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
