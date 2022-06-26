using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllProductsInShopList
{
    public class GetAllProductsInShopListQueryRequest:IRequest<List<GetAllProductsInShopListQueryResponse>>
    {
        public string Id { get; set; }
    }
}
