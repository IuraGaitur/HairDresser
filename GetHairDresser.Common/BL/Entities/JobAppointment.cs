using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GetHairDresser.Common
{
    [DataContract]
    public class JobAppointment
    {
        [Key]
        [DataMember]
        public int JobAppID { get; set; }

        [DataMember]
        public DateTime DateJob { get; set; }

        [DataMember]
        public TimeSpan HourJob { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public  User Hairdresser { get; set; }

        public JobAppointment()
        {
            Hairdresser = new User();
        }
    }
}
