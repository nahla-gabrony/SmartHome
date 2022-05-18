using SmartHome.Data.HelperFunction;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartHome.Data.SignalRServices
{
    public class HomeUserStatusService 
    {
     
        string connectionString;
        public HomeUserStatusService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<HomeUser> GetUserData()
        {
            List<HomeUser_Status> UsersLogs = new List<HomeUser_Status>();
            HomeUser_Status UsersLogdata;

            var data = GetData.GetDataFromDb(connectionString, "SpGetUsersData");

            foreach (DataRow row in data.Rows)
            {
                UsersLogdata = new HomeUser_Status
                {
                    Id = Convert.ToInt32(row["Id"]),
                    HomeUserId = Convert.ToInt32(row["HomeUserId"]),
                    Status = Convert.ToBoolean(row["Status"]),
                };
                UsersLogs.Add(UsersLogdata);
            }


            List<HomeUser> Users = new List<HomeUser>();
            HomeUser NewUserData;
            foreach (var user in UsersLogs)
            {
                var UserId = user.HomeUserId;
                var Usersdata = GetData.GetDataFromDb(connectionString, "SpGetHomeUsers", UserId);
                foreach (DataRow row in Usersdata.Rows)
                {
                    NewUserData = new HomeUser
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        FirstName = row["FirstName"].ToString(),
                        UserImageURL = row["UserImageURL"].ToString(),
                    };
                    Users.Add(NewUserData);
                }
                
            }
            return Users;
        }
   
    }
}
