using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator
    {
        public string GenerateJwtToken(User user)
        {
            string secretKey = "supersecretkeymadebycjpcudtmzxaxcvjsrfhpuiphqfycn";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>
            {
                new("Username", user.Username),
                new("Role", user.Role),
                new("Authorized", user.Authorized.ToString()),
                new("Id", user.UserId.ToString()),
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

//