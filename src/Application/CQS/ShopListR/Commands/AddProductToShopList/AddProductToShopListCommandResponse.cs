using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddProductToShopList
{
    public class AddProductToShopListCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
    }
}
