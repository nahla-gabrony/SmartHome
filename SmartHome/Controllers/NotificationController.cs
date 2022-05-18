using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;
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
