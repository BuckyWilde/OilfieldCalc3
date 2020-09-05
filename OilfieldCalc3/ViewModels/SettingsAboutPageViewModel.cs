using OilfieldCalc3.Resx;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilfieldCalc3.ViewModels
{
    public class SettingsAboutPageViewModel : ViewModelBase
    {
        public SettingsAboutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = AppResources.SettingsTabAboutTitle;
        }
    }
}
