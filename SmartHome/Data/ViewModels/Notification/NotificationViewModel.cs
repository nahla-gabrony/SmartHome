using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.ViewModels.Home
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string NotificationHeader { get; set; }
        public string NotificationBody { get; set; }
        public string NotificationDate { get; set; }
        public bool IsRead { get; set; }
        public bool Status { get; set; }

        public int DeviceId { get; set; }
     
    }
}
