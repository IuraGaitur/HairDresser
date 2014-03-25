using GetHairDresser.BL;
using GetHairDresser.Common.BLLInterfaces;
using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HairdressInfoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HairdressInfoService.svc or HairdressInfoService.svc.cs at the Solution Explorer and start debugging.
    public class HairdressInfoService : IHairdressInfoService
    {
        public IHairdressInfo hairdressInfos{ get; set; }
        public HairdressInfoService()
        {
            hairdressInfos = new HairdressInfoBLL();
        }

        public HairdresInfo GetHairdressInform(int id)
        {
            return hairdressInfos.GetHairdressInform(id);
        }

        public bool SetHairdressInform(HairdresInfo info)
        {
            return hairdressInfos.SetHairdressInform(info);
        }
    }
}
