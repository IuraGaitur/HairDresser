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
    /// Hairdress info service is responsible for hairdress information/review management.
    /// </summary>
    [ServiceContract]
    public interface IHairdressInfoService
    {
        /// <summary>
        /// Get inform about hairdress
        /// </summary>
        /// <param name="id">ID of the hairdress</param>
        /// <returns>Hairdress class</returns>
        [OperationContract]
        HairdresInfo GetHairdressInform(int id);
        /// <summary>
        /// Set details of one hairdress instance
        /// </summary>
        /// <param name="info"> Haidress instance what will be set</param>
        /// <returns>A bool if the operation failed or passed with success</returns>
        [OperationContract]
        bool SetHairdressInform(HairdresInfo info);
    }
}
