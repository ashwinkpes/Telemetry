using GraphQL.Types;
using Telemetry.Api.Models;
using Telemetry.Core.Data;

namespace Telemetry.Api.Queries
{
    public class DeviceDataQuery : ObjectGraphType
    {
        public DeviceDataQuery(IDeviceDataRepository deviceDataRepository)
        {
            Name = "Query_Device_Data";

            Description = "This API provides data related to the devices!!!";

            Field<ListGraphType<DeviceDataType>>(
              "AllDevicesData",
               description: "Get data of all the devices",
              resolve: context => deviceDataRepository.GetAllDeviceData());
        }
    }
}
