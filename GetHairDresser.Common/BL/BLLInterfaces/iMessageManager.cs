using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    /// <summary>
    /// Manage with user's messages
    /// </summary>
    public interface iMessageManager
    {
        /// <summary>
        /// Add a message to a user
        /// </summary>
        /// <param name="message">Message send</param>
        /// <returns>Passed with success</returns>
        bool AddMessage(Message message);
        /// <summary>
        /// Edit user's message 
        /// </summary>
        /// <param name="message">Message changed</param>
        /// <returns>Passed with success</returns>
        bool EditMessage(Message message);
        /// <summary>
        /// Delete user's message
        /// </summary>
        /// <param name="id">Message id</param>
        /// <returns>Passed with success</returns>
        bool DeleteMessage(int id);
        /// <summary>
        /// Get all messages for a user
        /// </summary>
        /// <param name="id">User receiver's id</param>
        /// <returns>List messages</returns>
        List<Message> GetListMessagesForUser(int id);


    }
}
