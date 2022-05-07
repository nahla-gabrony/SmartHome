using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public  interface IShowDevicesService
    {
        Task<List<Show_Devices>> ShowDevices();   
      //  Task<List<int>> ShowDevices();
        Task SaveShowDevices(int deviceId, bool statues);
    }
}
