// CatDto
using System;
using System.Text.Json.Serialization;

namespace Application.Dtos
{
	public class CatDto
	{
        public string Name { get; set; } = string.Empty;
        public bool LikesToPlay { get; set; }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string OwnerCatUserName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Guid> CatOwnerIds { get; set; } = new List<Guid>();
    }
}

