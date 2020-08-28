using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.VolumeUnits
{
    public class OilBarrels : Volume
    {
        public override string LongName => "oil barrels";
        public override string ShortName => "bbl";
        public override double ConversionFactor => 6.28981077;
    }
}
