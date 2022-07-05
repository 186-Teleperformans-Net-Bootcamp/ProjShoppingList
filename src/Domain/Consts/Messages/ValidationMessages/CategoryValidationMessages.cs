using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Consts.Messages.ValidationMessages
{
    public static class CategoryValidationMessages
    {
        public static string NameNotEmpty { get; set; } = "Please fill name area";

        public static string NameMaxLength { get; set; } = "please enter 3-200 characters.";

        public static string NameUnique { get; set; } = "Category name is exist, please chose another name";

        //Description
        public static string DescriptionNotEmpty { get; set; } = "Please fill Description area";

        public static string DescriptionMaxLength { get; set; } = "please enter 3-200 characters.";
    }
}
