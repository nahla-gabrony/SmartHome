using SmartHome.Data.Hubs;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace SmartHome.Data.SubscribeTableDependencies
{
    public class SubscribeUsersTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Users_Logs> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeUsersTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

 
        public void SubscribeTableDependency(string connectionString)
        {  
            tableDependency = new SqlTableDependency<Users_Logs>(connectionString);
            tableDependency.OnChanged +=  TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Users_Logs> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
              await  dashboardHub.SendUserData();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Users_Logs)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
