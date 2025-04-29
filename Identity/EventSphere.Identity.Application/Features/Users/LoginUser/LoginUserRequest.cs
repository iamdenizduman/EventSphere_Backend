using EventSphere.Core.Result;
using MediatR;

namespace EventSphere.Identity.Application.Features.Users.LoginUser
{
    public class LoginUserRequest : IRequest<DataResult<LoginUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
