using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetry.Api.Models.Inputs
{
    public class CreateDeviceType : InputObjectGraphType
    {
        public CreateDeviceType()
        {
            Name = "InputCreateDevice";

            Field<NonNullGraphType<StringGraphType>>("DeviceName");
            Field<NonNullGraphType<StringGraphType>>("Description");
        }
    }
}
