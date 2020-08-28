using OilfieldCalc3.Models.UnitsOfMeasure.ShortLengthUnits;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure
{
    public abstract class ShortLength : UnitBase
    {
        public static Milimeters Milimeter { get { return new Milimeters(); } }
        public static Inches Inch { get { return new Inches(); } }
    }
}
