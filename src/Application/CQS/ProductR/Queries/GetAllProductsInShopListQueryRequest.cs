using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Queries
{
    public class GetAllProductsInShopListQueryRequest : IRequest<PaginatedList<GetAllProductsInShopListQueryResponse>>
    {
        public string ShopListId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
