using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDevicesService _devicesService;
        private readonly INotificationService _notificationService;

        public HomeController(IDevicesService devicesService,
                                  INotificationService notificationService)
        {
            _devicesService = devicesService;
            _notificationService = notificationService;
        }


        [Route("Home")]
        public IActionResult index()
        {
            return View();
        }
        public IActionResult Error(int code)
        {
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewBag.ErrorStatusCode = code;

            return View();
        }


        // Json Function
        [HttpPost]
        public IActionResult SendCheckboxData(string checkValue,int dataId)
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

        [HttpPost]
        public async Task<IActionResult> SendNotification(string checkValue, int dataId)
        {
            if (checkValue == "true")
            {
                await _notificationService.CreateNotification(true, dataId);
            }
            else
            {
                await _notificationService.CreateNotification(false, dataId);
            }
            return Ok();
        }

    }
}
