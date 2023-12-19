



namespace Domain.Models.User
{
    public class DogOwner
    {
        public Guid DogId { get; set; }
        public Dog Dog { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}