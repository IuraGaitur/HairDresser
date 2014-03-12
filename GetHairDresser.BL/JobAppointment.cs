using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.BL
{
    public class JobAppointment
    {
        public int JobAppID { get; set; }
        public DateTime DateJob { get; set; }
        public TimeSpan HourJob { get; set; }
        public int Status { get; set; }
        public virtual User Hairdresser{ get; set; }
    }
}
