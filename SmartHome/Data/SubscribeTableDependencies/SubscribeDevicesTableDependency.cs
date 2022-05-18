using SmartHome.Data.Hubs;
using SmartHome.Models;
using System;
using TableDependency.SqlClient;

namespace SmartHome.Data.SubscribeTableDependencies
{
    public class SubscribeDevicesTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Devices_Status> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeDevicesTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

 
        public void SubscribeTableDependency(string connectionString)
        {  
            tableDependency = new SqlTableDependency<Devices_Status>(connectionString);
            tableDependency.OnChanged +=  TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Devices_Status> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
              await  dashboardHub.SendDevicesData();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Devices_Status)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
