using SmartHome.Data.HelperFunction;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SmartHome.Data.SignalRServices
{
    public class NotificationStatusService
    {
        string connectionString;
        public NotificationStatusService(string connectionString)
        {
             this.connectionString = connectionString;
        }

        public List<Notification> GetNotificationsData()
        {
            List<Notification> Notifications = new List<Notification>();
            Notification NotificationData;

            var data = GetData.GetDataFromDb(connectionString, "SpGetNotifications");
            foreach (DataRow row in data.Rows)
            {
                NotificationData = new Notification
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Status = Convert.ToBoolean(row["Status"]),
                    IsRead = Convert.ToBoolean(row["IsRead"]),
                    DeviceId = Convert.ToInt32(row["DeviceId"]),
                    NotificationBody = row["NotificationBody"].ToString(),
                    NotificationHeader = row["NotificationHeader"].ToString(),
                    NotificationDate = Convert.ToDateTime(row["NotificationDate"]),
                };
                Notifications.Add(NotificationData);
            }

            return Notifications;
        }
    }
}
