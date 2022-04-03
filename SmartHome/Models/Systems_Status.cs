using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Systems_Status
    {
        public int Id { get; set; }
        public int Status { get; set; }

        //Relationship
        public int SystemId { get; set; }
        [ForeignKey("SystemId")]
        public HomeSystem HomeSystem { get; set; }
    }
}
