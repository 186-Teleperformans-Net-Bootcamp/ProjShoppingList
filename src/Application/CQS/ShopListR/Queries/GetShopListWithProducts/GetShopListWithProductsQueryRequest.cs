using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetShopListWithProducts
{
    public class GetShopListWithProductsQueryRequest:IRequest<GetShopListWithProductsQueryResponse>
    {
        public string ShopListId { get; set; }
    }
}
