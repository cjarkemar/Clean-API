using System.ComponentModel.DataAnnotations;

namespace Domain.Models.UserAnimal
{
    public class UserAnimalJointTable
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
    }
}