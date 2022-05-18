using SmartHome.Data.Hubs;
using SmartHome.Models;
using System;
using TableDependency.SqlClient;

namespace SmartHome.Data.SubscribeTableDependencies
{
    public class SubscribeUsersTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<HomeUser_Status> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeUsersTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

 
        public void SubscribeTableDependency(string connectionString)
        {  
            tableDependency = new SqlTableDependency<HomeUser_Status>(connectionString);
            tableDependency.OnChanged +=  TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<HomeUser_Status> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
              await  dashboardHub.SendUserData();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(HomeUser_Status)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
