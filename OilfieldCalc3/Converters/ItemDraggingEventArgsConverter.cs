using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace OilfieldCalc3.Converters
{
    public class ItemDraggingEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemDraggingEventArgs = value as ItemDraggingEventArgs;

            if(itemDraggingEventArgs==null)
            {
                throw new ArgumentException("Expected value to be of type ItemDraggingEventArgs", nameof(value));
            }
            return itemDraggingEventArgs;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
