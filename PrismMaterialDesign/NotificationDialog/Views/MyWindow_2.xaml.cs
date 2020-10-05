using Prism.Services.Dialogs;
using PrismMaterialDesign.Resources.Controls;

namespace NotificationDialog.Views
{
    /// <summary>
    /// Interaction logic for MyWindow_2.xaml
    /// </summary>
    public partial class MyWindow_2 : MessageBoxWindow, IDialogWindow
    {
        public MyWindow_2()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
