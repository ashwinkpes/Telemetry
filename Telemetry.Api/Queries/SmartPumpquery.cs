using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetry.Api.APIAgents;
using Telemetry.Api.Controllers;
using Telemetry.Api.Models;

namespace Telemetry.Api.Queries
{
    public class SmartPumpquery : ObjectGraphType
    {
        public SmartPumpquery()
        {
            Name = "Smart_Pump_Query";

            Description = "This API connects to smart pumping APP";

            Field<ListGraphType<MovieType>>(
              "AllMovies",
               description: "Get data of all the movies",
              resolve: context => new SmartPumpApiAgent().GetAllMovies());
        }
    }
}
