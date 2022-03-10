using AMPOL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.DTOs
{
    public class BasketGroupByCategoryDto
    {
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public decimal PointsPerDollar { get; set; }
        public decimal TotalPoints { get; set; }

    }
}
