using System;

namespace SmartHome.Data.ViewModels.Notification
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string NotificationHeader { get; set; }
        public string NotificationBody { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationDateString { get; set; }
        public bool IsRead { get; set; }
        public bool Status { get; set; }

        public int DeviceId { get; set; }
     
    }
}
