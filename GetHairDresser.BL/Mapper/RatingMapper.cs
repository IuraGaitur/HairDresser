using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.Common;
using GetHairDresser.Common.DAL.Entities;
using AutoMapper;
using GetHairDresser.Common.Entities;


namespace GetHairDresser.BL.Mapper
{
    /// <summary>
    /// Map for rating
    /// </summary>
    public class RatingMapper : IMapperRating
    {
        public RatingMapper()
        {
            AutoMapper.Mapper.CreateMap<RatingDTO,Rating>();
            AutoMapper.Mapper.CreateMap<Rating, RatingDTO>();
        }
        public RatingDTO MapRatingDTO(Common.Entities.Rating rating)
        {
            return AutoMapper.Mapper.Map<RatingDTO>(rating);
        }

        public Common.Entities.Rating MapRating(RatingDTO rating)
        {
            return AutoMapper.Mapper.Map<Rating>(rating);
        }
    }
}
