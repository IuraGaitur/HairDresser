using GetHairDresser.Common.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.DAL.EntityLayerPath
{
    class EntityLayerInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<EntityLayerDB>
    {
        protected override void Seed(EntityLayerDB context)
        {
            //var users = new List<UserDTO>
            //{
            //    new UserDTO
            //    {
            //        age = 18,
            //        email = "iurasik93g@yandex.ru",
            //        firstName = "Vasile",
            //        gender = "male",
            //        UserGuid = Guid.NewGuid(),
            //        UserFacebook = "4652315648976432",
            //        typeClient = "client",
            //        lastName = "Bogheanu",
            //        hairdressInfo = new HairdresInfoDTO
            //        {
                        

            //        }

            //    }



            //};
            //users.ForEach(s => context.users.Add(s));
            //context.SaveChanges();

           
            
        }

    }
}
