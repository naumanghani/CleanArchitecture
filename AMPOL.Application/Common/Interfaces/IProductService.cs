using AMPOL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPOL.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductDiscountPromotions(List<string> productIds);
        Task<List<PointsPromotion>> GetPointsPromotions();
    }
}
