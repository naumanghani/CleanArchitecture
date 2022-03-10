using AMPOL.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Domain.Entities
{
    public class DiscountPromotion: Promotion
    {
        public string DiscountPromotionId { get; set; }
        public decimal DiscountPercent { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
