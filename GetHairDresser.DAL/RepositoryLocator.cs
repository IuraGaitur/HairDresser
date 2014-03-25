using GetHairDresser.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.DAL.EntityLayerPath;

namespace GetHairDresser.DAL
{
    public class RepositoryLocator
    {
        private static IRepository repository;
        private RepositoryLocator()
        {}

        public  static IRepository GetRepository()
        {
            if(repository == null)
                repository = new EntityLayer();
            return repository;
        }


    }
}
