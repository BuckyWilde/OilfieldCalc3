using OilfieldCalc3.Models.UnitsOfMeasure.MassUnits;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure
{
    public abstract class Mass : UnitBase
    {
        public static Kilograms Kilogram { get { return new Kilograms(); } }
        public static Pounds Pound { get { return new Pounds(); } }
    }
}
