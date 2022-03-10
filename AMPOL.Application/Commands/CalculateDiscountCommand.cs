using AMPOL.Application.Common.Exceptions;
using AMPOL.Application.Common.Interfaces;
using AMPOL.Application.Common.Mapping;
using AMPOL.Application.DTOs;
using AMPOL.Application.Services;
using AMPOL.Domain.Entities;
using AMPOL.Domain.Enums;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMPOL.Application.Commands
{
    public class CalculateDiscountCommand : IRequest<CalculateDiscountResponseDto>
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<CalculateDiscountCommandChild> Basket { get; set; }
    }

    public class CalculateDiscountCommandHandler : IRequestHandler<CalculateDiscountCommand, CalculateDiscountResponseDto>
    {
        
        private readonly IMapper _mapper;
        private readonly IProductService _calculateDiscountService;

        public CalculateDiscountCommandHandler(IMapper mapper, IProductService calculateDiscountService)
        {            
            _mapper = mapper;
            _calculateDiscountService = calculateDiscountService;
        }

        public async Task<CalculateDiscountResponseDto> Handle(CalculateDiscountCommand request, CancellationToken cancellationToken)
        {
            List<string> productIds = request.Basket.Select(b => b.ProductId)
                                                    .ToList();
            var productEntities = await _calculateDiscountService.GetProductDiscountPromotions(productIds);
       
            List<ProductDto> products = _mapper.Map<List<ProductDto>>(productEntities);
            ValidateProductIds(productIds, 
                               products.Select(p => p.ProductId).ToList()
                               );
            
            CalculateDiscountResponseDto resp = new CalculateDiscountResponseDto()
            {
                CustomerId = request.CustomerId,
                LoyaltyCard = request.LoyaltyCard,
                TransactionDate = request.TransactionDate,
            };

            resp.PointsEarned = await CalculatePointsEarned(request, 
                                                            products);                        
            resp.TotalAmount = request.Basket.Sum(p=> Math.Round(p.UnitPrice * p.Quantity,2));
            resp.DiscountApplied = CalculateDiscount(request, 
                                                     products); 
            resp.GrandTotal = resp.TotalAmount - resp.DiscountApplied;
            return resp;
        }
        private bool ValidateProductIds(List<string> productIds, 
                                        List<string> products)
        {
            List<string> inValidProductIds = productIds.Except(products).ToList();
            if (inValidProductIds.Count() == 0)
            {
                return true;
            }
            throw new NotFoundException($"{inValidProductIds.Count()} Product Id(s) not found ({String.Join(",",inValidProductIds)}).");            
        }
        private async Task<decimal> CalculatePointsEarned(CalculateDiscountCommand request, 
                                                          List<ProductDto> basketProducts)
        {
            var pointsPromotion = await _calculateDiscountService.GetPointsPromotions();

            var basketWithCategory = (from entity in basketProducts
                                      join product in request.Basket on entity.ProductId.Trim() equals product.ProductId
                                      select new
                                      {
                                          ProductId = product.ProductId,
                                          Amount = product.Quantity * product.UnitPrice,
                                          Category = entity.Category
                                      }).ToList();

            List<CategoryWisePointsPerDollarDto> basketSummaryCategoryWise = basketWithCategory
                                                                              .GroupBy(g => g.Category)
                                                                              .Select(g => new CategoryWisePointsPerDollarDto
                                                                              {
                                                                                  Category = g.Key,
                                                                                  TotalAmount = g.Sum(b => b.Amount)
                                                                              }).ToList();

            foreach (var productCategory in basketSummaryCategoryWise)
            {
                productCategory.PointsPerDollar = pointsPromotion.Where(p => (p.Category == productCategory.Category || p.Category == Category.Any) &&
                                                                                            request.TransactionDate >= p.StartDate &&
                                                                                            request.TransactionDate <= p.EndDate)
                                                                                .OrderByDescending(p => p.PointsPerDollar)
                                                                                .Select(p => p.PointsPerDollar)
                                                                                .FirstOrDefault();
            }
            return Math.Round(basketSummaryCategoryWise.Sum(p => (decimal)(p.TotalAmount * p.PointsPerDollar)),2);
        }

        private decimal CalculateDiscount(CalculateDiscountCommand request, 
                                                                                           List<ProductDto> basketProducts)
        {
            List<ProductDiscountDto> productDiscounts = (from entity in basketProducts
                                                          join product in request.Basket on entity.ProductId.Trim() equals product.ProductId
                                                          select new ProductDiscountDto
                                                          {
                                                              ProductId = product.ProductId,
                                                              Amount = product.Quantity * product.UnitPrice,
                                                              DiscountPercent = entity.DiscountPromotions.Where(d=> request.TransactionDate >= d.StartDate &&
                                                                                                                    request.TransactionDate <= d.EndDate)
                                                                                                         .OrderByDescending(d=> d.DiscountPercent)
                                                                                                         .Select(d=> d.DiscountPercent)
                                                                                                         .FirstOrDefault()
                                                          }).ToList();            

            return Math.Round(productDiscounts.
                                Sum(p => Math.Round(p.Amount * (p.DiscountPercent / 100), 2))
                              , 2);
        }
    }
}
