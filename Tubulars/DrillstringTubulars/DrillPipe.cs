using SQLite;

namespace Tubulars.DrillstringTubulars
{
    [Table("Drillstring")]
    public class DrillPipe : DrillstringTubularBase
    {
        public override string ItemDescription => "Drill Pipe";
    }
}
