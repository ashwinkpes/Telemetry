using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telemetry.HttpClient;

namespace Telemetry.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Default")]
    public class DefaultController : Controller
    {
        const string baseUri = "http://localhost:56942/movies";

        public async Task<IActionResult> Get()
        {
            var requestUri = $"{baseUri}";
            var response = await HttpRequestFactory.Get(requestUri);
            var outputModel = response.ContentAsType<List<MovieOutputModel>>();
            return Ok();
        }
    }

    public class MovieOutputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
        public DateTime LastReadAt { get; set; }
    }
}