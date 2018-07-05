using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telemetry.Dal
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<TelemetryDataContext>
    {
        public TelemetryDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TelemetryDataContext>();
            optionsBuilder.UseSqlServer("server=WTIN05201542L\\SQLEXPRESS;database=TelemetryData;Integrated Security=SSPI;");

            return new TelemetryDataContext(optionsBuilder.Options);
        }
    }
}
