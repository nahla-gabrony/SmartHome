using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class UserHome_Logs
    {
        public int Id { get; set; }
        public DateTime LogDateTime { get; set; }
        public bool Status { get; set; }

        //Relationship
        public int HomeUserId { get; set; }
        [ForeignKey("HomeUserId")]
        public HomeUser HomeUser { get; set; }
    }
}
