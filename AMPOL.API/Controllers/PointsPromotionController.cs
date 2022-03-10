
using AMPOL.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMPOL.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PointsPromotionController : ControllerBase
    {

        private readonly ILogger<PointsPromotionController> _logger;
        private readonly IMediator _mediator;

        public PointsPromotionController(ILogger<PointsPromotionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetPointsPromotionsQuery()));            
        }


    }
}
