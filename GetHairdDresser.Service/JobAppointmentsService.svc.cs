using GetHairDresser.BL;
using GetHairDresser.Common;
using GetHairDresser.Common.BLLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JobAppointmentsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JobAppointmentsService.svc or JobAppointmentsService.svc.cs at the Solution Explorer and start debugging.
    public class JobAppointmentsService : IJobAppointmentsService
    {
        private IJobAppointmentsManager jobs { get; set; }
        public JobAppointmentsService(IJobAppointmentsManager iJob)
        {
            jobs = iJob;
        }
        public bool AddJobAppointment(JobAppointment jobapp)
        {
            return jobs.AddJobAppointment(jobapp);
        }

        public bool EditJobAppointment(JobAppointment jobapp)
        {
            return jobs.EditJobAppointment(jobapp);
        }

        public bool DeleteJobAppointment(int id)
        {
            return jobs.DeleteJobAppointment(id);
        }

        public List<JobAppointment> GetJobAppointmentsByDate(User user, DateTime date)
        {
            return jobs.GetJobAppointmentsByDate(user, date);
        }

        public List<JobAppointment> GetJobAppointments(User user)
        {
            return jobs.GetJobAppointments(user);
        }

        public List<JobAppointment> GetTypedJobAppointmentsByDate(User user, int status)
        {
            return jobs.GetTypedJobAppointmentsByDate(user, status);
        }
    }
}
