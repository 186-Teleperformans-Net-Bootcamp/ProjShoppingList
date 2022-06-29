using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEditableEntity
    {
        [ForeignKey("ShopListId")]
        public string ShopListId { get; set; }
        public ShopList ShopList { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public bool IsBuy { get; set; }
    }
}
