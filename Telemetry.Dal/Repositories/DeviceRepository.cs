using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telemetry.Core.Data;
using Telemetry.Core.Models;

namespace Telemetry.Dal.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly TelemetryDataContext _db;

        public DeviceRepository(TelemetryDataContext db)
        {
            _db = db;
        }

        public async Task<Device> AddDevice(Device device)
        {
            device.CreatedBy = "System";
            device.Createdtime = DateTime.Now;
            await _db.Devices.AddAsync(device);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return device;
        }

        public async Task<List<Device>> GetAllDevices()
        {
            return await _db.Devices.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<Device> GetDeviceById(int id)
        {
            return await _db.Devices.FirstOrDefaultAsync(s=> s.DeviceId == id).ConfigureAwait(false);
        }
    }
}
