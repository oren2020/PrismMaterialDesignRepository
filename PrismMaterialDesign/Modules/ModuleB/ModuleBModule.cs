using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismMaterialDesign.Core;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        public ModuleBModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionB, typeof(ViewB));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}