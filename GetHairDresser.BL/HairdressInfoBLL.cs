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
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.BL.Mapper;

namespace GetHairDresser.BL
{
    public class HairdressInfoBLL:IHairdressInfoManager
    {

        IMapperHairdressInfo mapper;
        
        public HairdressInfoBLL()
        {
            mapper = new HairdressInfoMapper();
            
        }

        IRepository repository = RepositoryLocator.GetRepository();
        public HairdresInfo GetHairdressInform(int id)
        {
            HairdresInfoDTO infoDTO = null;
            if (id != 0)
            {
                infoDTO = repository.GetHairdressInfo(id);
            }
            return mapper.MapHairdressInfo(infoDTO);
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
