// UserModel
using System;
namespace Domain.Models.User
{
    public class UserModel
    {

        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}

