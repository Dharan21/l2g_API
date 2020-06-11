using l2g.DL;
using l2g.DL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.Extension;
using Unity.WebApi;

namespace l2g.BL
{
    public class UnityConfigBL: UnityContainerExtension 
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAuthDL, AuthDL>();
            Container.RegisterType<ICarDL,CarDL>();
            Container.RegisterType<IUserDL, UserDL>();
            Container.RegisterType<IQuoteDL, QuoteDL>();
            Container.RegisterType<IPaybackTimeDL, PaybackTimeDL>();
            Container.RegisterType<IMileageDL, MileageDL>();
        }
    }
}