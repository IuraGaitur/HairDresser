using GetHairDresser.Common.DAL.Entities;
using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.Mapper.Interfaces
{
    public interface IMapperHairdressInfo
    {
        HairdresInfoDTO MapHairdressInfoDTO(HairdresInfo info);

        HairdresInfo MapHairdressInfo(HairdresInfoDTO info);
        
    }
}
