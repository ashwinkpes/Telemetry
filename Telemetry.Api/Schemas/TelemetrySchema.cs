using GraphQL;
using GraphQL.Types;
using Telemetry.Api.Queries;

namespace Telemetry.Api.Schemas
{
    public class TelemetrySchema : Schema
    {
        public TelemetrySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TelemetryQuery>();
            
            //Query = resolver.Resolve<DeviceQuery>();
            //Query = resolver.Resolve<DeviceDataQuery>();
        }
    }
}
