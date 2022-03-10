using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.DTOs
{
    public class CalculateDiscountResponseDto
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PointsEarned { get; set; }

    }
}
