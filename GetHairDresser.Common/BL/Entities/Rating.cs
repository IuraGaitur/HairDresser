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
    public class Rating
    {
        [Key]
        [DataMember]
        public int RatingID { get; set; }
        [DataMember]
        public  User userIdRating { get; set; }
        [DataMember]
        public double totalRate { get; set; }
        [DataMember]
        public int votes { get; set; }

        public Rating()
        {
            userIdRating = new User();
        }
    }
}
