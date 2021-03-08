using BioMiniSlim.Wpf.Framework.DependencyResolver;
using Ninject;
using System.Windows;
using BioMiniSlim.Wpf.Views.Shared;

namespace BioMiniSlim.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Protected Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NinjectDependencyResolver.Container.Get<MainWindow>().Show();
        }

        #endregion Protected Methods
    }
}