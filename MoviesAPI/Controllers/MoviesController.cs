using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [Produces("application/json")]
    [Route("movies")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetMovies());
        }

        private List<MovieOutputModel> GetMovies()
        {
            var movies = new List<MovieOutputModel>();
            movies.Add(new MovieOutputModel { Id = 1, LastReadAt = DateTime.Now, ReleaseYear = 1983, Summary = "A SPECTRE agent has stolen two American nuclear warheads, and James Bond must find their targets before they are detonated.", Title = "Never Say Never Again" });
            movies.Add(new MovieOutputModel { Id = 2, LastReadAt = DateTime.Now, ReleaseYear = 1971, Summary = "A diamond smuggling investigation leads James Bond to Las Vegas, where he uncovers an evil plot involving a rich business tycoon.", Title = "Diamonds Are Forever" });
            movies.Add(new MovieOutputModel { Id = 3, LastReadAt = DateTime.Now, ReleaseYear = 1967, Summary = "Agent 007 and the Japanese secret service ninja force must find and stop the true culprit of a series of spacejackings before nuclear war is provoked.", Title = "You Only Live Twice" });
            return movies;
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
}