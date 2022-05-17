using Microsoft.AspNetCore.Identity;
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
            // Role
            var Roles = new List<IdentityRole>()
                {
                    new IdentityRole()
                    {
                        Name = "Dashboard Admin", NormalizedName = "DASHBOARD ADMIN"
                    },
                    new IdentityRole()
                    {
                        Name = "Control Users", NormalizedName = "CONTROL USERS"
                    },
                    new IdentityRole()
                    {
                        Name = "Main Systems", NormalizedName = "MAIN SYSTEMS"
                    },
                    new IdentityRole()
                    {
                        Name = "Bedroom One", NormalizedName = "BEDROOM ONE"
                    },
                    new IdentityRole()
                    {
                        Name = "Bedroom Two", NormalizedName = "BEDROOM TWO"
                    },
                    new IdentityRole()
                    {
                        Name = "Bedroom Three", NormalizedName = "BEDROOM THREE"
                    },
                    new IdentityRole()
                    {
                        Name = "Living Room", NormalizedName = "LIVING ROOM"
                    },
                    new IdentityRole()
                    {
                        Name = "Dining Room", NormalizedName = "DINING ROOM"
                    },
                    new IdentityRole()
                    {
                        Name = "Storage Room", NormalizedName = "STORAGE ROOM"
                    },
                    new IdentityRole()
                    {
                        Name = "Office Room", NormalizedName = "OFFICE ROOM"
                    },
                    new IdentityRole()
                    {
                        Name = "Garage", NormalizedName = "GARAGE"
                    },
                    new IdentityRole()
                    {
                        Name = "Garden", NormalizedName = "GARDEN"
                    },

                };
            modelBuilder.Entity<IdentityRole>().HasData(Roles);
            // Users
            var Users = new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        FirstName = "Ali",
                        LastName = "Ahmed",
                        Email = "ali_ahmed@gmail.com",
                        NormalizedEmail = "ALI_AHMED@GMAIL.COM",
                        UserName = "Ali_Ahmed@gmail.com",
                        NormalizedUserName = "ALI_AHMED@GMAIL.COM",
                        PhoneNumber = "01017080058",
                        UserImageURL = "../images/profile/1.png",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    },
                    new ApplicationUser()
                        {
                            FirstName = "Mona",
                            LastName = "Mohamed",
                            Email = "mona_mohamed@yahoo.com",
                            NormalizedEmail = "MONA_MOHAMED@YAHOO.COM",
                            UserName = "mona_mohamed@yahoo.com",
                            NormalizedUserName =  "MONA_MOHAMED@YAHOO.COM",
                            PhoneNumber = "01017180069",
                            UserImageURL = "../images/profile/2.png",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                    new ApplicationUser()
                        {
                            FirstName = "Mohamed",
                            LastName = "Ali",
                            Email = "mohamed_ali@gmail.com",
                            NormalizedEmail = "MOHAMED_ALI@GMAIL.COM",
                            UserName = "mohamed_ali@gmail.com",
                            NormalizedUserName = "MOHAMED_ALI@GMAIL.COM",
                            PhoneNumber = "01068289043",
                            UserImageURL = "../images/profile/3.png",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                    new ApplicationUser()
                        {
                            FirstName = "Mai",
                            LastName = "Ali",
                            Email = "mai_ali@gmail.com",
                            NormalizedEmail = "MAI_ALI@GMAIL.COM",
                            UserName = "mai_ali@gmail.com",
                            NormalizedUserName = "MAI_ALI@GMAIL.COM",
                             PhoneNumber = "01068289043",
                            UserImageURL = "../images/profile/4.png",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },
                    new ApplicationUser()
                        {
                            FirstName = "Ahmed",
                            LastName = "Ibrahim",
                            Email = "ahmed_ibrahim@yahoo.com",
                            NormalizedEmail = "AHMED_IBRAHIM@YAHOO.COM",
                            UserName = "ahmed_ibrahim@yahoo.com",
                            NormalizedUserName =  "AHMED_IBRAHIM@YAHOO.COM",
                            PhoneNumber = "01068289043",
                            UserImageURL = "../images/profile/5.png",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            SecurityStamp = Guid.NewGuid().ToString("D")
                        },

                };
            var password = new PasswordHasher<ApplicationUser>();
            Users[0].PasswordHash = password.HashPassword(Users[0], "Admin123$");
            Users[1].PasswordHash = password.HashPassword(Users[1], "Admin123$");
            Users[2].PasswordHash = password.HashPassword(Users[2], "Admin123$");
            Users[3].PasswordHash = password.HashPassword(Users[3], "Admin123$");
            Users[4].PasswordHash = password.HashPassword(Users[4], "Admin123$");
            modelBuilder.Entity<ApplicationUser>().HasData(Users);
            // User - Role
            var UserRole = new List<IdentityUserRole<string>>()
                {
                    new IdentityUserRole<string> (){
                        RoleId = Roles[0].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[1].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[2].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[3].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[4].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[5].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[6].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[7].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[8].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[9].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[10].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[11].Id,
                        UserId = Users[0].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[0].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[1].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[2].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[3].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[4].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[5].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[6].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[7].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[8].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[10].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[11].Id,
                        UserId = Users[1].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[2].Id,
                        UserId = Users[2].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[4].Id,
                        UserId = Users[2].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[7].Id,
                        UserId = Users[2].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[2].Id,
                        UserId = Users[3].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[4].Id,
                        UserId = Users[3].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[7].Id,
                        UserId = Users[3].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[2].Id,
                        UserId = Users[4].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[5].Id,
                        UserId = Users[4].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[7].Id,
                        UserId = Users[4].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[10].Id,
                        UserId = Users[4].Id
                    },
                    new IdentityUserRole<string> (){
                        RoleId = Roles[11].Id,
                        UserId = Users[4].Id
                    },

                };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(UserRole);

            // Home Users
            var HomeUsers = new List<HomeUser>()
                {
                    new HomeUser()
                    {
                        Id = 1,
                        FirstName = "Ali",
                        LastName = "Ahmed",
                        Email = "ali_ahmed@gmail.com",
                        Address = "In Home",
                        PhoneNumber = "01017080058",
                        UserImageURL = "../images/profile/1.png",
                    },
                    new HomeUser()
                    {
                        Id=2,
                        FirstName = "Mona",
                        LastName = "Mohamed",
                        Email = "mona_mohamed@yahoo.com",
                        Address = "In Home",
                        PhoneNumber = "01017180069",
                        UserImageURL = "../images/profile/2.png",
                    },
                    new HomeUser()
                    {
                        Id = 3,
                        FirstName = "Mohamed",
                        LastName = "Ali",
                        Email = "mohamed_ali@gmail.com",
                        Address = "In Home",
                        PhoneNumber = "01017189052",
                        UserImageURL = "../images/profile/3.png",
                    },
                    new HomeUser()
                    {
                        Id=4,
                        FirstName = "Mai",
                        LastName = "Ali",
                        Email = "mai_ali@gmail.com",
                        Address = "In Home",
                        PhoneNumber = "01069189080",
                        UserImageURL = "../images/profile/4.png",
                    },
                    new HomeUser()
                    {
                        Id=5,
                        FirstName = "Ahmed",
                        LastName = "Ibrahim",
                        Email = "ahmed_ibrahim@yahoo.com",
                        Address = "In Home",
                        PhoneNumber = "01068289043",
                        UserImageURL = "../images/profile/5.png",
                    },
                    new HomeUser()
                    {
                        Id=6,
                        FirstName = "Marwa",
                        LastName = "Saad",
                        Email = "marwa_saad@gmail.com",
                        Address = "90 Ain-shams - Cairo,Egypt",
                        PhoneNumber = "01268468933",
                        UserImageURL = "../images/profile/6.png",
                    },
                    new HomeUser()
                    {
                        Id=7,
                        FirstName = "Nada",
                        LastName = "Helmy",
                        Email = "mona_Kamel@gmail.com",
                        Address = "50 Ain-shams - Cairo,Egypt",
                        PhoneNumber = "01168237594",
                        UserImageURL = "../images/profile/7.png",
                    },

                };

            modelBuilder.Entity<HomeUser>().HasData(HomeUsers);
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
                    RoomName= "Bedroom 3"
                },
                new Room()
                {
                    Id = 5,
                    RoomName= "Leaving Room"
                },
                new Room()
                {
                    Id = 6,
                    RoomName= "Dining Room"
                },
                new Room()
                {
                    Id = 7,
                    RoomName= "Storage Room"
                },
                new Room()
                {
                    Id = 8,
                    RoomName= "Office Room"
                },
                new Room()
                {
                    Id = 9,
                    RoomName= "Garage"
                },
                new Room()
                {
                    Id = 10,
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
                    DeviceName= "Home Door",
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
                    DeviceName= "Door",
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
                    DeviceName= "AC",
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
                    DeviceName= "Door",
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
                    DeviceName= "AC",
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
                    DeviceName= "Door",
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
                    DeviceName= "Ac",
                    RoomId = 4
                },
                new Device()
                {
                    Id = 23,
                    DeviceName= "TV",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 24,
                    DeviceName= "Door",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 25,
                    DeviceName= "Sound",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 26,
                    DeviceName= "Light",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 27,
                    DeviceName= "AC",
                    RoomId = 5
                },
                new Device()
                {
                    Id = 28,
                    DeviceName= "Sound",
                    RoomId = 6
                },
                new Device()
                {
                    Id = 29,
                    DeviceName= "Light",
                    RoomId = 6
                },
                new Device()
                {
                    Id = 30,
                    DeviceName= "AC",
                    RoomId = 6
                },
                new Device()
                {
                    Id = 31,
                    DeviceName= "Light",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 32,
                    DeviceName= "Door",
                    RoomId = 7
                },
                new Device()
                {
                    Id = 33,
                    DeviceName= "TV",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 34,
                    DeviceName= "Door",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 35,
                    DeviceName= "Sound",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 36,
                    DeviceName= "Light",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 37,
                    DeviceName= "AC",
                    RoomId = 8
                },
                new Device()
                {
                    Id = 38,
                    DeviceName= "Garage Security",
                    RoomId = 9
                },
                new Device()
                {
                    Id = 39,
                    DeviceName= "Left Parking",
                    RoomId = 9
                },
                new Device()
                {
                    Id = 40,
                    DeviceName= "Right Parking",
                    RoomId = 9
                },
                new Device()
                {
                    Id = 41,
                    DeviceName= "Garage Door",
                    RoomId = 9
                },
                new Device()
                {
                    Id = 42,
                    DeviceName= "Garage Light",
                    RoomId = 9
                },
                new Device()
                {
                    Id = 43,
                    DeviceName= "Water Tank",
                    RoomId = 10
                },
                new Device()
                {
                    Id = 44,
                    DeviceName= "Irrigation System",
                    RoomId = 10
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
                    Status = 50,
                    DeviceId = 10,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 11,
                    Status = 90,
                    DeviceId = 11,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 12,
                    Status = 22,
                    DeviceId = 12,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 13,
                    Status = 0,
                    DeviceId = 13,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 14,
                    Status = 0,
                    DeviceId = 14,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 15,
                    Status = 40,
                    DeviceId = 15,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 16,
                    Status = 50,
                    DeviceId = 16,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 17,
                    Status = 20,
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
                    Status = 20,
                    DeviceId = 20,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 21,
                    Status = 25,
                    DeviceId = 21,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 22,
                    Status = 18,
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
                    Status = 0,
                    DeviceId = 24,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 25,
                    Status = 70,
                    DeviceId = 25,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 26,
                    Status = 80,
                    DeviceId = 26,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 27,
                    Status = 25,
                    DeviceId = 27,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 28,
                    Status = 20,
                    DeviceId = 28,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 29,
                    Status = 90,
                    DeviceId = 29,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 30,
                    Status = 20,
                    DeviceId = 30,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 31,
                    Status = 0,
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
                    Status = 10,
                    DeviceId = 35,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 36,
                    Status = 15,
                    DeviceId = 36,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 37,
                    Status = 20,
                    DeviceId = 37,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 38,
                    Status = 0,
                    DeviceId = 38,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 39,
                    Status = 1,
                    DeviceId = 39,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 40,
                    Status = 0,
                    DeviceId = 40,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 41,
                    Status = 0,
                    DeviceId = 41,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 42,
                    Status = 0,
                    DeviceId = 42,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 43,
                    Status = 50,
                    DeviceId = 43,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new Devices_Status()
                {
                    Id = 44,
                    Status = 90,
                    DeviceId = 44,
                    ModifyDateTime = new DateTime(2022,3,2,12,10,50)
                },
            };
            modelBuilder.Entity<Devices_Status>().HasData(DevicesStatus);

            // Home User status 
            var HomeUserStatus = new List<HomeUser_Status>()
            {
                new HomeUser_Status()
                {
                    Id = 1,
                    Status = true,
                    HomeUserId =1,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new HomeUser_Status()
                {
                    Id = 2,
                    Status = true,
                    HomeUserId =2,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new HomeUser_Status()
                {
                    Id = 3,
                    Status = true,
                    HomeUserId =3,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new HomeUser_Status()
                {
                    Id = 4,
                    Status = false,
                    HomeUserId =4,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new HomeUser_Status()
                {
                    Id = 5,
                    Status = false,
                    HomeUserId =5,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new HomeUser_Status()
                {
                    Id = 6,
                    Status = false,
                    HomeUserId =6,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },
                new HomeUser_Status()
                {
                    Id = 7,
                    Status = true,
                    HomeUserId =7,
                    StatusDateTime = new DateTime(2022,3,2,12,10,50)
                },

            };
            modelBuilder.Entity<HomeUser_Status>().HasData(HomeUserStatus);
        
            // Notifiction
            var Notifictions = new List<Notification>()
            {
                new Notification()
                {
                    Id = 1,
                    DeviceId = 1,
                    NotificationHeader = "Home Security",
                    NotificationBody ="The House is Safe Now",
                    NotificationDate = new DateTime(2022,3,2,12,10,50),
                    IsRead = true,
                    Status = false,
                },
               
                new Notification()
                {
                    Id = 2,
                    DeviceId = 3,
                    NotificationHeader = "Fire System",
                    NotificationBody ="There is no Fire in House",
                    NotificationDate = new DateTime(2022,3,2,12,10,50),
                    IsRead = true,
                    Status = false,
                },
               
                new Notification()
                {
                    Id = 3,
                    DeviceId = 4,
                    NotificationHeader = "Smoke System",
                    NotificationBody ="There is no Smoke in House",
                    NotificationDate = new DateTime(2022,3,2,12,10,50),
                    IsRead = true,
                    Status = false,
                },
               
                new Notification()
                {
                    Id = 4,
                    DeviceId = 32,
                    NotificationHeader = "Garage Security",
                    NotificationBody ="The Garage is Safe Now",
                    NotificationDate = new DateTime(2022,3,2,12,10,50),
                    IsRead = true,
                    Status = false,
                },
               

            };
            modelBuilder.Entity<Notification>().HasData(Notifictions);

        }
    }
}
