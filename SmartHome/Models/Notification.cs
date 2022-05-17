using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationHeader { get; set; }
        public string NotificationBody { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
        public bool Status { get; set; }
        //Relationship
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device Device { get; set; }

    }
}
