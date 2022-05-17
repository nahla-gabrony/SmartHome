using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using SmartHome.Data.SignalRServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Hubs
{
    public class DashboardHub : Hub
    {

        HomeUserStatusService _homeUserStatusService;
        DevicesStatusService _homeDevicesService;
        NotificationStatusService _notificationStatusService;
        public DashboardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _homeUserStatusService = new HomeUserStatusService(connectionString);
            _homeDevicesService = new DevicesStatusService(connectionString);
            _notificationStatusService = new NotificationStatusService(connectionString);
        }

        
        public async Task SendUserData() 
        {
            var UserData = _homeUserStatusService.GetUserData();
            await Clients.All.SendAsync("ReceivedUserData", UserData);
        }

        public async Task SendDevicesData()
        {
            var DevicesData = _homeDevicesService.GetDevicesData();
            await Clients.All.SendAsync("ReceivedDevicesData", DevicesData);
        }

        public async Task SendNotificationsData()
        {
            var Notifications = _notificationStatusService.GetNotificationsData();
            await Clients.All.SendAsync("ReceivedNotificationsData", Notifications);
        }
    }
}
