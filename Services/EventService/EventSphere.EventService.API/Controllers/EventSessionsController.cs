using EventSphere.EventService.Application.Features.EventSessions.CreateEventSession;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.EventService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSessionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventSessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(CreateEventSession))]
        public async Task<IActionResult> CreateEventSession(CreateEventSessionRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
