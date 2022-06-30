using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Consts.Messages.ValidationMessages
{
    public static class ProductValidationMessages
    {
        public static string ShopListIdControl { get; set; } = "Please select shop list correctly";
        public static string IdControl { get; set; } = "Please select product correctly";
        public static string NameNotEmpty { get; set; } = "Please fill name area";
        public static string LengthName { get; set; } = "Please enter 3-200 charakters";
        public static string MinPrice { get; set; } = "Please enter greater than 0";
    }
}
