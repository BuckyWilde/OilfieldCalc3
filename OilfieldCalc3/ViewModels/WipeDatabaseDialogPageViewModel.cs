using OilfieldCalc3.Services;
using OilfieldCalc3.Services.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Tubulars.DrillstringTubulars;
using Tubulars.WellboreTubulars;
using Xamarin.Essentials;

namespace OilfieldCalc3.ViewModels
{
    public class WipeDatabaseDialogPageViewModel : BindableBase, IDialogAware
    {
        private IDataService _dataService;
        private ISettings _settingsService;

        private bool _clearDrillstringDatabaseChecked;
        public bool ClearDrillstringDatabaseChecked
        {
            get => _clearDrillstringDatabaseChecked;
            set
            {
                SetProperty(ref _clearDrillstringDatabaseChecked, value);
                ClearCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _clearWellboreDatabaseChecked;
        public bool ClearWellboreDatabaseChecked
        {
            get => _clearWellboreDatabaseChecked;
            set
            {
                SetProperty(ref _clearWellboreDatabaseChecked, value);
                ClearCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _clearUserSettingsChecked;
        public bool ClearUserSettingsChecked
        {
            get => _clearUserSettingsChecked;
            set
            {
                SetProperty(ref _clearUserSettingsChecked, value);
                ClearCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand CloseCommand { get; }
        public DelegateCommand ClearCommand { get; }

        public WipeDatabaseDialogPageViewModel()
        {
            CloseCommand = new DelegateCommand(() => RequestClose(null));
            ClearCommand = new DelegateCommand(() =>
            {
                if (_clearDrillstringDatabaseChecked)
                {
                    _dataService.ClearTable<DrillPipe>();
                }
                if (_clearWellboreDatabaseChecked)
                {
                    _dataService.ClearTable<Casing>();
                }
                if (_clearUserSettingsChecked)
                {
                    _settingsService.Clear();
                }
                RequestClose(null);
            }, () => _clearDrillstringDatabaseChecked || _clearWellboreDatabaseChecked || _clearUserSettingsChecked);
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters param)
        {
            if (param?.ContainsKey("dataService") == true)
            {
                _dataService = param.GetValue<IDataService>("dataService");
            }

            if(param?.ContainsKey("settingsService") == true)
            {
                _settingsService = param.GetValue<ISettings>("settingsService");
            }
        }
    }
}
