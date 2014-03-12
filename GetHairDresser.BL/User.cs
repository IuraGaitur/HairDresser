using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.BL
{
    public class User
    {
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public virtual List<JobAppointment> JobAppointments { get; set; }

    }
}
