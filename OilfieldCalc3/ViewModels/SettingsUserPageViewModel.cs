using OilfieldCalc3.Resx;
using OilfieldCalc3.Services.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace OilfieldCalc3.ViewModels
{
    public class SettingsUserPageViewModel : ViewModelBase
    {
        private readonly ISettings _userSettings;

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set => SetProperty(ref _isDarkMode, value);
        }        

        public DelegateCommand ThemeSelectionChangedCommand { get; set; }

        public SettingsUserPageViewModel(INavigationService navigationService, ISettings userSettings) : base(navigationService)
        {
            _userSettings = userSettings;

            Title = AppResources.SettingsTabUserTitle;
            
            if (_userSettings.AppTheme == "Dark")
                IsDarkMode = true;
            else
                IsDarkMode = false;

            ThemeSelectionChangedCommand = new DelegateCommand(ThemeSelectionChanged);
        }

        private void ThemeSelectionChanged()
        {
            switch(_isDarkMode)
            {
                case true:
                    _userSettings.AppTheme = "Dark";
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
                case false:
                    _userSettings.AppTheme = "Light";
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }
    }
}
