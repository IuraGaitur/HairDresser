using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser;
using GetHairDresser.Common;
using GetHairDresser.Common.Entities;
using GetHairDresser.Common.DAL.Entities;

namespace GetHairDresser.DAL.EntityLayerPath
{
    class EntityLayerDB:DbContext
    {
        //public EntityLayerDB():base() 
        //{
        //    var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        //}
        //public void FixEfProviderServicesProblem()
        //{
        //    //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
        //    //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
        //    //Make sure the provider assembly is available to the running application. 
        //    //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

        //    var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}

        public EntityLayerDB()
            : base("name=MyDB")
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            //Database.SetInitializer<EntityLayerDB>(null);
        }

        public DbSet<UserDTO> users { get; set; }
        public DbSet<JobAppointmentDTO> jobAppoints { get; set; }
        public DbSet<MessageDTO> messages { get; set; }
        public DbSet<HairdresInfoDTO> infoHairdress { get; set; }

    }
}
