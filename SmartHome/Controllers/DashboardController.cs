using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize(Roles = "Dashboard Admin")]
    public class DashboardController : Controller
    {
        private readonly IDevicesService _devicesService;
        private readonly INotificationService _notificationService;

        public DashboardController(IDevicesService devicesService,
                              INotificationService notificationService)
        {
            _devicesService = devicesService;
            _notificationService = notificationService;
        }

        [HttpGet]
        [Route("Dashboard")]
        public  IActionResult Dashboard()
        {
            return View();
        }


        // Json Function
        [HttpPost]
        public IActionResult SendData(string checkValue,int dataId)
        {
           if(checkValue == "true")
            {
                _devicesService.UpdateData(1, dataId);
            }
            else
            {
                _devicesService.UpdateData(0, dataId);
            }
 
            return Ok();
        }

    }
}
