using System.Configuration;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GasTrackerTool
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static async Task Main(string[] args) 
        {
            // Setup DI
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddGasTrackerServices(); 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            //load Log4net
            try
            {
                string logFilePath = "C:\\Project\\GasTracker\\GasTracker\\log4net.config";
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logFilePath));
                log.Info("log4net initialized successfully.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            //  Using Factory to create GasTracker instance
            var factory = serviceProvider.GetService<GasTrackerFactory>();
            var gasTracker = factory?.CreateGasTracker("ETHGasTracker");

            if (gasTracker != null)
            {
                try
                {
                    decimal gasPrice = await gasTracker.GetGasPriceAsync();
                log.Info("Current Gas Price: "+gasPrice+" Gwei");
                }
                catch (Exception ex)
                {
                log.Error(ex.Message);
                }
            }
        }
    }
}