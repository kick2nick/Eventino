using Domain.Services;
using Domain.Services.Implementation;
using FileTransfer.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configuration
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAzureBlobStorage(configuration.GetSection("AzureBlobStorage"));

            services.AddTransient<IPictureService, PictureService>();

            return services;
        }
    }
}
