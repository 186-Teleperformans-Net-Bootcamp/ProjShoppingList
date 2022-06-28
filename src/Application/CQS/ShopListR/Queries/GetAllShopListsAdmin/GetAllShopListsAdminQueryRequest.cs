using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopListsAdmin
{
    public class GetAllShopListsAdminQueryRequest : IRequest<PaginatedList<GetAllShopListsAdminQueryResponse>>
    {
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }
}
