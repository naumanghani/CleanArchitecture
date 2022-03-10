﻿using AMPOL.Application.Commands;
using AMPOL.Application.Common.Interfaces;
using AMPOL.Application.DTOs;
using AMPOL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.Services
{


    public class ProductService: IProductService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public ProductService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Product>> GetProductDiscountPromotions(List<string> productIds)
        {
            return await _applicationDbContext.Products
                                          .Include(p => p.DiscountPromotions)
                                          .Where(p => productIds.Contains(p.ProductId.Trim()))
                                          .AsNoTracking()
                                          .ToListAsync();
        }

        public async Task<List<PointsPromotion>> GetPointsPromotions()
        {
            return  await _applicationDbContext.PointsPromotions
                              .AsNoTracking()
                              .ToListAsync();

        }
    }
}
