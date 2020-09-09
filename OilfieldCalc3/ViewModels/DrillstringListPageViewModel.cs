using OilfieldCalc3.Models.UnitsOfMeasure;
using OilfieldCalc3.Resx;
using OilfieldCalc3.Services;
using OilfieldCalc3.Services.Settings;
using OilfieldCalc3.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tubulars;
using Tubulars.DrillstringTubulars;

namespace OilfieldCalc3.ViewModels
{
    public class DrillstringListPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        IDataService _dataService;
        ISettings _settings;

        #region Properties
        private bool _listviewIsBusy;
        public bool ListviewIsBusy
        {
            get => _listviewIsBusy;
            set => SetProperty(ref _listviewIsBusy, value);
        }

        private ObservableCollection<ITubular> _drillstringTubulars;
        public ObservableCollection<ITubular> DrillstringTubulars
        {
            get => _drillstringTubulars;
            set => SetProperty(ref _drillstringTubulars, value);
        }

        private IDrillstringTubular _selectedItem;
        public IDrillstringTubular SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                //OnDeleteCommand.RaiseCanExecuteChanged();
                //OnEditCommand.RaiseCanExecuteChanged();
            }
        }

        //total dry displacement of the steel
        private double _totalDisplacement;
        public double TotalDisplacement
        {
            get => _totalDisplacement;
            set => SetProperty(ref _totalDisplacement, value);
        }

        //total internal volume capacity of all the tubulars
        private double _totalVolume;
        public double TotalVolume
        {
            get => _totalVolume;
            set => SetProperty(ref _totalVolume, value);
        }

        //Total length of all the tubulars
        private double _totalTubularLength;
        public double TotalTubularLength
        {
            get => _totalTubularLength;
            set => SetProperty(ref _totalTubularLength, value);
        }

        //Total well depth based on the length of the wellbore tubulars
        private double _totalWellDepth;
        public double TotalWellDepth
        {
            get => _totalWellDepth;
            set => SetProperty(ref _totalWellDepth, value);
        }

        //Total weight of the tubulars (weight of the steel in air)
        private double _totalWeight;
        public double TotalWeight
        {
            get => _totalWeight;
            set => SetProperty(ref _totalWeight, value);
        }

        public UnitBase LongLengthUnit => _settings.LongLengthUnit;
        public UnitBase ShortLengthUnit => _settings.ShortLengthUnit;
        public UnitBase VolumeUnit => _settings.VolumeUnit;
        public UnitBase CapacityUnit => _settings.CapacityUnit;
        public UnitBase MassUnit => _settings.MassUnit;
        #endregion

        #region Delegate Commands
        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand EditCommand { get; }
        public DelegateCommand<object> UpCommand { get; }
        public DelegateCommand<object> DownCommand { get; }
        public DelegateCommand<ItemDraggingEventArgs> ItemDraggingCommand { get; set; }
        #endregion

        public DrillstringListPageViewModel(INavigationService navigationService, IDataService dataService, ISettings settings)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _settings = settings;

            Title = AppResources.DrillstringPageTitle;
            _listviewIsBusy = false;

            #region Initialize Delegate Commands
            //Initialize commands in the constructor using anonymous methods
            DeleteCommand = new DelegateCommand(async () =>
            {
                if (_selectedItem is IDrillstringTubular dst)
                {
                    DrillstringTubulars.Remove(dst);   //remove the item from the collection
                    await _dataService.DeleteItemAsync(dst).ConfigureAwait(false); //Delete the record from the database
                }

                //Recalculate to compensate for the deleted item
                _totalTubularLength = GetTotalTublarLength();
                _totalDisplacement = GetTotalDryDisplacement();
                _totalWeight = GetTotalWeight();
                _totalVolume = GetTotalInternalVolume();

                UpCommand.RaiseCanExecuteChanged();
                DownCommand.RaiseCanExecuteChanged();
            }, () => _selectedItem != null);

            //EditCommand = new DelegateCommand(EditCommandExecuted, CanEdit);
            EditCommand = new DelegateCommand(async () =>
            {
                if (SelectedItem is IDrillstringTubular dst)
                {
                    var navigationParams = new NavigationParameters();
                    navigationParams.Add("drillstringTubular", dst);
                    await _navigationService.NavigateAsync(nameof(DrillstringDetailPage), navigationParams).ConfigureAwait(false);
                }
            }, () => _selectedItem != null);

            ItemDraggingCommand = new DelegateCommand<ItemDraggingEventArgs>(async (ItemDraggingEventArgs args) =>
              {
                  if (args != null && args.Action == DragAction.Drop)
                  {
                      ListviewIsBusy = true;
                      await Xamarin.Forms.Device.InvokeOnMainThreadAsync(() => ItemizeSortOrder()).ConfigureAwait(false);
                      ListviewIsBusy = false;
                  }
              });
            #endregion
        }

        #region Private Methods

        private double GetTotalTublarLength()
        {
            double totalLength = 0d;

            if (_drillstringTubulars != null)
            {
                //return the total length of all tubulars in the collection
                foreach (IDrillstringTubular dst in _drillstringTubulars)
                {
                    totalLength += dst.Length;
                }
                return totalLength;
            }
            return totalLength;
        }

        private double GetTotalDryDisplacement()
        {
            double totalDiplacement = 0d;

            if (_drillstringTubulars != null)
            {
                foreach (IDrillstringTubular dst in _drillstringTubulars)
                {
                    totalDiplacement += dst.TotalDryDisplacement;
                }
                return totalDiplacement;
            }
            return totalDiplacement;
        }

        private double GetTotalWeight()
        {
            double totalWeight = 0d;

            if (_drillstringTubulars != null)
            {
                foreach (IDrillstringTubular dst in _drillstringTubulars)
                {
                    totalWeight += dst.TotalWeight;
                }
                return totalWeight;
            }
            return totalWeight;
        }

        private double GetTotalInternalVolume()
        {

            double totalInternalVolume = 0d;

            if (_drillstringTubulars != null)
            {
                foreach (IDrillstringTubular dst in _drillstringTubulars)
                {
                    totalInternalVolume += dst.TotalInternalCapacity;
                }
                return totalInternalVolume;
            }
            return totalInternalVolume;
        }

        private async ValueTask<int> ItemizeSortOrder()
        {
            int itemsSaved = 0;

            for (int j = 0; j < DrillstringTubulars.Count; j++)
            {
                DrillstringTubulars[j].ItemSortOrder = j;
                itemsSaved+=await _dataService.SaveItemAsync(DrillstringTubulars[j]).ConfigureAwait(false);
            }
            return itemsSaved;
        }
        #endregion

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //Make sure these reinitialize to false when returning to this screen...
            _selectedItem = null;
            DeleteCommand.RaiseCanExecuteChanged();
            EditCommand.RaiseCanExecuteChanged();

            //Load the drillstring Tubulars from the dataservice.
            DrillstringTubulars = new ObservableCollection<ITubular>(await _dataService.GetItemsSortedAsync<DrillPipe>().ConfigureAwait(false));
        }
    }
}
