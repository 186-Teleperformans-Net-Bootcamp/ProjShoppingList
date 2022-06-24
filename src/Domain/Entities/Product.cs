using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public UnitProduct Unit { get; set; }
        public int StockAmount { get; set; }
        public bool IsExist { get; set; } = true;
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<ProductShopList> ProductShopList { get; set; }
    }
}
