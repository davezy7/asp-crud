using GAS_LATIHAN_ASP.Models.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GAS_LATIHAN_ASP.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly TokenOptions _options;
        public TokenService(IOptions<TokenOptions> options)
        {
            _options = options.Value;
        }

        public ResponseLoginUser GenerateUserToken(Guid id, string email)
        {
            // Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var signingCrendetials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCrendetials);

            // Claims
            var claims = new[]
            {
                new Claim("Email", email),
                new Claim("Id", id.ToString())
            };

            var current = DateTime.UtcNow;

            // Payload
            var payload = new JwtPayload
                (
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: current,
                    expires: current.AddDays(1)
                );

            // Token
            var token = new JwtSecurityToken(header, payload);

            var dataToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new ResponseLoginUser
            {
                UserID = id,
                Token = dataToken
            };
        }
    }
}
