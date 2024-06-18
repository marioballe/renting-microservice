using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.Queries;

namespace RentingMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListVehicles()
        {
            var query = new ListVehiclesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("rent")]
        public async Task<IActionResult> RentVehicle(RentVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnVehicle(ReturnVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddVehicle(AddVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
