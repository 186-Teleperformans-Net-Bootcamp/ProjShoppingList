using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.RemoveProduct
{
    public class SoftRemoveProductCommandRequest : IRequest<CommandResponse>
    {
        public string Id { get; set; }
    }
}
