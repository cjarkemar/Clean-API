namespace Application.Dtos
{
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }

        public required string Role { get; set; }
        public required bool Authorized { get; set; }

    }
}