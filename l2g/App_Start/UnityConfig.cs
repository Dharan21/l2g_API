using l2g.BL;
using l2g.BL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace l2g
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<UnityConfigBL>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            //container.RegisterType<IAuthBL, AuthBL>();
            container.RegisterType<ICarBL, CarBL>();
            container.RegisterType<IQuoteBL, QuoteBL>();
            container.RegisterType<IUserBL, UserBL>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}