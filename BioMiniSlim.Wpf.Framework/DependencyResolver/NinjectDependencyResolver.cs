using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace BioMiniSlim.Wpf.Framework.DependencyResolver
{
    public class NinjectDependencyResolver
    {
        public static IKernel Container => new StandardKernel(new NinjectAppModule());
    }
}
