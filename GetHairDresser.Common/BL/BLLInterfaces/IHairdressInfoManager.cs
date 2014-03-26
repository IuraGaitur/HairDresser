using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    /// <summary>
    /// Hairdress info is responsible for hairdress information/review management.
    /// </summary>
    public interface IHairdressInfoManager
    {
        /// <summary>
        /// Get inform about hairdress
        /// </summary>
        /// <param name="id">ID of the hairdress</param>
        /// <returns>Hairdress class</returns>
        HairdresInfo GetHairdressInform(int id);
        /// <summary>
        /// Set details of one hairdress instance
        /// </summary>
        /// <param name="info"> Haidress instance what will be set</param>
        /// <returns>A bool if the operation failed or passed with success</returns>
        bool SetHairdressInform(HairdresInfo info);


    }
}
