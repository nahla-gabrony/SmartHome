using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class HomeSystem
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
 

        //Relationship
        public ICollection<Systems_Status> SystemStatus { get; set; }

    
    }
}
