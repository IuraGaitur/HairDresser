using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    /// <summary>
    /// Service is responsible for manage Hairdresser job appointments
    /// </summary>
    [ServiceContract]
    public interface IJobAppointmentsService
    {
        /// <summary>
        /// Add a job appointment for a hairdress
        /// </summary>
        /// <param name="jobapp">Job appointment instance</param>
        /// <returns>Passed with success</returns>
        [OperationContract]
        bool AddJobAppointment(JobAppointment jobapp);
        /// <summary>
        /// Edit a job appointment for a hairdress
        /// </summary>
        /// <param name="jobapp">Job appointment instance</param>
        /// <returns>Passed with success</returns>
        [OperationContract]
        bool EditJobAppointment(JobAppointment jobapp);
        /// <summary>
        /// Delete a job appointment for a hairdress
        /// </summary>
        /// <param name="jobapp">Job appointment id</param>
        /// <returns>Passed with success</returns>
        [OperationContract]
        bool DeleteJobAppointment(int id);
        /// <summary>
        /// Get job appointment for a hairdress for a specified day
        /// </summary>
        /// <param name="user">Hairdress data</param>
        /// <param name="date">Day</param>
        /// <returns>Hairdress job appointments list for a day </returns>
        [OperationContract]
        List<JobAppointment> GetJobAppointmentsByDate(User user, DateTime date);
        /// <summary>
        /// Get all job appointment for a hairdress 
        /// </summary>
        /// <param name="user">Hairdress data</param>
        /// <returns>Hairdress job appointments list for a day </returns>
        [OperationContract]
        List<JobAppointment> GetJobAppointments(User user);
        /// <summary>
        /// Get all job appointment for a hairdress
        /// </summary>
        /// <param name="user">Hairdress data</param>
        /// <param name="status">Status:inactive,in processing,active</param>
        /// <returns>Hairdress job appointments list for a day </returns>
        [OperationContract]
        List<JobAppointment> GetTypedJobAppointmentsByDate(User user, int status);
    }
}
