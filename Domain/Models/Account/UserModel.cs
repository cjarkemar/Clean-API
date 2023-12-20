using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Account
{

    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required bool Authorized { get; set; }

        public string? Role { get; set; }

    }
}
