using OilfieldCalc3.Models.UnitsOfMeasure.VolumeUnits;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure
{
    public abstract class Volume : UnitBase
    {
        public static CubicFeet CubicFoot { get { return new CubicFeet(); } }
        public static CubicMeters CubicMeter { get { return new CubicMeters(); } }
        public static OilBarrels OilBarrel { get { return new OilBarrels(); } }
        public static FluidBarrels FluidBarrel { get { return new FluidBarrels(); } }
    }
}
