using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data
{
    public class SmartHomeContext : IdentityDbContext<ApplicationUser>
    {
        public SmartHomeContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.Seed();
        }

        public DbSet<Users_Logs> Users_Logs { get; set; }
        public DbSet<HomeUser> HomeUsers { get; set; }
        public DbSet<UserType> Users_Types { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceStatus> Devices_Status { get; set; }
        public DbSet<HomeSystem> Home_Systems { get; set; }
        public DbSet<Systems_Status> Systems_Status { get; set; }
    }
}
