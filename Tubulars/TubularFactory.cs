using Tubulars.DrillstringTubulars;
using Tubulars.WellboreTubulars;

namespace Tubulars
{
    public class TubularFactory : ITubularFactory
    {
        public IDrillstringTubular CreateDrillstringTubular(DrillstringTubularType tubularObject)
        {
            switch (tubularObject)
            {
                case DrillstringTubularType.Collars:
                    return new Collar();
                case DrillstringTubularType.DrillPipe:
                    return new DrillPipe();
                case DrillstringTubularType.HeviWateDrillPipe:
                    return new HeviWateDrillPipe();
                case DrillstringTubularType.PushPipe:
                    return new PushPipe();
                default:
                    return null;
            }
        }

        public IWellboreTubular CreateWellboreTubular(WellboreTubularType tubularObject)
        {
            switch (tubularObject)
            {
                case WellboreTubularType.Casing:
                    return new Casing();
                case WellboreTubularType.Liner:
                    return new Liner();
                case WellboreTubularType.OpenHole:
                    return new OpenHole();
                default:
                    return null;
            }
        }
    }
}
