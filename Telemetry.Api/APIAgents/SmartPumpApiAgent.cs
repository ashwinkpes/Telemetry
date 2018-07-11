using System.Collections.Generic;
using System.Threading.Tasks;
using Telemetry.Api.Controllers;
using Telemetry.HttpClient;

namespace Telemetry.Api.APIAgents
{
    public class SmartPumpApiAgent : BaseApiAgent
    {
        public SmartPumpApiAgent()
        {
            base.baseUri = "http://localhost:55029/movies";
        }

        public async Task<List<MovieOutputModel>> GetAllMovies()
        {
            var requestUri = $"{baseUri}";
            var response = await HttpRequestFactory.Get(requestUri);
            var outputModel = response.ContentAsType<List<MovieOutputModel>>();
            return outputModel;
        }
    }
}
