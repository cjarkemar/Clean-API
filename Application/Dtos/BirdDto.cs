

using System.Text.Json.Serialization;

namespace Application.Dtos
{
    public class BirdDto
    {
        public string Name { get; set; } = string.Empty;
        public bool CanFly { get; set; }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string OwnerBirdUserName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Guid> BirdOwnerIds { get; set; } = new List<Guid>();
    }
}


