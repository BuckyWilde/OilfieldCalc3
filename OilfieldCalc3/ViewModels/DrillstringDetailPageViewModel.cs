using OilfieldCalc3.Resx;
using OilfieldCalc3.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Tubulars;

namespace OilfieldCalc3.ViewModels
{
    public class DrillstringDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private double _length;
        public double Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }

        private double _outsideDiameter;
        public double OutsideDiameter
        {
            get => _outsideDiameter;
            set => SetProperty(ref _outsideDiameter, value);
        }

        private double _insideDiameter;
        public double InsideDiameter
        {
            get => _insideDiameter;
            set => SetProperty(ref _insideDiameter, value);
        }

        private double _adjustedWeight;
        public double AdjustedWeight
        {
            get => _adjustedWeight;
            set => SetProperty(ref _adjustedWeight, value);
        }

        private double _totalWeight;
        public double TotalWeight
        {
            get => _totalWeight;
            set => SetProperty(ref _totalWeight, value);
        }

        private double _dryDisplacementPerUnit;
        public double DryDisplacementPerUnit
        {
            get => _dryDisplacementPerUnit;
            set => SetProperty(ref _dryDisplacementPerUnit, value);
        }

        private double _totalDryDisplacement;
        public double TotalDryDisplacement
        {
            get => _totalDryDisplacement;
            set => SetProperty(ref _totalDryDisplacement, value);
        }

        private double _wetDisplacementPerUnit;
        public double WetDisplacementPerUnit
        {
            get
            {
                double wetDisplacement = TubularMath.GetWetDisplacement(_outsideDiameter);
                //TotalWetDisplacement.RaisePropertyChanged;
                return wetDisplacement;
            }
        }

        private double _totalWetDisplacement;
        public double TotalWetDisplacement => _wetDisplacementPerUnit * _length;

        private double _internalCapacityPerUnit;
        public double InternalCapacityPerUnit
        {
            get => _internalCapacityPerUnit;
            set => SetProperty(ref _internalCapacityPerUnit, value);
        }

        private double _totalInternalCapacity;
        public double TotalInternalCapacity
        {
            get => _totalInternalCapacity;
            set => SetProperty(ref _totalInternalCapacity, value);
        }

        public DrillstringDetailPageViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService)
        {
            _navigationService = navigationService;
            _dataService = dataService;

            Title = AppResources.DrillstringDetailPageTitle;
        }
    }
}
