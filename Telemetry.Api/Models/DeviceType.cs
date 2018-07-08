using GraphQL.Types;
using Telemetry.Core.Models;

namespace Telemetry.Api.Models
{
    public class DeviceType : ObjectGraphType<Device>
    {
        public DeviceType()
        {
            Field(x => x.DeviceId).Description("The Device ID");
            Field(x => x.DeviceName).Description("The Device Name");
            //Field<EnumerationGraphType>("Category", resolve: context => context.Source.Category == Category.Internal ? 1: 2);
            //Field(x => x.Category).Description("The Device Category");
            Field(x => x.Description).Description("The Device Description");
            Field(x => x.CreatedBy).Description("CreatedBy");
            Field(x => x.UpdatedBy,true).Description("UpdatedBy");
            Field<StringGraphType>("CreatedOn", resolve: context => context.Source.Createdtime.ToShortDateString(), description:"Created on");
            Field<StringGraphType>("UpdatedOn", resolve: context => context.Source.Updatedtime.HasValue ? context.Source.Updatedtime.Value.ToShortDateString() : null, description: "Updated on");

        }
    }
}
