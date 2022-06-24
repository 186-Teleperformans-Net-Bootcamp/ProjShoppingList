using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductShopList : BaseEditableEntity
    {
        public Product Product { get; set; }
        [ForeignKey("ProductId")]
        public string ProductId { get; set; }

        public ShopList ShopList { get; set; }
        [ForeignKey("ShopListId")]
        public string ShopListId { get; set; }
        public int Amount { get; set; }
        public bool IsBuy { get; set; }
        public bool IsActive { get; set; }
    }
}
