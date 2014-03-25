using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHairdressInfoService" in both code and config file together.
    [ServiceContract]
    public interface IHairdressInfoService
    {
        [OperationContract]
        HairdresInfo GetHairdressInform(int id);
        [OperationContract]
        bool SetHairdressInform(HairdresInfo info);
    }
}
