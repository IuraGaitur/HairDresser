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
    
    public class JobAppointmentDTO
    {
        [Key]
        public int JobAppID { get; set; }

        public DateTime DateJob { get; set; }

        public TimeSpan HourJob { get; set; }

        public int Status { get; set; }

        public  UserDTO Hairdresser { get; set; }

        public JobAppointmentDTO()
        {
            //Hairdresser = new UserDTO();
        }
    }
}
