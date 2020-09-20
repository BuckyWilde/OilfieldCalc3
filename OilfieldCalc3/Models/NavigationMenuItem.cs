using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using Xamarin.Forms;

namespace OilfieldCalc3.Models
{
    public class NavigationMenuItem : BindableBase
    {
        public string Title { get; set; }       //Name of the menu item
        public ImageSource IconBlack { get; set; }        //Icon image to display with the menu item
        public ImageSource IconWhite { get; set; }
        public string PageName { get; set; }    //Name of the page to navigate to.

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
    }
}
