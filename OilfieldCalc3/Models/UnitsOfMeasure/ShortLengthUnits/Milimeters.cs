using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.ShortLengthUnits
{
    public class Milimeters : ShortLength
    {
        public override string LongName => "milimeters";
        public override string ShortName => "mm";
        public override double ConversionFactor => 1d;
    }
}
