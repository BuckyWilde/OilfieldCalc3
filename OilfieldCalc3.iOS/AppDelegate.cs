﻿using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;

namespace OilfieldCalc3.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

            Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
            Syncfusion.XForms.iOS.EffectsView.SfEffectsViewRenderer.Init();
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfButtonRenderer.Init();
            Syncfusion.XForms.iOS.Expander.SfExpanderRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }

#pragma warning disable IDE1006 // Naming Styles
    public class iOSInitializer : IPlatformInitializer
#pragma warning restore IDE1006 // Naming Styles
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
