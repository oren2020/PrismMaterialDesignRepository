using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _skin;
        private readonly Dictionary<string, string> _skins;

        public DelegateCommand<string> ChangeSkinCommand { get; private set; }

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

        public ViewAViewModel()
        {
            Message = "View A";
            _skin = "Light";
            MySelectedDate = DateTime.Now;
            ChangeSkinCommand = new DelegateCommand<string>(ChangeSkin);

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
    }
}
