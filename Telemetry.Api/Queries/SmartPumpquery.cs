using GraphQL.Types;
using Telemetry.Api.APIAgents;
using Telemetry.Api.Models;


namespace Telemetry.Api.Queries
{
    public class SmartPumpquery : ObjectGraphType
    {
        public SmartPumpquery(SmartPumpApiAgent smartPumpApiAgent)
        {
            Name = "Smart_Pump_Query";

            Description = "This API connects to smart pumping APP";

            Field<CustomerType>(
              "GetCustomer",
               description: "Get data of all the movies",
              resolve: context => smartPumpApiAgent.GetCustomer());
        }
    }
}
