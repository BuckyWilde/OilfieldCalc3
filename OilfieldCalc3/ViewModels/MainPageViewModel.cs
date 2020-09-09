using OilfieldCalc3.Models.UnitsOfMeasure;
using OilfieldCalc3.Resx;
using OilfieldCalc3.Services;
using OilfieldCalc3.Services.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Tubulars;
using Xamarin.Forms;

namespace OilfieldCalc3.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IDataService _dataService;
        ISettings _unitSettings;

        public MainPageViewModel(INavigationService navigationService, IDataService dataService, ISettings unitSettings)
            : base(navigationService)
        {
            _dataService = dataService;
            _unitSettings = unitSettings;

            Title = AppResources.MainPageTitle;

            //Load user selected theme from userSettings
            //_unitSettings.Clear();
            if(_unitSettings.AppTheme=="Dark")
                Application.Current.UserAppTheme = OSAppTheme.Dark;

            //TODO: test area... remove when finished
            IWellboreTubular wellboreTubular;                           //Holds an instance of the tubular
            IDrillstringTubular drillstringTubular;
            ITubularFactory tubularFactory = new TubularFactory();      //instantiate the tubular factory
            ITubularFactory dsTubularFactory = new TubularFactory();

            wellboreTubular = tubularFactory.CreateWellboreTubular(WellboreTubularType.Casing);// GetWellboreTubular("Casing");  //Get a tubular from the factory
            wellboreTubular.ItemID = 1;
            wellboreTubular.InsideDiameter = 222;
            System.Diagnostics.Debug.WriteLine("Tubular is:" + wellboreTubular.ToString());
            System.Diagnostics.Debug.WriteLine("Tubular is:" + wellboreTubular.GetType());

            drillstringTubular = dsTubularFactory.CreateDrillstringTubular(DrillstringTubularType.HeviWateDrillPipe);
            drillstringTubular.ItemID = 0;
            drillstringTubular.OutsideDiameter = 111d;

            //var x = odb3.SaveItemAsync(wellboreTubular);
            //dataService.DeleteItemAsync(wellboreTubular);
            //dataService.SaveItemAsync(drillstringTubular);
            //System.Diagnostics.Debug.WriteLine("Database Written");

            System.Diagnostics.Debug.WriteLine("UNITS: " + Mass.Kilogram.LongName + " " + Mass.Kilogram.ShortName);
            System.Diagnostics.Debug.WriteLine("String = " + Mass.Kilogram.ToString());
            System.Diagnostics.Debug.WriteLine("Settings service::: " + _unitSettings.LongLengthUnit);
            _unitSettings.LongLengthUnit = LongLength.Foot;
            System.Diagnostics.Debug.WriteLine("Settings service::: " + _unitSettings.LongLengthUnit);
        }
    }
}
