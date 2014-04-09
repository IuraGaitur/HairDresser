using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using GetHairDresser.Common.Entities;

namespace GetHairDresser.Common
{
    [DataContract]
    public class User
    {
        [Key]
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastName { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public int age { get; set; }

        [DataMember]
        public string gender { get; set; }

        [DataMember]
        public string location { get; set; }

        [DataMember]
        public virtual List<JobAppointment> JobAppointments { get; set; }

        [DataMember]
        public virtual List<Message> receivedListMessages { get; set; }

        [DataMember]
        public virtual List<Message> sendListMessages { get; set; }

        [DataMember]
        public string typeClient { get; set; }

        [DataMember]
        public string UserFacebook { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        [Required]
        public virtual HairdresInfo hairdressInfo { get; set; }

    }
}
