using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public  interface IDevicesService
    {
        Task UpdateData(int data, int deviceId);
    }
}
