using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.VolumeUnits
{
    public class CubicFeet : Volume
    {
        public override string LongName => "cubic feet";
        public override string ShortName => "ft3";
        public override double ConversionFactor => 35.3146667;
    }
}
