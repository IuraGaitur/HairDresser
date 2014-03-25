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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MessagesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MessagesService.svc or MessagesService.svc.cs at the Solution Explorer and start debugging.
    public class MessagesService : IMessagesService
    {
        private iMessage messages { get; set; }

        public MessagesService()
        {
            messages = new MessageBLL();
        }

        public bool AddMessage(Message message)
        {
            return messages.AddMessage(message);
        }

        public bool EditMessage(Message message)
        {
            return messages.EditMessage(message);
        }

        public bool DeleteMessage(int id)
        {
            return messages.DeleteMessage(id);
        }

        public List<Message> GetListMessagesForUser(int id)
        {
            return messages.GetListMessagesForUser(id);
        }
    }
}
