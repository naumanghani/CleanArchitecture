using AMPOL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMPOL.Domain.Entities
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Category Category { get; set; }
        public ICollection<DiscountPromotion> DiscountPromotions { get; set; }
    }
}
