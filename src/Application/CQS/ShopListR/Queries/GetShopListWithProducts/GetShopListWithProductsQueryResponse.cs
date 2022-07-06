using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetShopListWithProducts
{
    public class GetShopListWithProductsQueryResponse
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public IList<ProductDto> Products { get; set; }
       
    }
}
