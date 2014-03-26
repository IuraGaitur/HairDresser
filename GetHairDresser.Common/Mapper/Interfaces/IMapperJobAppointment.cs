using GetHairDresser.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.Mapper.Interfaces
{
    public interface IMapperJobAppointment
    {
        JobAppointmentDTO MapJobAppointmentDTO(JobAppointment appoint);

        JobAppointment MapJobAppointment(JobAppointmentDTO appoint);
    }
}
