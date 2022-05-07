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
        private readonly IShowDevicesService _showDevicesService;

        public HomeController(IDevicesService devicesService,
                              IShowDevicesService showDevicesService)
        {
            _devicesService = devicesService;
            _showDevicesService = showDevicesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string UserImageURL, string UserName)
        {
            ViewData["UserImage"] = UserImageURL;
            ViewData["UserName"] = UserName;
            var Devices = await _showDevicesService.ShowDevices();
            return View(Devices);
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<Show_Devices> model)
        {
            var Devices = await _showDevicesService.ShowDevices();
            return View(Devices);
        }

        [Route("HomeRooms")]
        public IActionResult HomeRooms()
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

        [HttpPost]
        public IActionResult SendInputData(int dataValue ,int dataId)
        {
            _devicesService.UpdateData(dataValue, dataId);
            return Ok();
        }

    }
}
