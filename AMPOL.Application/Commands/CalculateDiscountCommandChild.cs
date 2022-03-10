using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.Commands
{
    public class CalculateDiscountCommandChild
    {
        public string ProductId { get; set; }
        public decimal UnitPrice  { get; set; }
        public decimal Quantity { get; set; }
    }
}
