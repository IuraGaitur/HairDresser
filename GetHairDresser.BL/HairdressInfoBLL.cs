using GetHairDresser.Common.BLLInterfaces;
using GetHairDresser.Common.Entities;
using GetHairDresser.Common.Interfaces;
using GetHairDresser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetHairDresser.Common.DAL.Entities;

namespace GetHairDresser.BL
{
    public class HairdressInfoBLL:IHairdressInfo
    {
        IRepository repository = RepositoryLocator.GetRepository();
        public HairdresInfo GetHairdressInform(int id)
        {
            HairdresInfo info = null;
            if (id != 0)
            {
                HairdresInfoDTO infoDTO = repository.GetHairdressInfo(id);
                info = Mapper.Map<HairdresInfo>(infoDTO);
            }
            return info;
        }

        public bool SetHairdressInform(HairdresInfo info)
        {
            if (info != null)
            {
                SetHairdressInform(info);
                return true;
            }
            return false;
        }
    }
}
