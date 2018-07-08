using GraphQL.Types;
using Telemetry.Core.Models;

namespace Telemetry.Api.Models
{
    public class DeviceDataType : ObjectGraphType<DeviceData>
    {
        public DeviceDataType()
        {
            Field(x => x.DeviceDataId).Description("The device data ID");
            Field(x => x.DeviceId).Description("The deviceID");
            Field(x => x.Description).Description("The device data description");
            Field(x => x.Severity).Description("The severity of the data");
        }
    }
}
