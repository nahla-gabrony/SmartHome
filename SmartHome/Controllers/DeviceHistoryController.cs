using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    [Authorize]
    public class DeviceHistoryController : Controller
    {
        private readonly IDevicesService _devicesService;

        public DeviceHistoryController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

       
        [Route("History/{id:int:min(1)}")]
        public async Task<IActionResult> History(int id)
        {
            var data = await _devicesService.GetHistory(id);
            if (data == null)
            {
                return View("NotFound");
            }
            else if (data.Any(x => x.DeviceId == 1))
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
                ViewData["IconName"] = "fab fa-gripfire";
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


            else if (data.Any(x => x.DeviceId == 38))
            {
                ViewData["SystemName"] = "Garage Security";
                ViewData["IconName"] = "fas fa-warehouse";
                ViewData["TrueValue"] = "Safe";
                ViewData["FalseValue"] = "Unsafe";
            }

            else if (data.Any(x => x.DeviceId == 39 || x.DeviceId == 40))
            {
                if(data.Any(x => x.DeviceId == 39))
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
            else if (data.Any(x => x.DeviceId == 42))
            {
                ViewData["SystemName"] = "Garage Light";
                ViewData["IconName"] = "far fa-lightbulb";
                ViewData["TrueValue"] = "On";
                ViewData["FalseValue"] = "Off";
            }
            return View(data);
        }
    
    

    }
}
