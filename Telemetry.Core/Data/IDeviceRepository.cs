using System.Collections.Generic;
using System.Threading.Tasks;
using Telemetry.Core.Models;

namespace Telemetry.Core.Data
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllDevices();
        Task<Device> GetDeviceById(int id);
        Task<Device> AddDevice(Device device);
    }
}
