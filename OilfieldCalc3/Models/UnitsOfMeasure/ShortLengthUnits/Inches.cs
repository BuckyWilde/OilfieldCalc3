using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.ShortLengthUnits
{
    public class Inches : ShortLength
    {
        public override string LongName => "inches";
        public override string ShortName => "in";
        public override double ConversionFactor => 0.03937007874;
    }
}
