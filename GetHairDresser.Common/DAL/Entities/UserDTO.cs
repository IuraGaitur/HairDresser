using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GetHairDresser.Common.DAL.Entities
{
    public class UserDTO
    {

        [Key]
        public int UserId { get; set; }

        
        public string firstName { get; set; }

        
        public string lastName { get; set; }

        
        public string email { get; set; }

        
        public int age { get; set; }

        
        public string gender { get; set; }

        
        public string location { get; set; }

        
        public virtual List<JobAppointmentDTO> JobAppointments { get; set; }

        
        public string typeClient { get; set; }

        
        public string UserFacebook { get; set; }

        
        public Guid UserGuid { get; set; }


    }
}
