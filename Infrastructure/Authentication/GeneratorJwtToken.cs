using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Domain.Models.User;

namespace Infrastructure.Authentication
{
    public class GeneratorJwtToken
    {
        public string GenerateJwtToken(User user)
        {
            string secretKey = "wtfisthisshitforatokenasdasdasdfsdggsdsdgasdasdas";

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