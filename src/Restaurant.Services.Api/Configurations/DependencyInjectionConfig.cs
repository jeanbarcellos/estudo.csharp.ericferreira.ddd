using Microsoft.Extensions.DependencyInjection;
using Restaurant.Infra.IoC;

namespace Restaurant.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            DependencyInjector.Register(services);
        }
    }
}