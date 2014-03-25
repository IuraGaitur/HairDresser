using GetHairDresser.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    public interface iMessage
    {
        bool AddMessage(Message message);
        
        bool EditMessage(Message message);
        
        bool DeleteMessage(int id);

        List<Message> GetListMessagesForUser(int id);


    }
}
