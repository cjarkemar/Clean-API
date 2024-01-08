using System;
using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Database.RealDatabase;
using Infrastructure.Repositories.Animals;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Cats;
using Infrastructure.Repositories.Dogs;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Other service registrations
            services.AddSingleton<MockDatabase>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IBirdRepository, BirdRepository>();
            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();

            services.AddDbContext<RealDatabase>(options =>
            {
                //connectionString to Db
                var connectionString = "Server=localhost;Port=3306;Database=RealDB;User=root;Password=arkemar321;";

                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
            });


            return services;
        }
    }
}