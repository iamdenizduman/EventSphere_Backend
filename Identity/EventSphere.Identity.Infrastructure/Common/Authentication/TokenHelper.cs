using EventSphere.Identity.Application.Common.Interfaces.Authentication;
using EventSphere.Identity.Application.Models.Authentication;
using EventSphere.Identity.Application.Models.OperationClaims;
using EventSphere.Identity.Domain.Entities;
using EventSphere.Identity.Infrastructure.Common.Extensions.Claims;
using EventSphere.Identity.Infrastructure.Common.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventSphere.Identity.Infrastructure.Common.Authentication
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;

        public TokenHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }
        public AccessToken CreateToken(User user, List<OperationClaimDto> operationClaimDtoList)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaimDtoList, accessTokenExpiration);
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = accessTokenExpiration
            };
        }
        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaimDto> operationClaimDtoList, DateTime accessTokenExpiration)
        {
            var jwt = new JwtSecurityToken
            (
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                signingCredentials: signingCredentials,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaimDtoList)
            );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaimDto> operationClaimDtoList)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.RecordId.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            if (operationClaimDtoList != null && operationClaimDtoList.Count > 0)
                claims.AddRoles(operationClaimDtoList.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
