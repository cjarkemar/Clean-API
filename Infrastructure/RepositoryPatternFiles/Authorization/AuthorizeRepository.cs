// AuthorizeRepository
using System;
using Domain.Models.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Database;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.RepositoryPatternFiles.Authorization
{
    public class AuthorizeRepository : IAuthorizeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly RealDatabase _realDatabase;

        public AuthorizeRepository(IConfiguration configuration, RealDatabase realDatabase)
        {
            _configuration = configuration;
            _realDatabase = realDatabase;
        }

        public User AuthenticateUser(string username, string password)
        {
            // Retrieve the user by username
            var user = _realDatabase.Users.FirstOrDefault(u => u.Username == username);

            // Check if the user exists
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Verify the password by comparing the hashed input password with the stored hashed password
            if (!VerifyPasswordHash(password, user.PasswordHash))
            {
                throw new Exception("Invalid password");
            }

            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JWtSettings:Key"]!);

            var roles = GetUserRoles(user); // Function to determine user roles

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, roles)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string GetUserRoles(User user)
        {
            // Check if the username is "admin" (case-insensitive) and assign the "Admin" role
            if (user.Username.ToUpperInvariant() == "ADMIN")
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }



        private bool VerifyPasswordHash(string password, string storedHash)
        {
            //BCrypt-paket tillagt på Infrastructure
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}