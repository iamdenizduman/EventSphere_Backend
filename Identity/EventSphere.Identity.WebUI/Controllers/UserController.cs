using EventSphere.Identity.Application.Features.Users.LoginUser;
using EventSphere.Identity.Application.Features.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSphere.Identity.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(LoginUser))]
        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(nameof(RegisterUser))]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
