using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tubulars.DrillstringTubulars
{
    [Table("Drillstring")]
    public class PushPipe : DrillstringTubularBase
    {
        public override string ItemDescription => "Push Pipe";
    }
}
