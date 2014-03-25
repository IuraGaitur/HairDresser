using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GetHairDresser.Common.DAL.Entities
{
    
    public class MessageDTO
    {
        [Key]
        public int MessageID { get; set; }
        
        public string text { get; set; }
        
        public virtual UserDTO senderID { get; set; }
        
        public virtual UserDTO receiverID { get; set; }
    }
}
