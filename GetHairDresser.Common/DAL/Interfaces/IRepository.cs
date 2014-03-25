using GetHairDresser.Common.DAL.Entities;
using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.Interfaces
{
    public interface IRepository
    {
        //User

         void AddUser(UserDTO user);

         void EditUser(UserDTO user);

         void DeleteUser(int id);

         UserDTO GetUser(Guid id);

         UserDTO GetUserByFacebook(string facebookId);

         List<UserDTO> GetUsers();

         List<UserDTO> SearchUsers(string name);


        //JobAppointment
         void AddJobAppointment(JobAppointmentDTO jobapp);

         void EditJobAppointment(JobAppointmentDTO jobapp);

         void DeleteJobAppointment(int id);

         List<JobAppointmentDTO> GetJobAppointmentsByDate(UserDTO user, DateTime date);

         List<JobAppointmentDTO> GetJobAppointments(UserDTO user);

         List<JobAppointmentDTO> GetTypedJobAppointmentsByDate(UserDTO user, int status);
        
        //UserType
        void ChangeUserType(int id, string hairdresser);

        string GetUserType(int id);


        //Messages

        void AddMessage(MessageDTO message);

        void EditMessage(MessageDTO message);

        void DeleteMessage(int id);

        List<MessageDTO> GetMessagesSend(int id);

        List<MessageDTO> GetMessagesReceived(int id);



        //HairdressInfo

        void EditHairdressInfo(UserDTO user, HairdresInfoDTO info);
        void EditHairdressInfoMap(UserDTO user, string map);
        void EditHairdressInfoPhoto(UserDTO user, string photo);
        void EditHairdressInfoRating(UserDTO user, double rating);

        HairdresInfoDTO GetHairdressInfo(int id);

        void DeleteHairdressInfo(UserDTO user);

        



    }
}
