using AMPOL.Application.Common.Interfaces;
using AMPOL.Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMPOL.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
    }

    public class GetCategoriesQueryHanlder : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetCategoriesQueryHanlder(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _applicationDbContext
                                    .Products
                                    .Include(p => p.DiscountPromotions)
                                    .AsNoTracking()
                                    .ToListAsync();

            return _mapper.Map<List<ProductDto>>(entities);
        }
    }
}
