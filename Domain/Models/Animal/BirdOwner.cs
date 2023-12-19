// BirdOwner
using System;
using Domain.Models.Animal;

namespace Domain.Models.User
{
    public class BirdOwner
    {
        public Guid BirdId { get; set; }
        public Bird Bird { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

