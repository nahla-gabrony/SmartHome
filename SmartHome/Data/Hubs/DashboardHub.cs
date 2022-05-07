using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using SmartHome.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Hubs
{
    public class DashboardHub : Hub
    {
    //    HomeSystemsService _homeSystemsServices;
        UserHomeService _userHomeServices;
        HomeDevicesService _homeDevicesService;
        public DashboardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    _homeSystemsServices = new HomeSystemsService(connectionString);
            _userHomeServices = new UserHomeService(connectionString);
            _homeDevicesService = new HomeDevicesService(connectionString);
        }

        //public async Task SendSystemsData() 
        //{
        //    var homeSystemData = _homeSystemsServices.GetHomeSystems();
        //    await Clients.All.SendAsync("ReceivedSystemsData", homeSystemData);
        //} 
        
        public async Task SendUserData() 
        {
            var UserData = _userHomeServices.GetUserData();
            await Clients.All.SendAsync("ReceivedUserData", UserData);
        }

        public async Task SendDevicesData()
        {
            var DevicesData = _homeDevicesService.GetDevicesData();
            await Clients.All.SendAsync("ReceivedDevicesData", DevicesData);
        }
    }
}
