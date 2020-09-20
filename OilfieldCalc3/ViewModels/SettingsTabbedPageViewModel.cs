using OilfieldCalc3.Models.UnitsOfMeasure;
using OilfieldCalc3.Resx;
using OilfieldCalc3.Services;
using OilfieldCalc3.Services.Settings;
using OilfieldCalc3.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Xamarin.Forms;

namespace OilfieldCalc3.ViewModels
{
    public class SettingsTabbedPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly ISettings _settings;

        public string SettingsAboutPageTitle { get; set; }
        public string SettingsAdvancedPageTitle { get; set; }
        public string SettingsUnitsPageTitle { get; set; }
        public string SettingsUserPageTitle { get; set; }

        private List<UnitBase> _longLengthUnits;
        public List<UnitBase> LongLengthUnits
        {
            get => _longLengthUnits;
            set => SetProperty(ref _longLengthUnits, value);
        }

        private List<UnitBase> _shortLengthUnits;
        public List<UnitBase> ShortLengthUnits
        {
            get => _shortLengthUnits;
            set => SetProperty(ref _shortLengthUnits, value);
        }

        private List<UnitBase> _volumeUnits;
        public List<UnitBase> VolumeUnits
        {
            get => _volumeUnits;
            set => SetProperty(ref _volumeUnits, value);
        }

        private List<UnitBase> _capacityUnits;
        public List<UnitBase> CapacityUnits
        {
            get => _capacityUnits;
            set => SetProperty(ref _capacityUnits, value);
        }

        private List<UnitBase> _massUnits;
        public List<UnitBase> MassUnits
        {
            get => _massUnits;
            set => SetProperty(ref _massUnits, value);
        }

        private UnitBase _selectedLongLengthUnit;
        public UnitBase SelectedLongLengthUnit
        {
            get => _selectedLongLengthUnit;
            set
            {
                SetProperty(ref _selectedLongLengthUnit, value);
                if (value != null)
                    _settings.LongLengthUnit = value;
            }
        }

        private UnitBase _selectedShortLengthUnit;
        public UnitBase SelectedShortLengthUnit
        {
            get => _selectedShortLengthUnit;
            set
            {
                SetProperty(ref _selectedShortLengthUnit, value);
                if (value != null)
                    _settings.ShortLengthUnit = value;
            }
        }

        private UnitBase _selectedVolumeUnit;
        public UnitBase SelectedVolumeUnit
        {
            get => _selectedVolumeUnit;
            set
            {
                SetProperty(ref _selectedVolumeUnit, value);
                if (value != null)
                    _settings.VolumeUnit = value;
            }
        }

        private UnitBase _selectedCapacityUnit;
        public UnitBase SelectedCapacityUnit
        {
            get => _selectedCapacityUnit;
            set
            {
                SetProperty(ref _selectedCapacityUnit, value);
                if (value != null)
                    _settings.CapacityUnit = value;
            }
        }

        private UnitBase _selectedMassUnit;
        public UnitBase SelectedMassUnit
        {
            get => _selectedMassUnit;
            set
            {
                SetProperty(ref _selectedMassUnit, value);
                if (value != null)
                    _settings.MassUnit = value;
            }
        }

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set => SetProperty(ref _isDarkMode, value);
        }

        public DelegateCommand WipeDatabaseCommand { get; }
        public DelegateCommand ThemeSelectionChangedCommand { get; set; }

        public SettingsTabbedPageViewModel(INavigationService navigationService, IDataService dataService, IDialogService dialogService, ISettings settings)
            : base(navigationService)
        {
            SettingsAboutPageTitle = AppResources.SettingsTabAboutTitle;
            SettingsAdvancedPageTitle = AppResources.SettingsTabAdvancedTitle;
            SettingsUnitsPageTitle = AppResources.SettingsTabUnitsTitle;
            SettingsUserPageTitle = AppResources.SettingsTabUserTitle;

            _dataService = dataService;
            _settings = settings;

            LongLengthUnits = new List<UnitBase>(UnitBase.GetUnits<LongLength>());
            ShortLengthUnits = new List<UnitBase>(UnitBase.GetUnits<ShortLength>());
            VolumeUnits = new List<UnitBase>(UnitBase.GetUnits<Volume>());
            CapacityUnits = new List<UnitBase>(UnitBase.GetUnits<Capacity>());
            MassUnits = new List<UnitBase>(UnitBase.GetUnits<Mass>());

            _selectedLongLengthUnit = _settings.LongLengthUnit;
            _selectedShortLengthUnit = _settings.ShortLengthUnit;
            _selectedVolumeUnit = _settings.VolumeUnit;
            _selectedCapacityUnit = _settings.CapacityUnit;
            _selectedMassUnit = _settings.MassUnit;

            if (_settings.AppTheme == "Dark")
                IsDarkMode = true;
            else
                IsDarkMode = false;

            ThemeSelectionChangedCommand = new DelegateCommand(() =>
            {
                switch (_isDarkMode)
                {
                    case true:
                        _settings.AppTheme = "Dark";
                        Application.Current.UserAppTheme = OSAppTheme.Dark;
                        break;
                    case false:
                        _settings.AppTheme = "Light";
                        Application.Current.UserAppTheme = OSAppTheme.Light;
                        break;
                }
            });

            WipeDatabaseCommand = new DelegateCommand(async () =>
            {
                var param = new DialogParameters();
                param.Add("dataService", _dataService);
                param.Add("settingsService", _settings);
                dialogService.ShowDialog(nameof(WipeDatabaseDialogPage), param, CloseDialogCallback);
            });
        }

        void CloseDialogCallback(IDialogResult dialogResult)
        {

        }
    }
}
