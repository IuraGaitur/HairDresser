using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common;
using GetHairDresser.Common.BLLInterfaces;
using GetHairDresser.Common.Interfaces;
using GetHairDresser.DAL;
using AutoMapper;
using GetHairDresser.Common.DAL.Entities;


namespace GetHairDresser.BL
{
    
    public class JobAppointmentsBLL:IJobAppointments
    {

        IRepository repository = RepositoryLocator.GetRepository();
        public bool AddJobAppointment(JobAppointment jobapp)
        {
            if (jobapp != null)
            {
                JobAppointmentDTO job = Mapper.Map<JobAppointmentDTO>(jobapp);
                repository.AddJobAppointment(job);
                return true;
            }

            return false;
        }

        public bool EditJobAppointment(JobAppointment jobapp)
        {
            if (jobapp != null)
            {
                JobAppointmentDTO job = Mapper.Map<JobAppointmentDTO>(jobapp);
                repository.EditJobAppointment(job);
                return true;
            }

            return false;
        }

        public bool DeleteJobAppointment(int id)
        {
            if (id != 0)
            {
                repository.DeleteJobAppointment(id);
                return true;
            }

            return false;
        }

        public List<JobAppointment> GetJobAppointmentsByDate(User user, DateTime date)
        {
            List<JobAppointment> jobs = null;
            List<JobAppointmentDTO> temp_jobs = null;
            if (user != null)
            {
                UserDTO temp_user = Mapper.Map<UserDTO>(user);
                temp_jobs = repository.GetJobAppointmentsByDate(temp_user, date);
                foreach (var temp in temp_jobs)
                {
                    jobs.Add(Mapper.Map<JobAppointment>(temp));
                }


            }
            return jobs;
        }

        public List<JobAppointment> GetJobAppointments(User user)
        {
            List<JobAppointment> jobs = null;
            List<JobAppointmentDTO> temp_jobs = null;
            if (user != null)
            {
                UserDTO temp_user = Mapper.Map<UserDTO>(user);
                temp_jobs = repository.GetJobAppointments(temp_user);
                foreach (var temp in temp_jobs)
                {
                    jobs.Add(Mapper.Map<JobAppointment>(temp));
                }
                
            }
            return jobs;
        }

        public List<JobAppointment> GetTypedJobAppointmentsByDate(User user, int status)
        {
            //List<JobAppointment> jobs = null;
            //List<JobAppointmentDTO> temp_jobs = null;
            //if (user != null)
            //{
            //    UserDTO temp_user = Mapper.Map<UserDTO>(user);
            //    temp_jobs = repository.GetJobAppointments(temp_user);
            //    foreach (var temp in temp_jobs)
            //    {
            //        jobs.Add(Mapper.Map<JobAppointment>(temp));
            //    }

            //}
            //return jobs;
            return null;
        }


        
    }
}
