using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common.BLLInterfaces;
using GetHairDresser.Common.Entities;
using GetHairDresser.Common.Interfaces;
using GetHairDresser.DAL;
using AutoMapper;
using GetHairDresser.Common.DAL.Entities;

namespace GetHairDresser.BL
{
    public class MessageBLL:iMessage
    {
        IRepository repository = RepositoryLocator.GetRepository();
        public bool AddMessage(Message message)
        {
            if (message != null)
            {
                MessageDTO mess = Mapper.Map<MessageDTO>(message);
                repository.AddMessage(mess);
                return true;
            }

            return false;
        }

        public bool EditMessage(Message message)
        {
            if (message != null)
            {
                MessageDTO mess = Mapper.Map<MessageDTO>(message);
                repository.EditMessage(mess);
                return true;
            }

            return false;
        }

        public bool DeleteMessage(int id)
        {
            if (id != 0)
            {
                repository.DeleteMessage(id);
                return true;
            }

            return false;
        }

        public List<Message> GetListMessagesForUser(int id)
        {
            List<Message> mess = null;
            List<MessageDTO> temp_mess = null;
            if (id != 0)
            {
                temp_mess = repository.GetMessagesReceived(id);
                foreach (var temp in temp_mess)
                {
                    mess.Add(Mapper.Map<Message>(temp));
                }
            }

            return mess;
        }
        public List<Message> GetListMessagesSentUser(int id)
        {
            List<Message> mess = null;
            List<MessageDTO> temp_mess = null;
            if (id != 0)
            {
                temp_mess = repository.GetMessagesSend(id);
                foreach (var temp in temp_mess)
                {
                    mess.Add(Mapper.Map<Message>(temp));
                }
            }

            return mess;
        }

    }
}
