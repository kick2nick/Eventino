using Azure.Identity;
using FileTransfer.Clients;
using FileTransfer.Clients.Implementation;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileTransfer.Configuration
{
    public static class StorageServiceRegistrator
    {
        public static IServiceCollection AddAzureBlobStorage(this IServiceCollection services, IConfiguration storageConfiguration)
        {
            services.AddAzureClients(builder =>
            {
                builder.ConfigureDefaults(storageConfiguration.GetSection("Defaults"));

                builder.UseCredential(new DefaultAzureCredential());

                builder.AddBlobServiceClient(storageConfiguration.GetSection("ConnectionString"));
            });

            services.AddTransient<IPictureTransferClient, PictureTransferClient>();

            return services;
        }
    }
}
