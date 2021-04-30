using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismMaterialDesign.Core;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _skin;
        private readonly Dictionary<string, string> _skins;
        private readonly IDialogService _dialogService;
        //private readonly IDialogServiceExt _dialogServiceExt;

        public DelegateCommand<string> ChangeSkinCommand { get; private set; }
        public DelegateCommand ShowDialogCommand { get; private set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DateTime _mySelectedDate;
        public DateTime MySelectedDate
        {
            get { return _mySelectedDate; }
            set { SetProperty(ref _mySelectedDate, value); }
        }

        public ViewAViewModel(IDialogService dialogService/*, IDialogServiceExt dialogServiceExt*/)
        {
            _dialogService = dialogService;
            //_dialogServiceExt = dialogServiceExt;
            Message = "View A";
            _skin = "Dark";
            MySelectedDate = DateTime.Now;
            ChangeSkinCommand = new DelegateCommand<string>(ChangeSkin);
            ShowDialogCommand = new DelegateCommand(ShowDialog);

            _skins = new Dictionary<string, string>
            {
                {"light", "/PrismMaterialDesign.Resources;component/Skins/Light/Skin.xaml"},
                {"dark", "/PrismMaterialDesign.Resources;component/Skins/Dark/Skin.xaml"}
            };

            ChangeSkin(_skin);
        }

        private void ChangeSkin(string skinName)
        {
            if (!_skins.ContainsKey(skinName.ToLower()))
                return;

            if (skinName.ToLower() == _skin.ToLower())
                return;
            _skin = skinName;

            if (!UriParser.IsKnownScheme("pack"))
                UriParser.Register(new GenericUriParser(GenericUriParserOptions.GenericAuthority), "pack", -1);

            var skinUri = new Uri(_skins[skinName.ToLower()], UriKind.Relative);
            var skin = new ResourceDictionary { Source = skinUri };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(skin);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/PrismMaterialDesign.Resources;component/Resources.xaml", UriKind.RelativeOrAbsolute)
            });
        }

        //private void ShowDialog()
        //{
        //    var message = "This is a message that should be shown in the dialog.";
        //    _dialogService.ShowNotification(message, r =>
        //    {
        //        if (r.Result == ButtonResult.None)
        //            Message = "Result is None";
        //        else if (r.Result == ButtonResult.OK)
        //            Message = "Result is OK";
        //        else if (r.Result == ButtonResult.Cancel)
        //            Message = "Result is Cancel";
        //        else
        //            Message = "I Don't know what you did!?";
        //    });
        //}

        private bool is2 = false;
        private void ShowDialog()
        {
            if (!is2)
            {
                var message = "This is a NOTIFICATION message that should be shown in the dialog.";
                _dialogService.ShowDialog("NotificationDialogView", new DialogParameters($"message={message}"), r =>
                 {
                     if (r.Result == ButtonResult.None)
                         Message = "Result is None";
                     else if (r.Result == ButtonResult.OK)
                         Message = "Result is OK";
                     else if (r.Result == ButtonResult.Cancel)
                         Message = "Result is Cancel";
                     else
                         Message = "I Don't know what you did!?";
                 }, "MyWindow");
            }
            else
            {
                var message = "This is an ERROR message that should be shown in the dialog.";
                _dialogService.ShowDialog("NotificationDialogView", new DialogParameters($"message={message}"), r =>
                 {
                     if (r.Result == ButtonResult.None)
                         Message = "Result is None";
                     else if (r.Result == ButtonResult.OK)
                         Message = "Result is OK";
                     else if (r.Result == ButtonResult.Cancel)
                         Message = "Result is Cancel";
                     else
                         Message = "I Don't know what you did!?";
                 }, "MyWindow_2");
            }
            is2 = !is2;
        }
    }
}
