using Microsoft.Extensions.DependencyInjection;

namespace GasTrackerTool
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGasTrackerServices(this IServiceCollection services)
        {
            services.AddSingleton<ETHGasTracker>();
            services.AddSingleton<SepoliaGasTracker>();
            services.AddSingleton<HoleskyGasTracker>();
            services.AddSingleton<GasTrackerFactory>();
            return services;
        }
    }
}
