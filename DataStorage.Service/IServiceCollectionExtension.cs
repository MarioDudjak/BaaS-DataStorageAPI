using Microsoft.Extensions.DependencyInjection;

namespace DataStorage.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServicesBindings(this IServiceCollection services)
        {
            services.AddTransient<, >();
            return services;
        }
    }
}
