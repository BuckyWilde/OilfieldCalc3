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
//      Interface for drillstring tubulars
// </summary>
// ********************************************************************************************************************
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
