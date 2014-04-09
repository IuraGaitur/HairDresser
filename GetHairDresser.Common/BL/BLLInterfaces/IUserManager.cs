using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    /// <summary>
    /// IUserManage is responsible for registering/login/add/edit/get user data 
    /// </summary>
    public interface IUserManage
    {
        /// <summary>
        /// Check if a user exist in database
        /// </summary>
        /// <param name="user">User details</param>
        /// <returns>A bool if such a user exist or not</returns>
        bool Login(User user);
        
        /// <summary>
        /// Register a user in database
        /// </summary>
        /// <param name="u">User instance</param>
        /// <returns>A bool if user was insert in db</returns>
        bool Register(User u);
        /// <summary>
        /// Get user data from db by a Guid id 
        /// </summary>
        /// <param name="id">User identificato</param>
        /// <returns>A user instance from db</returns>
        User GetUserData(Guid id);
        /// <summary>
        /// Get user data from db by a id from facebook
        /// </summary>
        /// <param name="facebookId">Facebook id from token</param>
        /// <returns>A user instance</returns>
        User GetUserByFacebook(string facebookId);
        /// <summary>
        /// Edit user's data
        /// </summary>
        /// <param name="user">Instance of user with details to be changed</param>
        /// <returns>A bool what specify if passed with success</returns>
        bool EditData(User user);
        /// <summary>
        /// Get user type:hairdress or client
        /// </summary>
        /// <param name="user">A user instance</param>
        /// <returns>User type</returns>
        string GetUserType(User user);
        /// <summary>
        /// Set user type to the mentioned
        /// </summary>
        /// <param name="user">User instance</param>
        /// <param name="hairdress">Type of user:hairdress or client</param>
        /// <returns>A bool what specify if passed with success</returns>
        bool SetUserType(User user,string hairdress);
        /// <summary>
        /// Get all hairdressers
        /// </summary>
        /// <returns>a list with haidressers without details</returns>
        List<User> GetAllHairdress();
        /// <summary>
        /// Get all hairdressers
        /// </summary>
        /// <param name="location">user location</param>
        /// <returns>return list of hairdress only from a location</returns>
        List<User> GetAllHaidressLocation(string location);


    }
}
