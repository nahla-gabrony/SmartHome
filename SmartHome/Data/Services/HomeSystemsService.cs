using Microsoft.EntityFrameworkCore;
using SmartHome.Data.HelperFunction;
using SmartHome.Data.ViewModels.Home;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class HomeSystemsService
    {
        string connectionString;
        public HomeSystemsService(string connectionString)
        {
             this.connectionString = connectionString;
        }

        public List<Systems_Status> GetHomeSystems()  
        {
            List<Systems_Status> HomeSystems = new List<Systems_Status>();
            Systems_Status HomeSystemsdata;

            var data = GetData.GetDataFromDb(connectionString, "SpGetHomeSystemData");
            foreach (DataRow row in data.Rows)
            {
                HomeSystemsdata = new Systems_Status
                {
                    Id =  Convert.ToInt32(row["Id"]) ,
                    Status =  Convert.ToInt32(row["Status"]) ,
                    SystemId =  Convert.ToInt32(row["SystemId"]) ,
                };
                HomeSystems.Add(HomeSystemsdata);
            }

            return HomeSystems;
        }
    }
}
