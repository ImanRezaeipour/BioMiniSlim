using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using BioMiniSlim.Data.UnitOfWork;
using BioMiniSlim.Service.Services.Device;
using BioMiniSlim.Service.Services.Persons;
using Ninject;
using Ninject.Modules;

namespace BioMiniSlim.Wpf.Framework.DependencyResolver
{
    public class NinjectAppModule : NinjectModule
    {
        

        public override void Load()
        {


            Bind<IPersonService>().To<PersonService>();
            Bind<IDeviceManager>().To<DeviceManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
