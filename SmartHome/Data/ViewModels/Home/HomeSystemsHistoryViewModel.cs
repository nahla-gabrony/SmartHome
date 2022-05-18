using System;

namespace SmartHome.Data.ViewModels.Home
{
    public class HomeSystemsHistoryViewModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public int DeviceId { get; set; }
        public string SystemName { get; set; }
        public string IconName { get; set; }
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }

    }
}
