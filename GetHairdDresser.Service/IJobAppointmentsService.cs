using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJobAppointmentsService" in both code and config file together.
    [ServiceContract]
    public interface IJobAppointmentsService
    {
        [OperationContract]
        bool AddJobAppointment(JobAppointment jobapp);
        [OperationContract]
        bool EditJobAppointment(JobAppointment jobapp);
        [OperationContract]
        bool DeleteJobAppointment(int id);
        [OperationContract]
        List<JobAppointment> GetJobAppointmentsByDate(User user, DateTime date);
        [OperationContract]
        List<JobAppointment> GetJobAppointments(User user);
        [OperationContract]
        List<JobAppointment> GetTypedJobAppointmentsByDate(User user, int status);
    }
}
