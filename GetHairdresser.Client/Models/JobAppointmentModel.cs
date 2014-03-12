using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GetHairdresser.Client.Models
{
    public class JobAppointment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int JobAppointmentsID { get; set; }
        public DateTime jobDate { get; set; }
        public DateTime jobHour { get; set; }
        public virtual UserProfile UserProfile{get;set;}


    }

}