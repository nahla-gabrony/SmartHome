using System.Collections.Generic;

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
