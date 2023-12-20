using Domain.Models;
using Domain.Models.Account;
using Domain.Models.Animal;
using Domain.Models.UserAnimal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.RealDatabase
{
    public class RealDatabase : DbContext
    {
        private readonly IConfiguration _configuration;

        public RealDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<UserAnimalJointTable> UserAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql( _configuration.GetConnectionString("DatabaseConnection"),
             new MySqlServerVersion(new Version(8, 2, 0)));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<UserAnimalJointTable>().ToTable(nameof(UserAnimalJointTable));

           
            
        }

    }
}