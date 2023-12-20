using Domain.Models.Animal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Bird")]
    public class Bird : AnimalModel
    {
        public bool CanFly { get; set; }

        public required string Color { get; set; }
    }
}