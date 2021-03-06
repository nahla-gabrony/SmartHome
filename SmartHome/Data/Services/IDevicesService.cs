using SmartHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public  interface IDevicesService
    {
        Task UpdateData(int data, int deviceId);
        Task<IEnumerable<Devices_Status>> GetHistory(int deviceId);
    }
}
