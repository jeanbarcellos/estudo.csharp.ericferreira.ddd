using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infra.Data.Contexts;

namespace Restaurant.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContext<Context>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("Default")));
        }

    }
}