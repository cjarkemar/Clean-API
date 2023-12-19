using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class DogDto
    {
        public string Name { get; set; } = string.Empty;
        public bool Barks { get; set; }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string OwnerDogUserName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Guid> DogOwnerIds { get; set; } = new List<Guid>();
    }
}
