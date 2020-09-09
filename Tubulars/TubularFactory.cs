// ********************************************************************************************************************
// Assembly             :  OilfieldCalc3
// Author               :  Scott Michael
// Created              :  08-14-2020
//
// Last Modified By     :  Scott Michael Bidulka
// Last Modified On     :  08-14-2020
// ********************************************************************************************************************
// <copyright company="Buck Wilde Enterprises">
//      Copyright (c) Scott Michael Bidulka. All rights reserved.
// </copyright>
// <summary>
//      Tubular factory for creation of wellbore and drillstring concrete objects
// </summary>
// ********************************************************************************************************************
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
