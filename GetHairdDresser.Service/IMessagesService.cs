using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    /// <summary>
    /// Service that manage with user's messages
    /// </summary>
    [ServiceContract]
    public interface IMessagesService
    {
        /// <summary>
        /// Add a message to a user
        /// </summary>
        /// <param name="message">Message send</param>
        /// <returns>Passed with success</returns>
        [OperationContract]
        bool AddMessage(Message message);
        /// <summary>
        /// Edit user's message 
        /// </summary>
        /// <param name="message">Message changed</param>
        /// <returns>Passed with success</returns>
        [OperationContract]
        bool EditMessage(Message message);
        /// <summary>
        /// Delete user's message
        /// </summary>
        /// <param name="id">Message id</param>
        /// <returns>Passed with success</returns>
        [OperationContract]
        bool DeleteMessage(int id);
        /// <summary>
        /// Get all messages for a user
        /// </summary>
        /// <param name="id">User receiver's id</param>
        /// <returns>List messages</returns>
        [OperationContract]
        List<Message> GetListMessagesForUser(int id);
    }
}
