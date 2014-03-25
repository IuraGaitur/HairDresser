using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    public interface IHairdressInfo
    {
        HairdresInfo GetHairdressInform(int id);
        
        bool SetHairdressInform(HairdresInfo info);


    }
}
