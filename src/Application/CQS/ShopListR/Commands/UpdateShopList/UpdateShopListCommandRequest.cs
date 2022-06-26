using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.UpdateShopList
{
    public class UpdateShopListCommandRequest : IRequest<CommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
