using SmartHome.Data.HelperFunction;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartHome.Data.SignalRServices
{
    public class DevicesStatusService
    {
        string connectionString;
        public DevicesStatusService(string connectionString)
        {
             this.connectionString = connectionString;
        }

        public List<Devices_Status> GetDevicesData()  
        {
            List<Devices_Status> Device = new List<Devices_Status>();
            Devices_Status DevicesData;

            var data = GetData.GetDataFromDb(connectionString, "SpGetHomeDevicesData");
            foreach (DataRow row in data.Rows)
            {
                DevicesData = new Devices_Status
                {
                    Id =  Convert.ToInt32(row["Id"]) ,
                    Status =  Convert.ToInt32(row["Status"]) ,
                    DeviceId =  Convert.ToInt32(row["DeviceId"]) ,
                };
                Device.Add(DevicesData);
            }

            return Device;
        }
    }
}
