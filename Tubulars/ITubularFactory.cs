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
//      Interface for the abstract factory class
// </summary>
// ********************************************************************************************************************
namespace Tubulars
{
    public interface ITubularFactory
    {
        IWellboreTubular CreateWellboreTubular(WellboreTubularType tubularType);
        IDrillstringTubular CreateDrillstringTubular(DrillstringTubularType tubularType);

    }
}
