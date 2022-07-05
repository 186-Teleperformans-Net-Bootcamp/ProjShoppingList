using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddShopListAdmin
{
    public class AddShopListAdminCommandRequest : IRequest<CommandResponse>
    {
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Descripiton { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UserId { get; set; }

    }
}
