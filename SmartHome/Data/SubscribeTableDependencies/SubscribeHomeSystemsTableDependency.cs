using SmartHome.Data.Hubs;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace SmartHome.Data.SubscribeTableDependencies
{
    public class SubscribeHomeSystemsTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Systems_Status> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeHomeSystemsTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

 
        public void SubscribeTableDependency(string connectionString)
        {  
            tableDependency = new SqlTableDependency<Systems_Status>(connectionString);
            tableDependency.OnChanged +=  TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Systems_Status> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
              await  dashboardHub.SendSystemsData();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Systems_Status)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
