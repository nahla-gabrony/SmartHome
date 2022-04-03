using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string UserTypeName { get; set; }

        //Relationship
        public ICollection<HomeUser> HomeUsers { get; set; }
    }
}
