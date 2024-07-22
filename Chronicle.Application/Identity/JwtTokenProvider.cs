using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chronicle.Domain.Identity;
using Chronicle.Domain.JWT;
using Chronicle.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Chronicle.Application.Identity
{
    public interface IJwtTokenProvider
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
    }

    public class JwtTokenProvider(UserManager<ApplicationUser> userManager) : IJwtTokenProvider
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(KnownClaims.Username, user.UserName),
                new(KnownClaims.Email, user.UserName),
                new(KnownClaims.Id, user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(userClaims);
            claims.AddRange(
                roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role))
            );

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Constants.JwtConfig.SigningKey)
            );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Constants.JwtConfig.Issuer,
                Constants.JwtConfig.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
