using Domain.Models.Users;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator
    {
        public string GenerateJwtToken(User user)
        {
            string secretKey = "wtfisthisshitforatokengagagagagaagagaga";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>
            {
                new("Username", user.Username),
                new("Role", user.Role),
                new("Authorized", user.Authorized.ToString()),
                new("Id", user.Id.ToString()),
                new("Issuer", "Clean-API"),
                new("Audience", "API")
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}