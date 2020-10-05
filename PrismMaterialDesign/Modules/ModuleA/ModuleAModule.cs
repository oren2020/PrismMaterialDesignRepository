using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismMaterialDesign.Core;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        //readonly IRegionManager _regionManager;

        //public ModuleAModule(IRegionManager regionManager)
        //{
        //    _regionManager = regionManager;
        //}

        //public void OnInitialized(IContainerProvider containerProvider)
        //{
        //    IRegion region = _regionManager.Regions[RegionNames.RegionA];

        //    var view = containerProvider.Resolve<ViewA>();
        //    region.Add(view);
        //    region.Activate(view);
        //}

        //public void RegisterTypes(IContainerRegistry containerRegistry)
        //{
        //    containerRegistry.RegisterForNavigation<ViewA>();
        //    containerRegistry.Register<IDialogServiceExt, DialogServiceExt>();
        //}

        private readonly IRegionViewRegistry _regionViewRegistry = null;

        public ModuleAModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionViewRegistry.RegisterViewWithRegion(RegionNames.RegionA, typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogServiceExt, DialogServiceExt>();
        }
    }
}