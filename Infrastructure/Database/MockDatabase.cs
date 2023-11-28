using Domain.Models;
using Domain.Models.Animal;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        //Put all the list on the top for better view
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }


        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Amanda", LikesToPlay = true},
            new Cat { Id = Guid.NewGuid(), Name = "Nemo", LikesToPlay = false},
            new Cat { Id = new Guid("23456789-2345-6789-2345-678923456789"), Name = "TestCatForUnitTests", LikesToPlay = true}
            
        };

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Max", CanFly = true},
            new Bird { Id = Guid.NewGuid(), Name = "Pepe", CanFly = false},
            new Bird { Id = Guid.NewGuid(), Name = "Tobias"},
            new Bird { Id = new Guid("87654321-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests"}
        };

        

        //// Adding Birds collection
        //private static List<Bird> allBirds = new()
        //{
        //    new Bird { Id = Guid.NewGuid(), Name = "Tweety", CanFly = true},
        //    new Bird { Id = Guid.NewGuid(), Name = "Polly", CanFly = false}
            
        //};

        //public List<Bird> Birds
        //{
        //    get { return allBirds; }
        //    set { allBirds = value; }
        //}
    }
}


