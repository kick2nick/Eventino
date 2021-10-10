using Dal.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Configuration
{
    public static class DalServicesRegistrator
    {
        public static void AddDal(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventsRepository, EventsRepository>();
        }
    }
}
