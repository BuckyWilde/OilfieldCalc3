using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure.MassUnits
{
    public class Pounds : Mass
    {
        public override string LongName => "pounds";
        public override string ShortName => "lbs";
        public override double ConversionFactor => 2.204622621848776;
    }
}
