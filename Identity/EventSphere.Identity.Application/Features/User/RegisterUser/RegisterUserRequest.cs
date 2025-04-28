using EventSphere.Core.Result;
using MediatR;

namespace EventSphere.Identity.Application.Features.User.RegisterUser
{
    public class RegisterUserRequest : IRequest<DataResult<RegisterUserResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
