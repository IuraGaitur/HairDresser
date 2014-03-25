using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GetHairDresser.Common.DAL.Entities
{
   
    public class RatingDTO
    {
       [Key]
        public int RatingID { get; set; }
      
        public virtual UserDTO userIdRating { get; set; }
        
        public double totalRate { get; set; }
        
        public int votes { get; set; }
    }
}
