using EventSphere.EventService.Application.Features.Events.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.EventService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
