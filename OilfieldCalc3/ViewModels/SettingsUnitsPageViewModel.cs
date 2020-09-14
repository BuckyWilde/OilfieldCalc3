using Newtonsoft.Json.Schema;
using OilfieldCalc3.Models.UnitsOfMeasure;
using OilfieldCalc3.Resx;
using OilfieldCalc3.Services.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilfieldCalc3.ViewModels
{
    public class SettingsUnitsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISettings _settings;

        #region Properties
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
        #endregion

        public SettingsUnitsPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService)
        {
            _navigationService = navigationService;
            _settings = settings;

            Title = AppResources.SettingsTabUnitsTitle;

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
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            
        }
    }
}
