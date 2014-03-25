using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    public interface IJobAppointments
    {
        bool AddJobAppointment(JobAppointment jobapp);

        bool EditJobAppointment(JobAppointment jobapp);

        bool DeleteJobAppointment(int id);

        List<JobAppointment> GetJobAppointmentsByDate(User user, DateTime date);

        List<JobAppointment> GetJobAppointments(User user);

        List<JobAppointment> GetTypedJobAppointmentsByDate(User user, int status);

    }
}
