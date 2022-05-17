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
            modelBuilder.Seed();
        }

        public DbSet<HomeUser_Status> HomeUser_Status { get; set; }
        public DbSet<HomeUser> HomeUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Devices_Status> Devices_Status { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
