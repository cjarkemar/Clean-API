//// DatabaseSeedHelper
//using System;
//using Domain.Models.Animal;
//using Domain.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Database
//{
//    public static class DatabaseSeedHelper
//    {
//        public static void SeedData(ModelBuilder modelBuilder)
//        {
//            Seed(modelBuilder);

//            // Add more methods for other entities as needed
//        }

//        private static void Seed(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Dog>().HasData(
//                new Dog { Id = Guid.NewGuid(), Name = "OldG", Barks = true, Breed = "Golden Retriever", Weight = 30},
//                new Dog { Id = Guid.NewGuid(), Name = "NewG", Barks = false, Breed = "Labrador", Weight = 15 },
//                new Dog { Id = Guid.NewGuid(), Name = "Björn" , Barks = true, Breed = "Daschund", Weight = 4 },
//                new Dog { Id = Guid.NewGuid(), Name = "Patrik" , Barks = true, Breed = "chihuahua", Weight = 4 },
//                new Dog { Id = Guid.NewGuid(), Name = "Alfred", Barks = true, Breed = "chihuahua", Weight = 4 }


//            );

//            modelBuilder.Entity<Cat>().HasData(
//                new Cat { Id = Guid.NewGuid(), Name = "Garfield", LikesToPlay = true , Breed = "Bergskatt", Weight = 3},
//                new Cat { Id = Guid.NewGuid(), Name = "HorseCatDude", LikesToPlay = false , Breed = "Bergskatt", Weight = 3 }


//            );

//            modelBuilder.Entity<Bird>().HasData(
//               new Bird { Id = Guid.NewGuid(), Name = "TobiasNugget", CanFly = true, Color = "Green&Yellow" },
//               new Bird { Id = Guid.NewGuid(), Name = "Allanballan", CanFly = false, Color = "Yellow" },
//               new Bird { Id = Guid.NewGuid(), Name = "Kalle", CanFly = false, Color = "Black" },
//               new Bird { Id = Guid.NewGuid(), Name = "Cherry", CanFly = true, Color = "Purple" }

//           );






//        }
//    }
//}

