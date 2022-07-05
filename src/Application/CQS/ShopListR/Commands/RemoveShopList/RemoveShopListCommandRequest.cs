using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.RemoveShopList
{
    public class RemoveShopListCommandRequest : IRequest<CommandResponse>
    {
        public string Id { get; set; }
    }
}
