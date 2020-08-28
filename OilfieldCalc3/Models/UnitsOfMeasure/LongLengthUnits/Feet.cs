using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.LongLengthUnits
{
    public class Feet : LongLength
    {
        public override string LongName => "feet";
        public override string ShortName => "ft";
        public override double ConversionFactor => 3.280839895d;
    }
}
