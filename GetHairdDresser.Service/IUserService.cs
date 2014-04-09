using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    /// <summary>
    /// Service is responsible  for registering/login/add/edit/get user data 
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// Check if a user exist in database
        /// </summary>
        /// <param name="user">User details</param>
        /// <returns>A bool if such a user exist or not</returns>
        [OperationContract]
        bool Login(User user);
        /// <summary>
        /// Register a user in database
        /// </summary>
        /// <param name="u">User instance</param>
        /// <returns>A bool if user was insert in db</returns>
        [OperationContract]
        bool Register(User u);
        /// <summary>
        /// Get user data from db by a Guid id 
        /// </summary>
        /// <param name="id">User identificato</param>
        /// <returns>A user instance from db</returns>
        [OperationContract]
        User GetUserData(Guid id);
        /// <summary>
        /// Get user data from db by a id from facebook
        /// </summary>
        /// <param name="facebookId">Facebook id from token</param>
        /// <returns>A user instance</returns>
        [OperationContract]
        User GetUserDataByFacebook(string facebookId);
        /// <summary>
        /// Edit user's data
        /// </summary>
        /// <param name="user">Instance of user with details to be changed</param>
        /// <returns>A bool what specify if passed with success</returns>
        [OperationContract]
        bool EditData(User user);
        /// <summary>
        /// Get user type:hairdress or client
        /// </summary>
        /// <param name="user">A user instance</param>
        /// <returns>User type</returns>
        [OperationContract]
        string GetUserType(User user);
        /// <summary>
        /// Set user type to the mentioned
        /// </summary>
        /// <param name="user">User instance</param>
        /// <param name="hairdress">Type of user:hairdress or client</param>
        /// <returns>A bool what specify if passed with success</returns>
        [OperationContract]
        bool SetUserType(User user, string userType);
        /// <summary>
        /// Get all hairdressers
        /// </summary>
        /// <returns>a list with haidressers without details</returns>
        [OperationContract]
        List<User> GetAllHairdress();
        /// <summary>
        /// Get all hairdressers
        /// </summary>
        /// <param name="location">user location</param>
        /// <returns>return list of hairdress only from a location</returns>
        [OperationContract]
        List<User> GetAllHaidressLocation(string location);

    }
}
