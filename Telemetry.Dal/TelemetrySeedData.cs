using System.Linq;

namespace Telemetry.Dal
{
    public static class TelemetrySeedData
    {

        public static void EnsureSeedData(this TelemetryDataContext db)
        {
            if (!db.Devices.Any())
            {
                var objUtility = new Utility();
                db.Devices.AddRange(objUtility.GetDevices());
                db.SaveChanges();

                int[] deviceIds = db.Devices.ToList().Select(s => s.DeviceId).ToArray();

                db.DeviceData.AddRange(objUtility.GetDevicesData(deviceIds));
                db.SaveChanges();
            }          
        }
    }
}
