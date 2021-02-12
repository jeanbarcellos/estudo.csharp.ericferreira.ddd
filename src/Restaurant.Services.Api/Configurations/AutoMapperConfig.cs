using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application;

namespace Restaurant.Services.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
        }
    }
}