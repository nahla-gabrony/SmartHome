﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public ICollection<UserHome_Logs> UserHomeLogs { get; set; }
        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public int UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }


    }
}
