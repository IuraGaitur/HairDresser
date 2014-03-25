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
    public class Message
    {
        [Key]
        [DataMember]
        public int MessageID { get; set; }
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public virtual User senderID { get; set; }
        [DataMember]
        public virtual User receiverID { get; set; }
    }
}
