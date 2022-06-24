using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddProductToShopList
{
    public class AddProductToShopListCommandRequest : IRequest<AddProductToShopListCommandResponse>
    {
        public string ShopListId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
}
