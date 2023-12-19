using Domain.Models;
using Domain.Models.Animal;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {
        }

        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<DogOwner> DogOwner { get; set; }
        public DbSet<CatOwner> CatOwner { get; set; }
        public DbSet<BirdOwner> BirdOwner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionString to Db
            string connectionString = "Server=localhost;Port=3306;Database=ReaLDB;User=root;Password=arkemar321;";

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        

            //Dog many-to-many User 
            modelBuilder.Entity<DogOwner>()
                .HasKey(ud => new { ud.DogId, ud.UserId });

            modelBuilder.Entity<DogOwner>()
                .HasOne(ud => ud.Dog)
                .WithMany(ud => ud.DogOwner)
                .HasForeignKey(ud => ud.DogId);

            modelBuilder.Entity<DogOwner>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.DogOwner)
                .HasForeignKey(ud => ud.UserId);
            //Bird many-to-many User 
            modelBuilder.Entity<BirdOwner>()
                .HasKey(bu => new { bu.BirdId, bu.UserId });

            modelBuilder.Entity<BirdOwner>()
                .HasOne(bu => bu.Bird)
                .WithMany(b => b.BirdOwner)
                .HasForeignKey(bu => bu.BirdId);

            modelBuilder.Entity<BirdOwner>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BirdOwner)
                .HasForeignKey(bu => bu.UserId);

            //Cat many-to-many User 
            modelBuilder.Entity<CatOwner>()
                .HasKey(uc => new { uc.CatId, uc.UserId });

            modelBuilder.Entity<CatOwner>()
                .HasOne(uc => uc.Cat)
                .WithMany(uc => uc.CatOwner)
                .HasForeignKey(uc => uc.CatId);

            modelBuilder.Entity<CatOwner>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.CatOwner)
                .HasForeignKey(uc => uc.UserId);


            // Call the SeedAnimals method to populate the data
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }
}