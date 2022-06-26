using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Commands.RemoveCategory
{
    public class RemoveCategoryCommandRequest : IRequest<CommandResponse>
    {
        public string Id { get; set; }
    }
}
