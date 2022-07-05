using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<CommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; }
    }
}
