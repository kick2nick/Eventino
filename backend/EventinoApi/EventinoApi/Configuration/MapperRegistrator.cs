using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EventinoApi.Configuration
{
    public static class MapperRegistrator
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(cfg => new MapperConfigurator(cfg).AddConfiguretion());

            services.AddSingleton(mapper.CreateMapper());

            return services;
        }
    }
}
