using GraphQL.Types;
using Telemetry.Api.Models;
using Telemetry.Core.Data;

namespace Telemetry.Api.Queries
{
    public class DeviceDataQuery : ObjectGraphType
    {
        public DeviceDataQuery(IDeviceDataRepository deviceDataRepository)
        {
            Field<ListGraphType<DeviceDataType>>(
              "AllDevicesData",
              resolve: context => deviceDataRepository.GetAllDeviceData());
        }
    }
}
