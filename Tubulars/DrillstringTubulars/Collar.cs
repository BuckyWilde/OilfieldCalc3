using SQLite;

namespace Tubulars.DrillstringTubulars
{
    [Table("Drillstring")]
    public class Collar : DrillstringTubularBase
    {
        public override string ItemDescription => "Collars";
    }
}
