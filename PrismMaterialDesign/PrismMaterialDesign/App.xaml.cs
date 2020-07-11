using ModuleA;
using ModuleB;
using Prism.Ioc;
using Prism.Modularity;
using PrismMaterialDesign.Views;
using System.Windows;

namespace PrismMaterialDesign
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule(typeof(ModuleAModule));
            moduleCatalog.AddModule(typeof(ModuleBModule));
        }
    }
}
