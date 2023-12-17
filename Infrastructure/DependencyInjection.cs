
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Infrastructure.Database;
using Infrastructure.Database.RealDatabase;
using Infrastructure.Authentication;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();

            services.AddSingleton<GeneratorJwtToken>();

           
            return services;
        }
    }
}
        