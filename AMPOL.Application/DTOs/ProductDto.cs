using AutoMapper;
using AMPOL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMPOL.Application.Common.Mapping;
using AMPOL.Domain.Enums;
using AMPOL.Application.DTOs;

namespace AMPOL.Application.DTOs
{
    public class ProductDto: IMapFrom<Product>
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Category Category { get; set; }
        public List<DiscountPromotionDto> DiscountPromotions{ get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                   .ForMember(d=> d.ProductId, opt=> opt.MapFrom(src=> src.ProductId.Trim()));
        }
    }
}
