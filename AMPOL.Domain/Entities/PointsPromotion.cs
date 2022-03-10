using AMPOL.Domain.Common;
using AMPOL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMPOL.Domain.Entities
{
    public class PointsPromotion: Promotion
    {
        public string PointsPromotionId { get; set; }
        public Category Category { get; set; }
        public string CategoryName => ((Category)this.Category).ToString();
        public decimal PointsPerDollar { get; set; }        
    }
}
