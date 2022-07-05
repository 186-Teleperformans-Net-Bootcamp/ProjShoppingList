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
        public string Title { get; set; }
        public string UserId { get; set; }
        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public IList<Product> Products { get; set; }

    }
}
