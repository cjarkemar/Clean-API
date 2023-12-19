using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Models.Animal;
using Domain.Models.User;

namespace Domain.Models
{
    public class Dog : AnimalModel
    {
        public new Guid Id { get; set; } = Guid.Empty;
        public new string Name { get; set; } = string.Empty;
        public override string TypeOfAnimal => "Dog";
        public override string animalSound => "Barking";
        public bool Barks { get; set; }
        public override string Breed { get; set; } = string.Empty;
        public override int Weight { get; set; }  

        [NotMapped]
        public string OwnerDogUsername { get; set; } = string.Empty;

        [NotMapped, JsonIgnore]
        public override string Color { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<DogOwner> DogOwner { get; set; } = new List<DogOwner>();
    }
}
