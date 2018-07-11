using GraphQL.Types;

namespace Telemetry.Api.Queries
{
    public class TelemetryQuery : ObjectGraphType
    {
        public TelemetryQuery()
        {
            Field<DeviceQuery>("DeviceQuery", resolve: ctx => new { });
            Field<DeviceDataQuery>("DeviceDataQuery", resolve: ctx => new { });
            Field<SmartPumpquery>("SmartPumpquery", resolve: ctx => new { });
        }
    }
}
