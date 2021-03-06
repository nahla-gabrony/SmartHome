using System.Collections.Generic;

namespace SmartHome.Models
{
    public class HomeUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserImageURL { get; set; }

        //Relationship
        public ICollection<HomeUser_Status> UserHomeLogs { get; set; }



    }
}
