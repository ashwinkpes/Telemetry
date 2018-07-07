using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetry.Api.Mutations
{
    public class TelemetryMutation : ObjectGraphType
    {
        public TelemetryMutation()
        {
            Field<DeviceMutation>("DeviceMutation", resolve: ctx => new { });
        }
    }
}
