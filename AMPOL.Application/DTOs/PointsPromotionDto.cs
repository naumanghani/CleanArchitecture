using AMPOL.Application.Common.Mapping;
using AMPOL.Domain.Entities;
using AMPOL.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.DTOs
{
    public class PointsPromotionDto: IMapFrom<PointsPromotion>
    {
        public string PointsPromotionId { get; set; }
        public Category Category { get; set; }
        public string CategoryName => ((Category)this.Category).ToString();
        public decimal PointsPerDollar { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PointsPromotion, PointsPromotionDto>();
        }
    }
}
