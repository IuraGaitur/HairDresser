using GetHairDresser.BL;
using GetHairDresser.Common.BLLInterfaces;
using GetHairDresser.Common.Interfaces;
using GetHairDresser.DAL.EntityLayerPath;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace GetHairdDresser.Service
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
			 //register all your components with the container here
            container
               .RegisterType<IUserService, UserService>()
               .RegisterType<IUserManage, UserBLL>()
               .RegisterType<IRepository, EntityLayer>()
               .RegisterType<IMessagesService, MessagesService>()
               .RegisterType<iMessageManager, MessageBLL>()
               .RegisterType<IJobAppointmentsService,JobAppointmentsService>()
               .RegisterType<IJobAppointmentsManager, JobAppointmentsBLL>()
               .RegisterType<IHairdressInfoService, HairdressInfoService>()
               .RegisterType<IHairdressInfoManager, HairdressInfoBLL>();
                //.RegisterType<DataContext>(new HierarchicalLifetimeManager());
        }
    }    
}