using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly SmartHomeContext _context;

        public DevicesService(SmartHomeContext context)
        {
            _context = context;
        }

        public async Task UpdateData(int data, int deviceId)
        {
            Devices_Status createItem = new()
            {
                Status = data,
                DeviceId = deviceId,
                ModifyDateTime = DateTime.Now
            };


            await _context.Devices_Status.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }
    }
}
