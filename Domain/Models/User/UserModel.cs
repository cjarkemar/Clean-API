// UserModel
using System;
namespace Domain.Models.User
{
    public class UserModel
    {

        public Guid Id { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required bool Authorized { get; set; }

        public string? Role { get; set; }
    }
}

