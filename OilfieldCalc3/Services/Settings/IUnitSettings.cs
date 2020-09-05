// ********************************************************************************************************************
// Assembly             :  OilfieldCalc3
// Author               :  Scott Michael Bidulka
// Created              :  08-25-2020
//
// Last Modified By     :  Scott Michael Bidulka
// Last Modified On     :  08-26-2020
// ********************************************************************************************************************
// <copyright company="Buck Wilde Enterprises">
//      Copyright (c) Scott Michael Bidulka. All rights reserved.
// </copyright>
// <summary>
//      Public interface for user preferences dealing with units of measure
// </summary>
// ********************************************************************************************************************
using OilfieldCalc3.Models.UnitsOfMeasure;
using System.Threading.Tasks;

namespace OilfieldCalc3.Services.Settings
{
    public interface IUnitSettings
    {
        UnitBase LongLengthUnit { get; set; }
        UnitBase ShortLengthUnit { get; set; }
        UnitBase VolumeUnit { get; set; }
        UnitBase CapacityUnit { get; set; }
        UnitBase MassUnit { get; set; }
        string AppTheme { get; set; }

        UnitBase GetComplexValueOrDefault(string key, UnitBase defaultValue);
        Task AddOrUpdateComplexValue(string key, UnitBase value);

        bool GetValueOrDefault(string key, bool defaultValue);
        string GetValueOrDefault(string key, string defaultValue);

        Task AddOrUpdateValue(string key, bool value);
        Task AddOrUpdateValue(string key, string value);
    }
}
