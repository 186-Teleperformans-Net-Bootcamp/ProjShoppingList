using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopLists
{
    public class GetAllShopListsQueryResponse
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
