using Microsoft.EntityFrameworkCore;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class ShowDevicesService : IShowDevicesService
    {
        private readonly SmartHomeContext _context;

        public ShowDevicesService(SmartHomeContext context)
        {
            _context = context;
        }

        public async Task<List<Show_Devices>> ShowDevices()
        {
            var result = await _context.Show_Devices.FromSqlRaw("SpGetShowDevicesTest").ToListAsync();
            return result;
        }
        public async Task SaveShowDevices(int deviceId, bool statues)
        {
            Show_Devices createItem = new()
            {
                Status = statues,
                DeviceId = deviceId,
                UserId = "3b984f50-99c3-41d4-9e4e-31c8ec434f7c"  // Change
            };


            await _context.Show_Devices.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }
   
    }
}
