using GraphQL.Types;
using Telemetry.Api.Controllers;

namespace Telemetry.Api.Models
{
    public class MovieType : ObjectGraphType<MovieOutputModel>
    {
        public MovieType()
        {
            Field(x => x.Id).Description("The movie ID");
            Field(x => x.ReleaseYear).Description("The release year of the movie");
            Field(x => x.Title).Description("The title of the movie");
            Field(x => x.Summary).Description("The summary of the movie");
        }
    }
}
