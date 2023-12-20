using Domain.Models.Animal;

namespace Domain.Models.UserAnimal
{
    public class UserAnimalModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public List<AnimalModel> Animals { get; set; } = new List<AnimalModel>();
    }
}