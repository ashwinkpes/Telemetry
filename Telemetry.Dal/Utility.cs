using System;
using System.Collections.Generic;
using Telemetry.Core.Models;

namespace Telemetry.Dal
{
    internal class Utility
    {
        const string High = "High";
        const string Low = "High";
        const string TemperatureRecorded = "Temperature recorded ";
        const string HumidityRecorded = "Humidity recorded";
        const string CreatedBy = "System";

        public IList<Device> GetDevices()
        {
            var devicesList = new List<Device>();
            for (int i = 1; i <= 10; i++)
            {
                devicesList.Add( new Device
                {
                  DeviceName = $"Device {i}",
                  Category = (i%2 == 0) ? Category.Internal : Category.External,
                  Description = $"Device {i} belongs to category {(i % 2 == 0 ? Category.Internal.ToString() : Category.External.ToString())}",
                  CreatedBy = nameof(System),
                  Createdtime = DateTime.Now

                });
            }

            return devicesList;
        }

        public IList<DeviceData> GetDevicesData(int[] deviceIds)
        {
            var devicesData = new List<DeviceData>();
            int deviceId; 
            for (int i = 1; i <= 10; i++)
            {
                deviceId = deviceIds[i - 1];
                devicesData.Add(new DeviceData
                {
                    DeviceId = deviceId,
                    Severity = (i % 2 == 0) ? nameof(High): nameof(Low),
                    Temperature = (i % 2 == 0) ? null : (float?)(i * new Random().Next(10,100)),
                    Humidity = (i % 2 == 0) ? (float?)(i * new Random().Next(10, 100)) : null,
                    Description = (i % 2 == 0) ? nameof(TemperatureRecorded) : nameof(HumidityRecorded),
                    CreatedBy = nameof(System),
                    Createdtime = DateTime.Now

                });
            }

            return devicesData;
        }

    }
}
