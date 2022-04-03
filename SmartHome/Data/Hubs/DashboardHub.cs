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
        HomeSystemsServices _homeSystemsServices;
        UserHomeServices _userHomeServices;
        public DashboardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _homeSystemsServices = new HomeSystemsServices(connectionString);
            _userHomeServices = new UserHomeServices(connectionString);
        }

        public async Task SendSystemsData() 
        {
            var homeSystemData = _homeSystemsServices.GetHomeSystems();
            await Clients.All.SendAsync("ReceivedSystemsData", homeSystemData);
        } 
        
        public async Task SendUserData() 
        {
            var UserData = _userHomeServices.GetUserData();
            await Clients.All.SendAsync("ReceivedUserData", UserData);
        }
    }
}
