
namespace Tubulars
{
    public interface IDrillstringTubular : ITubular
    {
        double OutsideDiameter { get; set; }
        double AdjustedWeight { get; set; }
        double TotalWeight { get; }

        double DryDisplacementPerUnit { get; }
        double WetDisplacementPerUnit { get; }
        double TotalDryDisplacement { get; }
        double TotalWetDispalcement { get; }
    }
}
