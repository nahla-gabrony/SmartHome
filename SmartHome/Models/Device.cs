using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
 

        //Relationship
        public ICollection<Devices_Status> DevicesStatus { get; set; }
        public ICollection<Notification> Notification { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
