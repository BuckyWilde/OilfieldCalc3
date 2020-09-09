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

        private List<string> _themeOptionsList;
        public List<string> ThemeOptionsList 
        { 
            get => _themeOptionsList;
            set => SetProperty(ref _themeOptionsList, value);
        }

        private string _selectedMenuItem;
        public string SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        public DelegateCommand ThemeSelectionChangedCommand { get; set; }

        public SettingsUserPageViewModel(INavigationService navigationService, ISettings userSettings) : base(navigationService)
        {
            _userSettings = userSettings;

            Title = AppResources.SettingsTabUserTitle;

            ThemeOptionsList = new List<string>();

            ThemeOptionsList.Add("Light");
            ThemeOptionsList.Add("Dark");

            _selectedMenuItem = _userSettings.AppTheme;

            ThemeSelectionChangedCommand = new DelegateCommand(ThemeSelectionChanged);
        }

        private void ThemeSelectionChanged()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            switch(_selectedMenuItem)
            {
                case "Dark":
                    _userSettings.AppTheme = "Dark";
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
                case "Light":
                    _userSettings.AppTheme = "Light";
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                default:
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
