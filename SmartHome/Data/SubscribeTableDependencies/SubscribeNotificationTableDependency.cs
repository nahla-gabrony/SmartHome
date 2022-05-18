using SmartHome.Data.Hubs;
using SmartHome.Models;
using System;
using TableDependency.SqlClient;

namespace SmartHome.Data.SubscribeTableDependencies
{
    public class SubscribeNotificationTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Notification> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeNotificationTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

 
        public void SubscribeTableDependency(string connectionString)
        {  
            tableDependency = new SqlTableDependency<Notification>(connectionString);
            tableDependency.OnChanged +=  TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Notification> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
              await  dashboardHub.SendNotificationsData();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Devices_Status)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
