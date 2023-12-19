namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual string TypeOfAnimal { get; } = string.Empty;
        public virtual string Breed { get; set; } = string.Empty;
        public virtual string animalSound { get; } = string.Empty;
        public virtual int Weight { get; set; }
        public virtual string Color { get; set; } = string.Empty;
        
        
    }
}
