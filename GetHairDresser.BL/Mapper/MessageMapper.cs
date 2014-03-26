using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.Common.Entities;
using GetHairDresser.Common.DAL.Entities;
using GetHairDresser.Common;
using AutoMapper;


namespace GetHairDresser.BL
{
    /// <summary>
    /// Map for Messages
    /// </summary>
    public class MessageMapper:IMapperMessages
    {
        public MessageMapper()
        {
            AutoMapper.Mapper.CreateMap<MessageDTO, Message>();
            AutoMapper.Mapper.CreateMap<Message, MessageDTO>();
        }

        public MessageDTO MapMessageDTO(Message message)
        {
            return AutoMapper.Mapper.Map<MessageDTO>(message);
        }

        public Message MapMessage(MessageDTO message)
        {
            return AutoMapper.Mapper.Map<Message>(message);
        }
    }
}
