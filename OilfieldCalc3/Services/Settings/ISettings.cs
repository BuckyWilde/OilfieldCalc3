
// ********************************************************************************************************************
// Assembly             :  OilfieldCalc3
// Author               :  Scott Michael Bidulka
// Created              :  08-26-2020
//
// Last Modified By     :  Scott Michael Bidulka
// Last Modified On     :  09-07-2020
// ********************************************************************************************************************
// <copyright company="Buck Wilde Enterprises">
//      Copyright (c) Scott Michael Bidulka. All rights reserved.
// </copyright>
// <summary>
//      Public interface for user preferences.
// </summary>
// ********************************************************************************************************************
using OilfieldCalc3.Models.UnitsOfMeasure;
using System.Threading.Tasks;

namespace OilfieldCalc3.Services.Settings
{
    public interface ISettings
    {
        //TODO: Add user settings here...
        UnitBase LongLengthUnit { get; set; }
        UnitBase ShortLengthUnit { get; set; }
        UnitBase VolumeUnit { get; set; }
        UnitBase CapacityUnit { get; set; }
        UnitBase MassUnit { get; set; }
        string AppTheme { get; set; }

        bool ContainsKey(string key);
        void Remove(string key);
        void Clear();

        //bool GetValueOrDefault(string key, bool defaultValue);
        //string GetValueOrDefault(string key, string defaultValue);
        //double GetValueOrDefault(string key, double defaultValue);
        //UnitBase GetValueOrDefault(string key, UnitBase defaultValue);

        //void AddOrUpdateValue(string key, bool value);
        //void AddOrUpdateValue(string key, string value);
        //void AddOrUpdateValue(string key, double value);
        //void AddOrUpdateValue(string key, UnitBase defaultValue);
    }
}
