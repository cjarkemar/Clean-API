using System;
using Infrastructure.Database;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using Infrastructure.RepositoryPatternFiles.UserPattern;
using Infrastructure.RepositoryPatternFiles.BirdsPattern;
using Infrastructure.RepositoryPatternFiles.CatsPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.RepositoryPatternFiles.Authorization;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddScoped<IAuthorizeRepository, AuthorizeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IBirdRepository, BirdRepository>();
            services.AddScoped<ICatRepository, CatRepository>();
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