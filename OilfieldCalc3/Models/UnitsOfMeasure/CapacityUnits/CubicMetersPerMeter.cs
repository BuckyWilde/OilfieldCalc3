using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.CapacityUnits
{
    public class CubicMetersPerMeter : Capacity
    {
        public override string LongName => "cubic meters per meter";
        public override string ShortName => "m3/m";
        public override double ConversionFactor => 1d;
    }
}
