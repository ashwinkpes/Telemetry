using GraphQL.Types;

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
