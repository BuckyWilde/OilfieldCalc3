using OilfieldCalc3.Models.UnitsOfMeasure.CapacityUnits;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure
{
    public abstract class Capacity : UnitBase
    {
        public static CubicFeetPerFoot CubicFeetPerFoot { get { return new CubicFeetPerFoot(); } }
        public static CubicMetersPerMeter CubicMetersPerMeter { get { return new CubicMetersPerMeter(); } }
        public static OilBarrelsPerFoot OilBarrelsPerFoot { get { return new OilBarrelsPerFoot(); } }
        public static FluidBarrelsPerFoot FluidBarrelsPerFoot { get { return new FluidBarrelsPerFoot(); } }
    }
}
