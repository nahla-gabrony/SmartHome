using Microsoft.EntityFrameworkCore;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // Rooms 
            var Rooms = new List<Room>()
            {
                new Room()
                {
                    Id = 1,
                    RoomName= "Main Systems"
                },
                new Room()
                {
                    Id = 2,
                    RoomName= "Bedroom 1"
                },
                new Room()
                {
                    Id = 3,
                    RoomName= "Bedroom 2"
                },
                new Room()
                {
                    Id = 4,
                    RoomName= "Leaving Room"
                },
                new Room()
                {
                    Id = 5,
                    RoomName= "Dining Room"
                },
                new Room()
                {
                    Id = 6,
                    RoomName= "Storage Room"
                },
                new Room()
                {
                    Id = 7,
                    RoomName= "Office Room"
                },
                new Room()
                {
                    Id = 8,
                    RoomName= "Garage"
                },
                new Room()
                {
                    Id = 9,
                    RoomName= "Garden"
                },
               
            };
            modelBuilder.Entity<Room>().HasData(Rooms);
            // Devices
            var Devices = new List<Device>()
            {
                new Device()
                {
                    Id = 1,
                    DeviceName= "Home Security",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 2,
                    DeviceName= "Open Door",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 3,
                    DeviceName= "Fire System",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 4,
                    DeviceName= "Smoke System",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 5,
                    DeviceName= "Outdoor Light",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 6,
                    DeviceName= "Temperature",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 7,
                    DeviceName= "Humidity",
                    RoomId = 1
                },
                new Device()
                {
                    Id = 8,
                    DeviceName= "TV",
                    RoomId = 2
                },
                new Device()
                {
                    Id = 9,
                    DeviceName= "AC",
                    RoomId = 2
                },
                new Device()
                {
                    Id = 10,
                    DeviceName= "Sound",
                    RoomId = 2
                },
                new Device()
                {
                    Id = 11,
                    DeviceName= "Light",
                    RoomId = 2
                },
                new Device()
                {
                    Id = 12,
                    DeviceName= "Door",
                    RoomId = 2
                },
                new Device()
                {
                    Id = 13,
                    DeviceName= "TV",
                    RoomId = 3
                },
                new Device()
                {
                    Id = 14,
                    DeviceName= "AC",
                    RoomId = 3
                },
                new Device()
                {
                    Id = 15,
                    DeviceName= "Sound",
                    RoomId = 3
                },
                new Device()
                {
                    Id = 16,
                    DeviceName= "Light",
                    RoomId = 3
                },
                new Device()
                {
                    Id = 17,
                    DeviceName= "Door",
                    RoomId = 3
                },
                new Device()
                {
                    Id = 18,
                    DeviceName= "TV",
                    RoomId = 4
                },
                new Device()
                {
                    Id = 19,
                    DeviceName= "AC",
                    RoomId = 4
                },
                new Device()
                {
                    Id = 20,
                    DeviceName= "Sound",
                    RoomId = 4
                },
                new Device()
                {
                    Id = 21,
                    DeviceName= "Light",
                    RoomId = 4
                },
                new Device()
                {
                    Id = 22,
                    DeviceName= "AC",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 23,
                    DeviceName= "Sound",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 24,
                    DeviceName= "Light",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 25,
                    DeviceName= "Light",
                    RoomId = 6
                },
                new Device()
                {
                    Id = 26,
                    DeviceName= "Door",
                    RoomId = 6
                },
                new Device()
                {
                    Id = 27,
                    DeviceName= "TV",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 28,
                    DeviceName= "AC",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 29,
                    DeviceName= "Sound",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 30,
                    DeviceName= "Light",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 31,
                    DeviceName= "Door",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 32,
                    DeviceName= "Garage Security",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 33,
                    DeviceName= "Garage Door",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 34,
                    DeviceName= "Left Parking",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 35,
                    DeviceName= "Right Parking",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 36,
                    DeviceName= "Garage Light",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 37,
                    DeviceName= "Water Tank",
                    RoomId = 9
                },
                new Device()
                {
                    Id = 38,
                    DeviceName= "Irrigation System",
                    RoomId = 9
                },
            };
            modelBuilder.Entity<Device>().HasData(Devices);

            // Devices status 
            var DevicesStatus = new List<Devices_Status>()
            {
                new Devices_Status()
                {
                    Id = 1,
                    Status = 0,
                    DeviceId = 1,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 2,
                    Status = 0,
                    DeviceId = 2,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 3,
                    Status = 0,
                    DeviceId = 3,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 4,
                    Status = 0,
                    DeviceId = 4,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 5,
                    Status = 1,
                    DeviceId = 5,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 6,
                    Status = 31,
                    DeviceId = 6,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 7,
                    Status = 10,
                    DeviceId = 7,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 8,
                    Status = 1,
                    DeviceId = 8,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 9,
                    Status = 0,
                    DeviceId = 9,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 10,
                    Status = 1,
                    DeviceId = 10,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 11,
                    Status = 0,
                    DeviceId = 11,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 12,
                    Status = 1,
                    DeviceId = 12,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 13,
                    Status = 1,
                    DeviceId = 13,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 14,
                    Status = 1,
                    DeviceId = 14,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 15,
                    Status = 1,
                    DeviceId = 15,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 16,
                    Status = 0,
                    DeviceId = 16,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 17,
                    Status = 0,
                    DeviceId = 17,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 18,
                    Status = 0,
                    DeviceId = 18,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 19,
                    Status = 0,
                    DeviceId = 19,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 20,
                    Status = 1,
                    DeviceId = 20,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 21,
                    Status = 1,
                    DeviceId = 21,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 22,
                    Status = 0,
                    DeviceId = 22,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 23,
                    Status = 1,
                    DeviceId = 23,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 24,
                    Status = 1,
                    DeviceId = 24,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 25,
                    Status = 1,
                    DeviceId = 25,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 26,
                    Status = 0,
                    DeviceId = 26,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 27,
                    Status = 1,
                    DeviceId = 27,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 28,
                    Status = 0,
                    DeviceId = 28,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 29,
                    Status = 0,
                    DeviceId = 29,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 30,
                    Status = 0,
                    DeviceId = 30,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 31,
                    Status = 1,
                    DeviceId = 31,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 32,
                    Status = 0,
                    DeviceId = 32,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 33,
                    Status = 0,
                    DeviceId = 33,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 34,
                    Status = 0,
                    DeviceId = 34,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 35,
                    Status = 0,
                    DeviceId = 35,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 36,
                    Status = 0,
                    DeviceId = 36,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 37,
                    Status = 50,
                    DeviceId = 37,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 38,
                    Status = 90,
                    DeviceId = 38,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
            };
            modelBuilder.Entity<Devices_Status>().HasData(DevicesStatus);



        }
    }
}
