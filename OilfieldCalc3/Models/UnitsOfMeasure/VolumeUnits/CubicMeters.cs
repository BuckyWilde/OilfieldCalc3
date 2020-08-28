using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.VolumeUnits
{
    public class CubicMeters : Volume
    {
        public override string LongName => "cubic meters";
        public override string ShortName => "m3";
        public override double ConversionFactor => 1d;
    }
}
