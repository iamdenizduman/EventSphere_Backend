using EventSphere.Core.Result;
using EventSphere.Identity.Application.Common.Interfaces.Authentication;
using EventSphere.Identity.Application.Common.Interfaces.Security;
using EventSphere.Identity.Application.Models.OperationClaims;
using EventSphere.Identity.Domain.Repositories;
using MediatR;

namespace EventSphere.Identity.Application.Features.Users.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, DataResult<LoginUserResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IHashingHelper _hashingHelper;

        public LoginUserHandler(IUserReadRepository userReadRepository, IUserOperationClaimReadRepository userOperationClaimReadRepository, ITokenHelper tokenHelper, IHashingHelper hashingHelper)
        {
            _userReadRepository = userReadRepository;
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _tokenHelper = tokenHelper;
            _hashingHelper = hashingHelper;
        }

        public async Task<DataResult<LoginUserResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetSingleAsync(u => u.Email == request.Email, u => u.UserOperationClaims);
            if (user == null)
                return new DataResult<LoginUserResponse>(null, Core.Enums.ResultStatus.Error, "Kullanıcı adı veya şifre hatalı");

            bool passwordCheck = _hashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

            if (!passwordCheck)
                return new DataResult<LoginUserResponse>(null, Core.Enums.ResultStatus.Error, "Kullanıcı adı veya şifre hatalı");

            var userClaims = (await _userReadRepository.GetUserWithClaimsAsync(request.Email))?.UserOperationClaims.Select(uoc => new OperationClaimDto
            {
                Name = uoc.OperationClaim.Name
            })?.ToList();           
           
            var accessToken = _tokenHelper.CreateToken(user, userClaims);

            var loginResponse = new LoginUserResponse
            {
                Token = accessToken
            };

            return new DataResult<LoginUserResponse>(loginResponse, Core.Enums.ResultStatus.Success);
        }
    }
}
