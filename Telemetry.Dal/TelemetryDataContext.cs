using Microsoft.EntityFrameworkCore;
using Telemetry.Core.Models;

namespace Telemetry.Dal
{
    public sealed class TelemetryDataContext : DbContext
    {
        public TelemetryDataContext(DbContextOptions options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceData> DeviceData { get; set; }
    }
}
