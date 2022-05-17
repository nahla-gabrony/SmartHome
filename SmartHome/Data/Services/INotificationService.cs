using SmartHome.Data.ViewModels.Home;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public  interface INotificationService
    {
        Task<IEnumerable<NotificationViewModel>> GetNotificationList();
        Task<int> GetDeviceId(int dataId);
        Task UpdateNotification(int dataId);
        Task CreateNotification(bool readValue, int dataId);
    }
}
