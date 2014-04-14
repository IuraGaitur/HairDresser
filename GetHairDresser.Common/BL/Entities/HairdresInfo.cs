using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GetHairDresser.Common.Entities
{
    [DataContract]
    public class HairdresInfo
    {
        [Key]
        [DataMember]
        public int HairdressInfoID{get;set;}
        [DataMember]
        public string map_data { get; set; }
        [DataMember]
        public double rating { get; set; }
        [DataMember]
        public string photo { get; set; }
        [DataMember]
        public User HairdressID { get; set; }

        public HairdresInfo()
        {
            //HairdressID = new User();
        }
    }
}
