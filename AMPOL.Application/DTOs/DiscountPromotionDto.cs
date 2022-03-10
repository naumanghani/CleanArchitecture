using AMPOL.Application.Common.Mapping;
using AMPOL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.DTOs
{
    public class DiscountPromotionDto: IMapFrom<DiscountPromotion>
    {
        public string DiscountPromotionId { get; set; }
        public decimal DiscountPercent { get; set; }
        public string PromotionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
