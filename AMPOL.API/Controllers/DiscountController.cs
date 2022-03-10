
using AMPOL.Application.Commands;
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
    public class DiscountCalculatorController : ControllerBase
    {
        private readonly ILogger<DiscountCalculatorController> _logger;
        private readonly IMediator _mediator;

        public DiscountCalculatorController(ILogger<DiscountCalculatorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CalculationDiscount(CalculateDiscountCommand request)
        {
            return Ok(await _mediator.Send(request));            
        }


    }
}
