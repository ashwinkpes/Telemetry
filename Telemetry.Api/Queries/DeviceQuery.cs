using GraphQL.Types;
using Telemetry.Api.Models;
using Telemetry.Core.Data;

namespace Telemetry.Api.Queries
{
    public class DeviceQuery : ObjectGraphType
    {
        public DeviceQuery(IDeviceRepository deviceRepository)
        {
            Name = "Query_Device";

            Description = "This API provides methods to query devices by id or as a list";

            Field<DeviceType>(
              "DeviceById",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                description: "Get Device by ID",
              resolve: context => deviceRepository.GetDeviceById(context.GetArgument<int>("id")));


            Field<ListGraphType<DeviceType>>(
               "AllDevices",
               description: "Get list of all the devices",
               resolve: context => deviceRepository.GetAllDevices());

        }

    }
}
