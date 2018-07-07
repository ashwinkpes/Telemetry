using GraphQL;
using GraphQL.Types;
using Telemetry.Api.Mutations;
using Telemetry.Api.Queries;

namespace Telemetry.Api.Schemas
{
    public class TelemetrySchema : Schema
    {
        public TelemetrySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TelemetryQuery>();
            Mutation = resolver.Resolve<TelemetryMutation>();
            //Mutation = resolver.Resolve<DeviceMutation>();
            //Query = resolver.Resolve<DeviceQuery>();
            //Query = resolver.Resolve<DeviceDataQuery>();
        }
    }
}
