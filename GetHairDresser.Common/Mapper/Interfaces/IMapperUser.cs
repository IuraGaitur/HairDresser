using GetHairDresser.Common.DAL.Entities;
using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.Mapper.Interfaces
{
    /// <summary>
    /// Map from entities to DTO and from DTO to entities
    /// </summary>
    public interface IMapperUser
    {
        UserDTO MapUserDTO(User user);
        
        User MapUser(UserDTO user);
       
    }
}
