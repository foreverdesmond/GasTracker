using log4net;
using Microsoft.Extensions.Configuration;

namespace GasTrackerTool
{
    public class ConfigHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConfigHelper));

        //ReadConfigFiles
        public string ReadConfig(string ConfigText)
        {
            try
            {
                //Create configuration builder
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("C:\\Project\\GasTracker\\GasTracker\\appsettings.json");
                //.AddJsonFile("/Users/richy/Projects/WalletLogin/WalletLogin/appsettings.json");

                // Build configuration
                IConfiguration configuration = builder.Build();

                // Read WalletFilePath configuration item
                return configuration[ConfigText];
            }
            catch (FileNotFoundException ex)
            {
                log.Error("Error: Configuration file 'appsettings.json' was not found.", ex);
                log.Error(ex.Message);
                return string.Empty;
            }
        }
    }
}

