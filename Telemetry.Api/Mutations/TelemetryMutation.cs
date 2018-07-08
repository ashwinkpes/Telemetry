using GraphQL.Types;

namespace Telemetry.Api.Mutations
{
    public class TelemetryMutation : ObjectGraphType
    {
        public TelemetryMutation()
        {
            Field<DeviceMutation>("DeviceMutation", resolve: ctx => new { });
        }
    }
}
