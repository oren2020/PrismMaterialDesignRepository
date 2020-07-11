using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismMaterialDesign.Core;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        readonly IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = _regionManager.Regions[RegionNames.RegionB];

            var view = containerProvider.Resolve<ViewB>();
            region.Add(view);
            region.Activate(view);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}