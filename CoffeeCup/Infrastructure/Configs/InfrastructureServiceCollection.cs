using Infrastructure.Contexts;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configs
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructureServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<CoffeeCupContext>(options =>
            {
                var connection = new SqliteConnection(configuration.GetConnectionString("AppConnection"));
                options.UseSqlite(connection);
            });

            services
                .AddTransient(o => o.GetRequiredService<IDbContextFactory<CoffeeCupContext>>().CreateDbContext());

            services.Configure<PasswordHasherOptions>(options =>
            {
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
            });

            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<CoffeeCupContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
