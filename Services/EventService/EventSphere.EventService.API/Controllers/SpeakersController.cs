using EventSphere.EventService.Application.Features.Speaker.CreateSpeaker;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.EventService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpeakersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(CreateSpeaker))]
        public async Task<IActionResult> CreateSpeaker(CreateSpeakerRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
