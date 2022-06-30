using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Consts.Messages.ValidationMessages
{
    public static class ShopListValidationMessages
    {
        public static string IdControl { get; set; } = "Please select shopping list correctly";
        public static string TitleNotEmpty { get; set; } = "Please fill title area";
        public static string TitleLength { get; set; } = "Please enter 3-200 characters";
        public static string CategoryIdControl { get; set; } = "Please select category correctly";
    }
}
