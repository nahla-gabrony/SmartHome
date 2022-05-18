using System;

namespace SmartHome.Data.ViewModels.Home
{
    public class HomeUsersHistoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserImageURL { get; set; }
        public bool Status { get; set; }
        public DateTime CurrentStatusDateTime { get; set; }
        public DateTime LastEntringDateTime { get; set; }



    }
}
