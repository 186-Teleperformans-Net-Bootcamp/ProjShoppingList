using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyAllProducts
{
    public class BuyAllProductsCommandRequest : IRequest<CommandResponse>
    {
        public string ShopListId { get; set; }
    }
}
