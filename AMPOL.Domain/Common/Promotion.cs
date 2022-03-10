using System;
using System.Collections.Generic;
using System.Text;

namespace AMPOL.Domain.Common
{
    public class Promotion
    { 
        public string PromotionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
