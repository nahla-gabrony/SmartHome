using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }


        //Relationship
        public ICollection<Device> Devices { get; set; }


    }
}
