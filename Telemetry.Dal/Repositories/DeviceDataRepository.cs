using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetry.Core.Data;
using Telemetry.Core.Models;

namespace Telemetry.Dal.Repositories
{
    public class DeviceDataRepository : IDeviceDataRepository
    {
        private readonly TelemetryDataContext _db;

        public DeviceDataRepository(TelemetryDataContext db)
        {
            _db = db;
        }

        public async Task<List<DeviceData>> GetAllDeviceData()
        {
            return await _db.DeviceData.AsNoTracking().ToListAsync();
        }

        public async Task<List<DeviceData>> GetDeviceDataById(int deviceId)
        {
            return await _db.DeviceData.Where(s=> s.DeviceId == deviceId).AsNoTracking().ToListAsync();
        }
    }
}
