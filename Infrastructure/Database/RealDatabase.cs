// RealDatabase
using System;
using Domain.Models;
using Domain.Models.Animal;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public virtual DbSet<Dog> Dogs { get; set; }

        public virtual DbSet<Cat> Cats { get; set; }

        public virtual DbSet<Bird> Birds { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=arkemar321;database=RealDB",
                        new MySqlServerVersion(new Version(8, 2, 0)));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }

}



