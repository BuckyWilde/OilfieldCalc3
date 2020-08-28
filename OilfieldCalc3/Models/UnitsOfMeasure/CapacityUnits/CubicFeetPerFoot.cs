using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.CapacityUnits
{
    public class CubicFeetPerFoot : Capacity
    {
        public override string LongName => "cubic feel per foot";
        public override string ShortName => "ft3/ft";
        public override double ConversionFactor => 10.7639;
    }
}
