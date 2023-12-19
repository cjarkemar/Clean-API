
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Models.User;

namespace Domain.Models.Animal
{
	public class Bird : AnimalModel
	{
        public new Guid Id { get; set; } = Guid.Empty;
        public new string Name { get; set; } = string.Empty;
        public override string TypeOfAnimal => "Bird";
        public override string animalSound => "Tweets";
        public bool CanFly { get; set; }
        public override string Color { get; set; } = string.Empty;


        [NotMapped]
        public string OwnerBirdUserName { get; set; } = string.Empty;

        [NotMapped, JsonIgnore]
        public override string Breed { get; set; } = string.Empty;

        [NotMapped, JsonIgnore]
        public override int Weight { get; set; }

        [JsonIgnore]
        public virtual ICollection<BirdOwner> BirdOwner { get; set; } = new List<BirdOwner>();
    }
}

