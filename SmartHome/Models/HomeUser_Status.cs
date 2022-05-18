using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHome.Models
{
    public class HomeUser_Status
    {
        public int Id { get; set; }
        public DateTime StatusDateTime { get; set; }
        public bool Status { get; set; }

        //Relationship
        public int HomeUserId { get; set; }
        [ForeignKey("HomeUserId")]
        public HomeUser HomeUser { get; set; }
    }
}
