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
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.BL.Mapper;


namespace GetHairDresser.BL
{
    
    public class JobAppointmentsBLL:IJobAppointmentsManager
    {
        IMapperJobAppointment mapper;

        public JobAppointmentsBLL()
        {
            mapper = new JobAppointMapper();
            
        }


        IRepository repository = RepositoryLocator.GetRepository();
        public bool AddJobAppointment(JobAppointment jobapp)
        {
            if (jobapp != null)
            {
                repository.AddJobAppointment(mapper.MapJobAppointmentDTO(jobapp));
                return true;
            }

            return false;
        }

        public bool EditJobAppointment(JobAppointment jobapp)
        {
            if (jobapp != null)
            {
                repository.EditJobAppointment(mapper.MapJobAppointmentDTO(jobapp));
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
                IMapperUser userMap = new UserMapper();
                temp_jobs = repository.GetJobAppointmentsByDate(userMap.MapUserDTO(user), date);
                foreach (var temp in temp_jobs)
                {
                    jobs.Add(mapper.MapJobAppointment(temp));
                }


            }
            return jobs;
        }

        public List<JobAppointment> GetJobAppointments(User user)
        {
            List<JobAppointment> jobs = new List<JobAppointment>();
            List<JobAppointmentDTO> temp_jobs = null;
            if (user != null)
            {
                IMapperUser userMap = new UserMapper();
                temp_jobs = repository.GetJobAppointments(userMap.MapUserDTO(user));
                foreach (var temp in temp_jobs)
                {
                    jobs.Add(mapper.MapJobAppointment(temp));
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
