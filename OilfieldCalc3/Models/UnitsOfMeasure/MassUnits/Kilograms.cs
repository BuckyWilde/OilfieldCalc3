using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.MassUnits
{
    public class Kilograms : Mass
    {
        public override string LongName => "kilograms";
        public override string ShortName => "kg";
        public override double ConversionFactor => 1d;
    }
}
