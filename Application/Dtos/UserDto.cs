namespace Application.Dtos
{
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }


        //Är detta korrekt? Kontrollera
        public required bool Authorized { get; set; }
        public required string Role { get; set; }


    }
}