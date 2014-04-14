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
    
    public class MessageDTO
    {
        [Key]
        public int MessageID { get; set; }

        public string text { get; set; }

        public  UserDTO senderID { get; set; }

        public  UserDTO receiverID { get; set; }

        public MessageDTO()
        {
            //senderID = new UserDTO();
            //receiverID = new UserDTO();
        }
    }
}
