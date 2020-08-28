using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.CapacityUnits
{
    public class FluidBarrelsPerFoot : Capacity
    {
        public override string LongName => "fluid barrels per foot";
        public override string ShortName => "bbl/ft";
        public override double ConversionFactor => 2.5561791;
    }
}
