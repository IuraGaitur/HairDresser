using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetHairDresser.Common.DAL.Entities
{
    
    public class HairdresInfoDTO
    {
        [Key, ForeignKey("HairdressID")]
        public int HairdressInfoID{get;set;}
        
        public string map_data { get; set; }
        
        public double rating { get; set; }
        
        public string photo { get; set; }
        
        public virtual UserDTO HairdressID { get; set; }
    }
}
