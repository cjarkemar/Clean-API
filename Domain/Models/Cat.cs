using Domain.Models.Animal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Cat")]
    public class Cat : AnimalModel
    {
        public string Purr()
        {
            return "This animal purrs";
        }
        public bool LikesToPlay { get; set; }

        public int Weight { get; set; }

        public string Breed { get; set; } = string.Empty;
    }
}