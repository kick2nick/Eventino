using Application.Services;
using Application.Services.Implementation;
using FileTransfer.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAzureBlobStorage(configuration.GetSection("AzureBlobStorage"));

            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEventsService, EventsService>();

            return services;
        }
    }
}
