using Microsoft.EntityFrameworkCore;
using SmartHome.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly SmartHomeContext _context;

        public NotificationService(SmartHomeContext context)
        {
            _context = context;
        }
            public async Task UpdateNotification(int dataId)
        {
            var item = await _context.Notification.Where(x => x.Id == dataId).FirstOrDefaultAsync();
            if (item != null)
            {
                item.IsRead = true;
                _context.Notification.Update(item);
                await _context.SaveChangesAsync();
            }
        
        }
        public async Task CreateNotification(bool checkValue, int dataId)
        {
            var header = "";
            var body = "" ;
            if (dataId == 1 && checkValue == true)
            {
                 header = "Home Security";
                 body = "Someone Break Into the House.";
            }
            else if (dataId == 1 && checkValue == false)
            {
                header = "Home Security";
                body = "The House is Safe Now";
            }
            else if (dataId == 3 && checkValue == true)
            {
                header = "Fire System";
                body = "There is Fire in House";
            }
            else if (dataId == 3 && checkValue == false)
            {
                header = "Fire System";
                body = "There is no Fire in House";
            }
            else if (dataId == 4 && checkValue == true)
            {
                header = "Smoke System";
                body = "There is Smoke in House";
            }
            else if (dataId == 4 && checkValue == false)
            {
                header = "Smoke System";
                body = "There is no Smoke in House";
            }
            else if (dataId == 38 && checkValue == true)
            {
                header = "Garage Security";
                body = "Someone Break Into the Garage.";
            }
            else if (dataId == 38 && checkValue == false)
            {
                header = "Garage Security";
                body = "The Garage is Safe Now";
            }
            var lastSavedStatus = await _context.Notification.Where(x=>x.DeviceId == dataId).OrderByDescending(x=>x.Id).Select(x=>x.Status).FirstOrDefaultAsync();
            if( lastSavedStatus != checkValue)
            {
                var item = new Notification()
                {
                    DeviceId = dataId,
                    IsRead = false,
                    NotificationBody = body,
                    NotificationHeader = header,
                    Status = checkValue,
                    NotificationDate = DateTime.Now,
                };

                await _context.Notification.AddAsync(item);
                await _context.SaveChangesAsync();
            }
         
        }
        // Helper Function 
        public string ConvertDateTime(DateTime date)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
                            
    }
}
