using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GetHairdDresser.Service;

namespace GetHairdresser.WCFHost
{
    class Program
    {

        static void Main(string[] args)
        {



            using (ServiceHost host = new ServiceHost(typeof(GHairService)))
            {

                Console.WriteLine("Starting host for the GHairdresser");
                host.Open();
                Console.WriteLine("The service is hosted.Please Enter a key to finish hosting!");
                Console.ReadKey();
            }

        }
    }
}
