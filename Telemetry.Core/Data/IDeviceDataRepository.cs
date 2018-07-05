using System.Collections.Generic;
using System.Threading.Tasks;
using Telemetry.Core.Models;

namespace Telemetry.Core.Data
{
    public interface IDeviceDataRepository
    {
        Task<List<DeviceData>> GetAllDeviceData();
        Task<List<DeviceData>> GetDeviceDataById(int deviceId);
    }
}
