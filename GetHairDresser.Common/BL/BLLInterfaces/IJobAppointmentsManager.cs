using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    /// <summary>
    /// Manage Hairdresser job appointments
    /// </summary>
    public interface IJobAppointmentsManager
    {
        /// <summary>
        /// Add a job appointment for a hairdress
        /// </summary>
        /// <param name="jobapp">Job appointment instance</param>
        /// <returns>Passed with success</returns>
        bool AddJobAppointment(JobAppointment jobapp);
        /// <summary>
        /// Edit a job appointment for a hairdress
        /// </summary>
        /// <param name="jobapp">Job appointment instance</param>
        /// <returns>Passed with success</returns>
        bool EditJobAppointment(JobAppointment jobapp);
        /// <summary>
        /// Delete a job appointment for a hairdress
        /// </summary>
        /// <param name="jobapp">Job appointment id</param>
        /// <returns>Passed with success</returns>
        bool DeleteJobAppointment(int id);
        /// <summary>
        /// Get job appointment for a hairdress for a specified day
        /// </summary>
        /// <param name="user">Hairdress data</param>
        /// <param name="date">Day</param>
        /// <returns>Hairdress job appointments list for a day </returns>
        List<JobAppointment> GetJobAppointmentsByDate(User user, DateTime date);
        /// <summary>
        /// Get all job appointment for a hairdress 
        /// </summary>
        /// <param name="user">Hairdress data</param>
        /// <returns>Hairdress job appointments list for a day </returns>
        List<JobAppointment> GetJobAppointments(User user);
        /// <summary>
        /// Get all job appointment for a hairdress
        /// </summary>
        /// <param name="user">Hairdress data</param>
        /// <param name="status">Status:inactive,in processing,active</param>
        /// <returns>Hairdress job appointments list for a day </returns>
        List<JobAppointment> GetTypedJobAppointmentsByDate(User user, int status);

    }
}
