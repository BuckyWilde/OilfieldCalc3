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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzExNjUwQDMxMzgyZTMyMmUzMEVKNUk4dHZYWk12T0pTdWovNDFBZzZIQmFuU3htRlczQkxrTXYyaG56b289;MzExNjUxQDMxMzgyZTMyMmUzMG1EUXBBM3BvRnovUk8xZm0weSsxV1hueGpIOGtaYitDZHQyRHBEdmJySG89;MzExNjUyQDMxMzgyZTMyMmUzMGFUVUlFMnNGL09XT1E0UjBYYTY4bTM3dXExUWlOeU43enhUeUVaS3BwdHM9;MzExNjUzQDMxMzgyZTMyMmUzMFhPWE9jcVpDbW90NDZYbFFjdnpXVHBzVjhhRy9vaG1ycTIxTGRSbTU2cjQ9;MzExNjU0QDMxMzgyZTMyMmUzMFZKNm5nRGhtQjlMZFVrSDNDK1lxdHNyaE45amxLeTN3K3ZDL0FmTFRDTEU9;MzExNjU1QDMxMzgyZTMyMmUzMGYyTm1BMm5VTWVNbitpQWxBMVZlQ0trcklqVEFNTVM0NzFBVzc0RktrTVk9;MzExNjU2QDMxMzgyZTMyMmUzMGNpYU5IaWdWM2hDZ08ra1NKN2dJTnFhMWY0V1g4dXFkSGlnMklTRXFvODg9;MzExNjU3QDMxMzgyZTMyMmUzMEVtK1JMVTdhdnowRGlwd1lra294KzNtTDRGeTZGWVQvVnRQbkRObTJyeVE9;MzExNjU4QDMxMzgyZTMyMmUzMGJhMXo1enRwNWF5cWdiK3RxUDhXd0RrOGNmVDJCcWZTVTRNZ0tpQ25iWnc9;NT8mJyc2IWhia31hfWN9Z2doYmF8YGJ8ampqanNiYmlmamlmanMDHmggMDwnJ30xOjcmPzgyEzQ+Mjo/fTA8Pg==;MzExNjU5QDMxMzgyZTMyMmUzMFlsd1kvRjVyWmp0WVVmTGtpaHY5QndsbkppS1FONHllMDBYYll4azBWVjA9");

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
            containerRegistry.RegisterSingleton<IUnitSettings, Settings>();

            containerRegistry.RegisterForNavigation<NavigationMasterDetailPage, NavigationMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsTabbedPage, SettingsTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsAboutPage, SettingsAboutPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsAdvancedPage, SettingsAdvancedPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsUnitsPage, SettingsUnitsPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsUserPage, SettingsUserPageViewModel>();
        }
    }
}
