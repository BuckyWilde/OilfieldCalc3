using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.CapacityUnits
{
    public class OilBarrelsPerFoot : Capacity
    {
        public override string LongName => "oil barrels per foot";
        public override string ShortName => "bbl/ft";
        public override double ConversionFactor => 1.91713;
    }
}
