// DatabaseSeedHelper
using System;
using Domain.Models.Animal;
using Domain.Models;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);

            // Add more methods for other entities as needed
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { Id = Guid.NewGuid(), Name = "OldG" },
                new Dog { Id = Guid.NewGuid(), Name = "NewG" },
                new Dog { Id = Guid.NewGuid(), Name = "Björn" },
                new Dog { Id = Guid.NewGuid(), Name = "Patrik" },
                new Dog { Id = Guid.NewGuid(), Name = "Alfred" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345671"), Name = "TestDogForUnitTests1" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345672"), Name = "TestDogForUnitTests2" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345673"), Name = "TestDogForUnitTests3" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDogForUnitTests4" }
            );

            modelBuilder.Entity<Cat>().HasData(
                new Cat { Id = Guid.NewGuid(), Name = "Garfield", LikesToPlay = true },
                new Cat { Id = Guid.NewGuid(), Name = "HorseCatDude", LikesToPlay = false },
                new Cat { Id = new Guid("12345678-1234-5678-1234-567812345675"), Name = "AmandatheUglyCat", LikesToPlay = true }
                
            );

            modelBuilder.Entity<Bird>().HasData(

                new Bird { Id = Guid.NewGuid(), Name = "TwitterGod", CanFly = true },
                new Bird { Id = Guid.NewGuid(), Name = "TobiasNugget", CanFly = false}

                );

         



        }
    }
}

