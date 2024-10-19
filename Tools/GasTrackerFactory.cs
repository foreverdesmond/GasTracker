using System;
using Microsoft.Extensions.DependencyInjection;

namespace GasTrackerTool
{
    public class GasTrackerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public GasTrackerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGasTracker CreateGasTracker(string trackerType)
        {
            return trackerType switch
            {
                "ETHGasTracker" => _serviceProvider.GetService<ETHGasTracker>(),
                "SepoliaGasTracker" => _serviceProvider.GetService<SepoliaGasTracker>(),
                "HoleskyGasTracker" => _serviceProvider.GetService<HoleskyGasTracker>(),
                _ => throw new ArgumentException("Invalid tracker type", nameof(trackerType))
            };
        }
    }
}
