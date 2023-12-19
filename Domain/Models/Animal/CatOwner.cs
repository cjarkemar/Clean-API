// CatOwner
using System;
using Domain.Models.Animal;

namespace Domain.Models.User
{
    public class CatOwner
    {
        public Guid CatId { get; set; }
        public Cat Cat { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

