using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using SmartHome.Data.Services;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
       
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

       
        public async Task<IActionResult> Update(int deviceid, int id)
        {
            if (deviceid == 0)
            {
                return View("NotFound");
            }
            await _notificationService.UpdateNotification(id);
            return RedirectToAction("History", "DeviceHistory", new { id = deviceid });
        }


    }
}
