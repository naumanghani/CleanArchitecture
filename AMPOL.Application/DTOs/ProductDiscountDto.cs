using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.DTOs
{
    public class ProductDiscountDto
    {
        public string ProductId { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
    }
}
