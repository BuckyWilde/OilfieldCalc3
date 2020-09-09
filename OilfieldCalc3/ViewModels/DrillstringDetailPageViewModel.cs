using OilfieldCalc3.Resx;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilfieldCalc3.ViewModels
{
    public class DrillstringDetailPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public DrillstringDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            Title = AppResources.DrillstringDetailPageTitle;
        }
    }
}
