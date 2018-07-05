using GraphQL.Types;
using Telemetry.Api.Models;
using Telemetry.Core.Data;

namespace Telemetry.Api.Queries
{
    public class DeviceQuery : ObjectGraphType
    {
        public DeviceQuery(IDeviceRepository deviceRepository)
        {
            Field<DeviceType>(
              "DeviceById",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
              resolve: context => deviceRepository.GetDeviceById(context.GetArgument<int>("id")));


            Field<ListGraphType<DeviceType>>(
               "AllDevices",
               resolve: context => deviceRepository.GetAllDevices());
        }

    }
}
