using EventSphere.Identity.Application.Models.Authentication;
using EventSphere.Identity.Application.Models.OperationClaims;
using EventSphere.Identity.Domain.Entities;

namespace EventSphere.Identity.Application.Common.Interfaces.Authentication
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaimDto> operationClaimDtoList);
    }
}
