using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.BL;

namespace GetHairDresser.DAL.EntityLayerPath
{
    class EntityLayerDB:DbContext
    {

        public DbSet<User> users { get; set; }
        public DbSet<JobAppointment> jobAppoints { get; set; }
        public DbSet<UserType> userType { get; set; }

    }
}
