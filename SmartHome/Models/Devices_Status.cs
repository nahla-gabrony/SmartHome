using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Devices_Status
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime ModifyDateTime { get; set; }
        //Relationship
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device Device { get; set; }
    }
}
