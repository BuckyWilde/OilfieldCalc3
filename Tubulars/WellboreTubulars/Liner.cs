
using SQLite;

namespace Tubulars.WellboreTubulars
{
    [Table("Wellbore")]
    public class Liner : WellboreTubularBase
    {
        public override string ItemDescription => "Liner";

        public override int WashoutFactor { get; set; } = 0;
    }
}
