using OilfieldCalc3.Models.UnitsOfMeasure.LongLengthUnits;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure
{
    public abstract class LongLength : UnitBase
    {
        public static Meters Meter { get { return new Meters(); } }
        public static Feet Foot { get { return new Feet(); } }
    }
}
