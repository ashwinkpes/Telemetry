using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetry.Api.Models;
using Telemetry.Api.Models.Inputs;
using Telemetry.Core.Data;
using Telemetry.Core.Models;

namespace Telemetry.Api.Mutations
{
    public class DeviceMutation : ObjectGraphType
    {
        public DeviceMutation(IDeviceRepository deviceRepository)
        {
            Name = "CRUD_Device";

            Description = "This API provides methods to create,edit,update and delete devices";

            Field<DeviceType>(
               "AddDevice",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<CreateDeviceType>> { Name = "CreateDeviceType" }
               ),
               resolve: context =>
               {
                   var device = context.GetArgument<Device>("CreateDeviceType");
                   device.Category = Category.Internal;
                   return deviceRepository.AddDevice(device);
               });
        }
    }
}
