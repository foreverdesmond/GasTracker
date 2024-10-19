using System;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json.Linq;

namespace GasTrackerTool
{
    public class GasTracker : IGasTracker
    {

        public static readonly ILog log = LogManager.GetLogger(typeof(GasTracker));
        public ConfigHelper configHelper = new ConfigHelper();
        public static readonly HttpClient client = new HttpClient();
        protected string infuraUrl = new ConfigHelper().ReadConfig("infuraUrlEHT");

        public async Task<decimal> GetGasPriceAsync(string chain)
        {
            string infuraUrlChain = configHelper.ReadConfig(chain);
            try
            {
                var response = await client.PostAsync(infuraUrlChain, new StringContent("{\"jsonrpc\":\"2.0\",\"method\":\"eth_gasPrice\",\"params\":[],\"id\":1}", System.Text.Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                var gasPriceHex = json["result"].ToString();
                var gasPriceWei = Convert.ToInt64(gasPriceHex, 16);

                // Convert Wei to Gwei
                return gasPriceWei / 1_000_000_000m;
            }
            catch (Exception ex)
            {
                log.Info("Error fetching gas price: " + ex.Message);
                return -1;
            }
        }

        public async Task<decimal> GetGasPriceAsync()
        {
            try
            {
                var response = await client.PostAsync(infuraUrl, new StringContent("{\"jsonrpc\":\"2.0\",\"method\":\"eth_gasPrice\",\"params\":[],\"id\":1}", System.Text.Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                var gasPriceHex = json["result"].ToString();
                var gasPriceWei = Convert.ToInt64(gasPriceHex, 16);

                // Convert Wei to Gwei
                return gasPriceWei / 1_000_000_000m;
            }
            catch (Exception ex)
            {
                log.Info("Error fetching gas price: " + ex.Message+",url is:" +infuraUrl);
                return -1;
            }
        }
    }
}
