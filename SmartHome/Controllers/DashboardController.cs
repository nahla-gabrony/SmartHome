using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;

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


    }
}
