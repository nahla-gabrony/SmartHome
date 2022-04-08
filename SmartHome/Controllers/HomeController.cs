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
    public class HomeController : Controller
    {
        private readonly IDevicesService _devicesService;

        public HomeController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

        public IActionResult Index(string UserImageURL, string UserName)
        {
            ViewData["UserImage"] = UserImageURL;
            ViewData["UserName"] = UserName;
            return View();
        }

        public IActionResult Members()
        {
            return View();
        }
        public IActionResult HomeRooms()
        {
            return View();
        }
        public IActionResult DashBoard()
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
