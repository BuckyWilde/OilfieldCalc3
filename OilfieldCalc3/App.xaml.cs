using Prism;
using Prism.Ioc;
using OilfieldCalc3.ViewModels;
using OilfieldCalc3.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using OilfieldCalc3.Services;
using OilfieldCalc3.Services.Settings;

namespace OilfieldCalc3
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQxNzIyQDMxMzgyZTMzMmUzMGtwNWJyTDVPZmRwMmJBQ0VWSE01MW5adlE1RkpqYzNVMkZ3WmlPS0FiQkE9;MzQxNzIzQDMxMzgyZTMzMmUzMGx6WmM0Um1wa0s5enJudlA0bHorenBjUk5vS0Q1amNWUE1udHVUUXZFU3M9;MzQxNzI0QDMxMzgyZTMzMmUzMEwwWVVCV1d4OFlvRFRWSFAzelpPVUU4Y1g4cFNkdDFkYm8wTFd5MXkrblU9;MzQxNzI1QDMxMzgyZTMzMmUzMGdUc1pZZlljdG81NmxONm1NZ3ZsMXJlclRlWGFVY0RQMTVhVzlCMHR5bFU9;MzQxNzI2QDMxMzgyZTMzMmUzMFpGYXlLSXJnQmdYTmYzb2pYWFZKbW8wSk0xZFZMbS9HbCtHdzVLWGZ0UEU9;MzQxNzI3QDMxMzgyZTMzMmUzMG9pQUVRQ1dxZy9ZOHd5TFhORmtrUFJKdGxMTXFxQXpTdVl0UE5YNUNFLzQ9;MzQxNzI4QDMxMzgyZTMzMmUzMGgzRnRUWjIwcWpGZzlpNkNRbnZXVnNBQUk1YmtGSE1KUG5DNno5RTltME09;MzQxNzI5QDMxMzgyZTMzMmUzMFR4bE51TkJFMWVPVE5DVDU3elFQeS9VWDUzTEZKMVBIRU9oSDcyNXplZE09;MzQxNzMwQDMxMzgyZTMzMmUzMGhZM3ZzUWZ0bHpOaDZNem85bC9NeUFpUzVOaitHYW5teGtnTXRITFN2Y009;MzQxNzMxQDMxMzgyZTMzMmUzMGpYdVJ4eUlZM1VwSEw5UXNNK2ZRNnVRcytrQWt3YXdIVUczU0Z2ZFNGMms9");

            InitializeComponent();
            Device.SetFlags(new string[] { "AppTheme_Experimental", "Expander_Experimental", "SwipeView_Experimental", "DragAndDrop_Experimental" });

            await NavigationService.NavigateAsync("NavigationMasterDetailPage/NavigationPage/MainPage").ConfigureAwait(false);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterSingleton<IDataService, DataService>();
            containerRegistry.RegisterSingleton<ISettings, Settings>();

            containerRegistry.RegisterForNavigation<NavigationMasterDetailPage, NavigationMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsTabbedPage, SettingsTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsAboutPage, SettingsTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsAdvancedPage, SettingsTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsUnitsPage, SettingsTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsUserPage, SettingsTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<DrillstringListPage, DrillstringListPageViewModel>();
            containerRegistry.RegisterForNavigation<WellboreListPage, WellboreListPageViewModel>();
            containerRegistry.RegisterForNavigation<WellboreDetailPage, WellboreDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<DrillstringDetailPage, DrillstringDetailPageViewModel>();
            containerRegistry.RegisterDialog<WipeDatabaseDialogPage, WipeDatabaseDialogPageViewModel>();
        }
    }
}
