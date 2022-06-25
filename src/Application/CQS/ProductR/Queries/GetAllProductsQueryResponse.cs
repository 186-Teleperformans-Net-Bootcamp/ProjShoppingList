using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Queries
{
    public class GetAllProductsQueryResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public UnitProduct Unit { get; set; }
    }
}
