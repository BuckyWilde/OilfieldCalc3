
namespace Tubulars
{
    public interface ITubularFactory
    {
        IWellboreTubular CreateWellboreTubular(WellboreTubularType tubularType);
        IDrillstringTubular CreateDrillstringTubular(DrillstringTubularType tubularType);

    }
}
