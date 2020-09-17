using OilfieldCalc3.Resx;
using OilfieldCalc3.Services;
using OilfieldCalc3.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace OilfieldCalc3.ViewModels
{
    public class SettingsAdvancedPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public DelegateCommand WipeDatabaseCommand { get; }

        public SettingsAdvancedPageViewModel(INavigationService navigationService, IDataService dataService, IDialogService dialogService) 
            : base(navigationService)
        {
            Title = AppResources.SettingsTabAdvancedTitle;

            _dataService = dataService;

            WipeDatabaseCommand = new DelegateCommand(async () =>
              {
                  System.Diagnostics.Debug.WriteLine("trying dialog but to no avail???");
                  dialogService.ShowDialog(nameof(WipeDatabaseDialogPage), CloseDialogCallback);
              });
        }

        void CloseDialogCallback(IDialogResult dialogResult)
        {

        }
    }
}
