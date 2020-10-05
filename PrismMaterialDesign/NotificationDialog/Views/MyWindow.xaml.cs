using Prism.Services.Dialogs;
using PrismMaterialDesign.Resources.Controls;

namespace NotificationDialog.Views
{
    /// <summary>
    /// Interaction logic for MyWindow.xaml
    /// </summary>
    public partial class MyWindow : MessageBoxWindow, IDialogWindow
    {
        public MyWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
