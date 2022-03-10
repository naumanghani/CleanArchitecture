using AMPOL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.DTOs
{
    public class CategoryWisePointsPerDollarDto
    {
        public Category Category { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PointsPerDollar { get; set; }        
    }
}
