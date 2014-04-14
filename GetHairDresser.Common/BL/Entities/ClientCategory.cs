using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BL.Entities
{
    public class ClientCategory
    {
       public enum Category{hairdress,client};

       public Category CategoryUser { get; set; }

    }
}
