using NotificationDialog.ViewModels;
using NotificationDialog.Views;
using Prism.Ioc;
using Prism.Modularity;
using PrismMaterialDesign.Core;

namespace NotificationDialog
{
    public class NotificationDialogModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterDialogWindow<MyWindow>();
            containerRegistry.RegisterDialogWindow<MyWindow>(nameof(MyWindow));
            containerRegistry.RegisterDialogWindow<MyWindow_2>(nameof(MyWindow_2));
            containerRegistry.RegisterDialog<NotificationDialogView, NotificationDialogViewModel>("NotificationDialogView");
        }
    }
}