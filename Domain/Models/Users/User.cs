// User
using System;
namespace Domain.Models.User
{
    public class User : UserModel
    {
        public virtual ICollection<BirdOwner> BirdOwner { get; set; }
        public virtual ICollection<CatOwner> CatOwner { get; set; }
        public virtual ICollection<DogOwner> DogOwner { get; set; }
    }
}

