using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Repository;
using SmartHome.Data.ViewModels.Home;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;
using SmartHome.Data.HelperFunction;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class UserHomeServices 
    {
     
        string connectionString;
        public UserHomeServices(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<HomeUser> GetUserData()
        {
            List<Users_Logs> UsersLogs = new List<Users_Logs>();
            Users_Logs UsersLogdata;

            var data = GetData.GetDataFromDb(connectionString,"SpGetUsers");

            foreach (DataRow row in data.Rows)
            {
                UsersLogdata = new Users_Logs
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
