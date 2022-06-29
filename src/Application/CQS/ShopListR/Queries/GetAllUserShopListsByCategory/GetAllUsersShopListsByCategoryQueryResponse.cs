using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory
{
    public class GetAllUsersShopListsByCategoryQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
