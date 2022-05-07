﻿using Microsoft.AspNetCore.Mvc;
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
    public class DeviceHistoryController : Controller
    {
        private readonly IDevicesService _devicesService;

        public DeviceHistoryController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

       
        [Route("History/{id:int:min(1)}")]
        public async Task<IActionResult> DevicesHistory(int id)
        {
           var data = await _devicesService.GetHistory(id);
            if (data.Any(x => x.DeviceId == 1))
            {
                ViewData["SystemName"] = "Home Security";
                ViewData["IconName"] = "fas fa-hotel";
                ViewData["TrueValue"] = "Safe";
                ViewData["FalseValue"] = "Unsafe";
            } 
            
            else if (data.Any(x => x.DeviceId == 3))
            {
                ViewData["SystemName"] = "Fire System";
                ViewData["IconName"] = "fas fa-fire-extinguisher";
                ViewData["TrueValue"] = "Safe";
                ViewData["FalseValue"] = "Fire";
            }  
            
            else if (data.Any(x => x.DeviceId == 4))
            {
                ViewData["SystemName"] = "Smoke System";
                ViewData["IconName"] = "fas fa-gripfire";
                ViewData["TrueValue"] = "Safe";
                ViewData["FalseValue"] = "Smoke";
            }

            else if (data.Any(x => x.DeviceId == 5))
            {
                ViewData["SystemName"] = "Outdoor Light";
                ViewData["IconName"] = "far fa-lightbulb";
                ViewData["TrueValue"] = "On";
                ViewData["FalseValue"] = "Off";
            }


            else if (data.Any(x => x.DeviceId == 32))
            {
                ViewData["SystemName"] = "Garage Security";
                ViewData["IconName"] = "fas fa-warehouse";
                ViewData["TrueValue"] = "Safe";
                ViewData["FalseValue"] = "Unsafe";
            }

            else if (data.Any(x => x.DeviceId == 34 || x.DeviceId == 35))
            {
                if(data.Any(x => x.DeviceId == 34))
                {
                    ViewData["SystemName"] = "Left Parking";
                }
                else 
                {
                    ViewData["SystemName"] = "Right Parking";
                }
                ViewData["IconName"] = "fas fa-parking";
                ViewData["TrueValue"] = "Empty";
                ViewData["FalseValue"] = "Busy";
            }
            return View(data);
        }
    
    

    }
}