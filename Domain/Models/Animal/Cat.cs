﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Models.Animal;
using Domain.Models.User;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public new Guid Id { get; set; } = Guid.Empty;
        public new string Name { get; set; } = string.Empty;
        public override string TypeOfAnimal => "Cat";
        public override string animalSound => "Meows";
        public bool LikesToPlay { get; set; }
        public override string Breed { get; set; } = string.Empty;
        public override int Weight { get; set; }
        [NotMapped]
        public string OwnerCatUserName { get; set; } = string.Empty;
        [NotMapped, JsonIgnore]
        public override string Color { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<CatOwner> CatOwner { get; set; } = new List<CatOwner>();
    }
}

