using OilfieldCalc3.Models;
using OilfieldCalc3.Resx;
using OilfieldCalc3.Services.Settings;
using OilfieldCalc3.Views;
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
    public class NavigationMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUnitSettings _settings;

        public DelegateCommand<string> NavigateCommand { get; }

        public NavigationMasterDetailPageViewModel(INavigationService navigationService, IUnitSettings settings) : base(navigationService)
        {
            _navigationService = navigationService;
            _settings = settings;

            NavigateCommand = new DelegateCommand<string>(async (string sender) =>
            {
                var result = await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + sender).ConfigureAwait(false);
                if (!result.Success)
                    System.Diagnostics.Debugger.Break();
            });
        }
    }
}
