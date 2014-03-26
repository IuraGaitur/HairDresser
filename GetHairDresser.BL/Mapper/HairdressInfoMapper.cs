using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.Common.Entities;
using GetHairDresser.Common.DAL.Entities;
using AutoMapper;



namespace GetHairDresser.BL.Mapper
{
    /// <summary>
    /// Map for Hairdress info
    /// </summary>
    public class HairdressInfoMapper : IMapperHairdressInfo
    {

        public HairdressInfoMapper()
        {
            AutoMapper.Mapper.CreateMap<HairdresInfoDTO, HairdresInfo>();
            AutoMapper.Mapper.CreateMap<HairdresInfo, HairdresInfoDTO>();
        }

        public HairdresInfoDTO MapHairdressInfoDTO(Common.Entities.HairdresInfo info)
        {
           return AutoMapper.Mapper.Map<HairdresInfoDTO>(info);
        }

        public Common.Entities.HairdresInfo MapHairdressInfo(HairdresInfoDTO info)
        {
            return AutoMapper.Mapper.Map<HairdresInfo>(info);
        }
    }
}
