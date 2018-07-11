using System.Threading.Tasks;
using Telemetry.Api.Models;
using Telemetry.HttpClient;

namespace Telemetry.Api.APIAgents
{
    public class SmartPumpApiAgent : BaseApiAgent
    {
        public SmartPumpApiAgent()
        {
            //base.baseUri = "http://localhost:55029/movies";
            base.baseUri = "https://caf-smartpumping-services-dev1.azurewebsites.net/api/Customers/4";
        }

        public async Task<Customer> GetCustomer()
        {
            var requestUri = $"{baseUri}";
            var response = await HttpRequestFactory.Get(requestUri);
            var outputModel = response.ContentAsType<Customer>();
            return outputModel;
        }
    }
}
