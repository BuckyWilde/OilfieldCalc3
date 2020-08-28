using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.LongLengthUnits
{
    public class Meters : LongLength
    {
        public override string LongName => "meters";
        public override string ShortName => "m";
        public override double ConversionFactor => 1d;
    }
}
