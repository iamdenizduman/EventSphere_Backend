using EventSphere.Identity.Application.Common.Models.Authentication;
using EventSphere.Identity.Domain.Entities;

namespace EventSphere.Identity.Application.Common.Interfaces.Authentication
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, OperationClaimListDto operationClaimListDto);
    }
}
