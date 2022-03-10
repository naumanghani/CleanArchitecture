using AMPOL.Application.Common.Interfaces;
using AMPOL.Application.DTOs;
using AMPOL.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AMPOL.Application.Queries
{
    public class GetPointsPromotionsQuery: IRequest<List<PointsPromotionDto>>
    {
    }
    public class GetPointsPromotionsQueryHanlder : IRequestHandler<GetPointsPromotionsQuery, List<PointsPromotionDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetPointsPromotionsQueryHanlder(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<List<PointsPromotionDto>> Handle(GetPointsPromotionsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _applicationDbContext
                                    .PointsPromotions                                    
                                    .AsNoTracking()
                                    .ToListAsync();

            return _mapper.Map<List<PointsPromotionDto>>(entities);
        }
    }
}
