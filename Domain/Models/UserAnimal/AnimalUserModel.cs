using Domain.Models.Account;

namespace Domain.Models.UserAnimal
{
    public class AnimalUserModel
    {
        public Guid AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string Breed { get; set; }
        public List<UserModelForAnimals> Users { get; set; }
    }
}