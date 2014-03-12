using GetHairDresser.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.DAL.Interfaces
{
    interface IRepository
    {
        public void AddUser(User user);

        public void EditUser(User user);

        public void DeleteUser(int id);

        public void AddJobAppointment(BL.JobAppointment jobapp);

        public void EditJobAppointment(BL.JobAppointment jobapp);

        public void DeleteJobAppointment(int id);
    }
}
