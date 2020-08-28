
using SQLite;

namespace Tubulars.WellboreTubulars
{
    [Table("Wellbore")]
    public class Casing : WellboreTubularBase
    {
        public override string ItemDescription => "Casing";

        public override int WashoutFactor { get; set; } = 0;
    }
}
