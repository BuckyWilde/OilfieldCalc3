using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.VolumeUnits
{
    public class FluidBarrels : Volume
    {
        public override string LongName => "fluid barrels";
        public override string ShortName => "bbl";
        public override double ConversionFactor => 8.38641436;
    }
}
