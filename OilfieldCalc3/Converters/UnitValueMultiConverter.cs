using FastExpressionCompiler.LightExpression;
using OilfieldCalc3.Models.UnitsOfMeasure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace OilfieldCalc3.Converters
{
    public class UnitValueMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            UnitBase unitBase;
            double metricValue;
            double convertedValue;
            double conversionFactor;

            //1st value is the original metric value provided from the sender
            if (values?[0] != null)
            {
                StringBuilder completeString = new StringBuilder();
                metricValue = (double)values[0];
                completeString.Append(metricValue);

                //2nd value is the Unit in use for the value
                if (values[1] != null)
                {
                    unitBase = values[1] as UnitBase;
                    conversionFactor = unitBase.ConversionFactor;
                    convertedValue = metricValue * conversionFactor;

#pragma warning disable CA1305 // Specify IFormatProvider
                    if (unitBase.GetType().BaseType == typeof(LongLength) || unitBase.GetType() == typeof(ShortLength))
                    {
                        completeString = new StringBuilder(string.Format("{0:F2}", convertedValue));
                    }
                    else
                    {
                        completeString = new StringBuilder(string.Format("{0:F4}", convertedValue));
                    }
#pragma warning restore CA1305 // Specify IFormatProvider

                    //3rd value is the string to prepend with for the label
                    if (values[2] != null)
                    {
                        completeString.Insert(0, values[2].ToString() + " = ");
                    }

                    if (parameter != null)
                    {
                        switch (parameter)
                        {
                            case "ShortName":
                                completeString.Append(' ').Append(unitBase.ShortName);
                                break;
                            case "LongName":
                                completeString.Append(' ').Append(unitBase.LongName);
                                break;
                            default:
                                completeString.Append(' ').Append(unitBase.ShortName);
                                break;
                        }

                    }
                }

                return completeString;
            }

            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
