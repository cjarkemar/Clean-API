// RealDatabase
using System;
using Domain.Models;
using Domain.Models.Animal;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.RealDatabase
{
    public class RealDatabase : DbContext
    {

        public DbSet<Bird> Birds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<User> Users { get; set; }

       
        private readonly IConfiguration _configuration;

        public RealDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DatabaseConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 2, 0)); //När man använder Mysql behöver man skriva ut serverversion här? dont know why

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }

    }
}





