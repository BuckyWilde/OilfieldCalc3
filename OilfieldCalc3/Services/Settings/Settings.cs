// ********************************************************************************************************************
// Assembly             :  OilfieldCalc3
// Author               :  Scott Michael Bidulka
// Created              :  08-24-2020
//
// Last Modified By     :  Scott Michael Bidulka
// Last Modified On     :  08-26-2020
// ********************************************************************************************************************
// <copyright company="Buck Wilde Enterprises">
//      Copyright (c) Scott Michael Bidulka. All rights reserved.
// </copyright>
// <summary>
//      Setting concrete object for setting and retrieving user preferences.
// </summary>
// ********************************************************************************************************************
using Newtonsoft.Json;
using OilfieldCalc3.Models.UnitsOfMeasure;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OilfieldCalc3.Services.Settings
{
    public class Settings : ISettings
    {
        #region UnitSettings Constants
        private const string LongLengthKey = "long_length_unit";
        private static readonly LongLength LongLengthDefault = LongLength.Meter;

        private const string ShortLengthKey = "short_length_unit";
        private static readonly ShortLength ShortLengthDefault = ShortLength.Milimeter;

        private const string VolumeKey = "volume_unit";
        private static readonly Volume VolumeDefault = Volume.CubicMeter;

        private const string CapacityKey = "capacity_unit";
        private static readonly Capacity CapacityDefault = Capacity.CubicMetersPerMeter;

        private const string MassKey = "mass_unit";
        private static readonly Mass MassDefault = Mass.Kilogram;

        private const string ApplicationThemeKey = "App_theme";
        private static readonly string ApplicationThemeDefault = "Light";
        #endregion

        #region Settings Properties
        public UnitBase LongLengthUnit
        {
            get => GetValueOrDefault(LongLengthKey, LongLengthDefault);
            set => AddOrUpdateValue(LongLengthKey, value);
        }

        public UnitBase ShortLengthUnit
        {
            get => GetValueOrDefault(ShortLengthKey, ShortLengthDefault);
            set => AddOrUpdateValue(ShortLengthKey, value);
        }

        public UnitBase VolumeUnit
        {
            get => GetValueOrDefault(VolumeKey, VolumeDefault);
            set => AddOrUpdateValue(VolumeKey, value);
        }

        public UnitBase CapacityUnit
        {
            get => GetValueOrDefault(CapacityKey, CapacityDefault);
            set => AddOrUpdateValue(CapacityKey, value);
        }

        public UnitBase MassUnit
        {
            get => GetValueOrDefault(MassKey, MassDefault);
            set => AddOrUpdateValue(MassKey, value);
        }

        public string AppTheme
        {
            get => GetValueOrDefault(ApplicationThemeKey, ApplicationThemeDefault);
            set => AddOrUpdateValue(ApplicationThemeKey, value);
        }
        #endregion

        #region private Methods
        //public UnitBase GetValueOrDefault(string key, UnitBase defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        private UnitBase GetValueOrDefault(string key, UnitBase defaultValue)
        {
            object value = null;

            if (Preferences.ContainsKey(key))
            {
                value = JsonConvert.DeserializeObject<UnitBase>((string)Preferences.Get(key, null), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }); 
            }
            return null != value ? (UnitBase)value : defaultValue;
        }

        private bool GetValueOrDefault(string key, bool defaultValue) => Preferences.Get(key, defaultValue);
        private double GetValueOrDefault(string key, double defaultValue) => Preferences.Get(key, defaultValue);
        private string GetValueOrDefault(string key, string defaultValue) => Preferences.Get(key, defaultValue);



        private void AddOrUpdateValue(string key, UnitBase value)
        {
            if (value == null)
            {
                Preferences.Remove(key);
            }
            Preferences.Set(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
        }

        private void AddOrUpdateValue(string key, bool value) => Preferences.Set(key, value);
        private void AddOrUpdateValue(string key, double value) => Preferences.Set(key, value);
        private void AddOrUpdateValue(string key, string value) => Preferences.Set(key, value);
        #endregion

        #region Public Methods
        public bool ContainsKey(string key) => Preferences.ContainsKey(key);

        public void Clear()
        {
            Preferences.Clear();
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }
        #endregion
    }
}
