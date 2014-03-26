using GetHairDresser.Common.DAL.Entities;
using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.Interfaces
{
    /// <summary>
    /// Works with all the necessary methods what write and read from database
    /// </summary>
    public interface IRepository
    {
        //User
        /// <summary>
        /// Add a user in database
        /// </summary>
        /// <param name="user">User instance</param>
         void AddUser(UserDTO user);
        /// <summary>
        /// Edit a user from db
        /// </summary>
        /// <param name="user">user instance</param>
         void EditUser(UserDTO user);
        /// <summary>
        /// Delete a user from db
        /// </summary>
        /// <param name="id">user id</param>
         void DeleteUser(int id);
         /// <summary>
         /// Get user data from db by a Guid id 
         /// </summary>
         /// <param name="id">User identificato</param>
         /// <returns>A user instance from db</returns>
         UserDTO GetUser(Guid id);
         /// <summary>
         /// Get user data from db by a id from facebook
         /// </summary>
         /// <param name="facebookId">Facebook id from token</param>
         /// <returns>A user instance</returns>
         UserDTO GetUserByFacebook(string facebookId);
        /// <summary>
        /// Get all users from db
        /// </summary>
        /// <returns>List with UserDTO instances</returns>
         List<UserDTO> GetUsers();
        /// <summary>
        /// Search a user/users
        /// </summary>
        /// <param name="name">List of users instances</param>
        /// <returns></returns>
         List<UserDTO> SearchUsers(string name);


        //JobAppointment
         /// <summary>
         /// Add a job appointment for a hairdress
         /// </summary>
         /// <param name="jobapp">Job appointment instance</param>
         void AddJobAppointment(JobAppointmentDTO jobapp);
         /// <summary>
         /// Edit a job appointment for a hairdress
         /// </summary>
         /// <param name="jobapp">Job appointment instance</param>
         void EditJobAppointment(JobAppointmentDTO jobapp);
         /// <summary>
         /// Delete a job appointment for a hairdress
         /// </summary>
         /// <param name="jobapp">Job appointment id</param>
         void DeleteJobAppointment(int id);
         /// <summary>
         /// Get job appointment for a hairdress for a specified day
         /// </summary>
         /// <param name="user">Hairdress data</param>
         /// <param name="date">Day</param>
         /// <returns>Hairdress job appointments list for a day </returns>
         List<JobAppointmentDTO> GetJobAppointmentsByDate(UserDTO user, DateTime date);
         /// <summary>
         /// Get all job appointment for a hairdress 
         /// </summary>
         /// <param name="user">Hairdress data</param>
         /// <returns>Hairdress job appointments list for a day </returns>
         List<JobAppointmentDTO> GetJobAppointments(UserDTO user);
         /// <summary>
         /// Get all job appointment for a hairdress
         /// </summary>
         /// <param name="user">Hairdress data</param>
         /// <param name="status">Status:inactive,in processing,active</param>
         /// <returns>Hairdress job appointments list for a day </returns>
         List<JobAppointmentDTO> GetTypedJobAppointmentsByDate(UserDTO user, int status);
        
        /// <summary>
        /// Change user's category:client,hairdress
        /// </summary>
        /// <param name="id">User's id</param>
        /// <param name="hairdresser">Type of category:client,hairdress</param>
        void ChangeUserType(int id, string hairdresser);
        /// <summary>
        /// Return User type:client,hairdress
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>User type:client,hairdress</returns>
        string GetUserType(int id);


        //Messages
        /// <summary>
        /// Add a message to a user
        /// </summary>
        /// <param name="message">Message send</param>
        void AddMessage(MessageDTO message);
        /// <summary>
        /// Edit user's message 
        /// </summary>
        /// <param name="message">Message changed</param>
        void EditMessage(MessageDTO message);
        /// <summary>
        /// Delete user's message
        /// </summary>
        /// <param name="id">Message id</param>
        void DeleteMessage(int id);
        /// <summary>
        /// Get all messages sended by a user
        /// </summary>
        /// <param name="id">Sender's id</param>
        /// <returns>List messages</returns>
        List<MessageDTO> GetMessagesSend(int id);
        /// <summary>
        /// Get all messages received by a user
        /// </summary>
        /// <param name="id">Receiver's id</param>
        /// <returns>List messages</returns>
        List<MessageDTO> GetMessagesReceived(int id);



        //HairdressInfo
        /// <summary>
        /// Set details of one hairdress instance
        /// </summary>
        /// <param name="info"> Haidress instance what will be set</param>
        void EditHairdressInfo(UserDTO user, HairdresInfoDTO info);
        void EditHairdressInfoMap(UserDTO user, string map);
        void EditHairdressInfoPhoto(UserDTO user, string photo);
        void EditHairdressInfoRating(UserDTO user, double rating);
        /// <summary>
        /// Get inform about hairdress
        /// </summary>
        /// <param name="id">ID of the hairdress</param>
        /// <returns>Hairdress class</returns>
        HairdresInfoDTO GetHairdressInfo(int id);

        void DeleteHairdressInfo(UserDTO user);

        



    }
}
