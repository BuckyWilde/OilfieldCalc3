
using SQLite;

namespace Tubulars.WellboreTubulars
{
    [Table("Wellbore")]
    public class OpenHole : WellboreTubularBase
    {
        public override string ItemDescription => "Open Hole";

        public override int WashoutFactor { get; set; } = 0;
    }
}
