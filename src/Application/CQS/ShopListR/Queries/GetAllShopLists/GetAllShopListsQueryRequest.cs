using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopLists
{
    public class GetAllShopListsQueryRequest : IRequest<List<GetAllShopListsQueryResponse>>
    {
    }
}
