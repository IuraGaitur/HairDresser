using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.Common;
using GetHairDresser.Common.DAL.Entities;
using AutoMapper;


namespace GetHairDresser.BL.Mapper
{
    /// <summary>
    /// Map for JobAppointments
    /// </summary>
    public class JobAppointMapper : IMapperJobAppointment
    {
        public JobAppointMapper()
        {
            AutoMapper.Mapper.CreateMap<JobAppointmentDTO, JobAppointment>();
            AutoMapper.Mapper.CreateMap<JobAppointment, JobAppointmentDTO>();
        }

        public JobAppointmentDTO MapJobAppointmentDTO(JobAppointment appoint)
        {
            return AutoMapper.Mapper.Map<JobAppointmentDTO>(appoint);
        }

        public JobAppointment MapJobAppointment(JobAppointmentDTO appoint)
        {
            return AutoMapper.Mapper.Map<JobAppointment>(appoint);
        }
    }
}
