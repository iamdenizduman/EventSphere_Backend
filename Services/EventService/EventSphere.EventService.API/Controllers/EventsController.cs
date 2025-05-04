using EventSphere.EventService.Application.Features.Events.CreateEvent;
using EventSphere.EventService.Application.Features.Events.GetEventById;
using EventSphere.EventService.Application.Features.Events.GetEvents;
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

        [HttpPost(nameof(CreateEvent))]
        public async Task<IActionResult> CreateEvent(CreateEventRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost(nameof(GetEvents))]
        public async Task<IActionResult> GetEvents(GetEventsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost(nameof(GetEventById))]
        public async Task<IActionResult> GetEventById(GetEventByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
