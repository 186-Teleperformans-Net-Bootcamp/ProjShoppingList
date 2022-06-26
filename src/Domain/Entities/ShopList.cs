using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShopList : BaseEntity
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public IList<ProductShopList> ProductShopList { get; set; }

    }
}
