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
            // Home System
            var HomeSystems = new List<HomeSystem>()
            {
                new HomeSystem()
                {
                    Id = 1,
                    SystemName= "Home Security"
                },
                new HomeSystem()
                {
                    Id = 2,
                    SystemName= "Garage Security"
                },
                new HomeSystem()
                {
                    Id = 3,
                    SystemName= "Fire System"
                },
                new HomeSystem()
                {
                    Id = 4,
                    SystemName= "Smoke System"
                },
                new HomeSystem()
                {
                    Id = 5,
                    SystemName= "Left Parking"
                },
                new HomeSystem()
                {
                    Id = 6,
                    SystemName= "Right Parking"
                },
                new HomeSystem()
                {
                    Id = 7,
                    SystemName= "Outdoor Light"
                },
                new HomeSystem()
                {
                    Id = 8,
                    SystemName= "Temperature"
                },
                new HomeSystem()
                {
                    Id = 9,
                    SystemName= "Humidity"
                },
                new HomeSystem()
                {
                    Id = 10,
                    SystemName= "Water Tank"
                },
                new HomeSystem()
                {
                    Id = 11,
                    SystemName= "Irrigation System"
                },
            };
            modelBuilder.Entity<HomeSystem>().HasData(HomeSystems);

            // System status
            var SystemsStatus = new List<Systems_Status>()
            {
                new Systems_Status()
                {
                    Id = 1,
                    Status = 1,
                    SystemId = 1
                },
                new Systems_Status()
                {
                    Id = 2,
                    Status = 0,
                    SystemId = 1
                },
                new Systems_Status()
                {
                    Id = 3,
                    Status = 1,
                    SystemId = 2
                },
                new Systems_Status()
                {
                    Id = 4,
                    Status = 0,
                    SystemId = 2
                },
            };
            modelBuilder.Entity<Systems_Status>().HasData(SystemsStatus);

        }
    }
}
