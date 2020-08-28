using System;
using System.Collections.Generic;
using System.Text;

namespace OilfieldCalc3.Models.UnitsOfMeasure
{
    public abstract class UnitBase : IEquatable<UnitBase>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public virtual string LongName { get; }
        public virtual string ShortName { get; }
        public virtual double ConversionFactor { get; }

        public bool Equals(UnitBase other)
        {
            if (other == null)
                return false;

            return this.LongName == other.LongName;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            UnitBase uomObj = obj as UnitBase;

            if (uomObj == null)
                return false;
            else
                return this.Equals(uomObj);
        }

        public override int GetHashCode()
        {
            if (this.LongName == null || this.ShortName == null)
                return 0;
            else
                return this.LongName.GetHashCode();
        }

        public static bool operator ==(UnitBase obj1, UnitBase obj2)
        {
            if ((object)obj1 == null || (object)obj2 == null)
                return System.Object.Equals(obj1, obj2);

            return obj1.Equals(obj2);
        }

        public static bool operator !=(UnitBase obj1, UnitBase obj2)
        {
            return !(obj1 == obj2);
        }

        public override string ToString()
        {
            return LongName;
        }
    }
}
