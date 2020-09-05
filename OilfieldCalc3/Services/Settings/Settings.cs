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
    public class Settings : IUnitSettings, ISettings
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
            get => GetComplexValueOrDefault(LongLengthKey, LongLengthDefault);
            set=> AddOrUpdateComplexValue(LongLengthKey, value);
        }

        public UnitBase ShortLengthUnit
        {
            get => GetComplexValueOrDefault(ShortLengthKey, ShortLengthDefault);
            set => AddOrUpdateComplexValue(ShortLengthKey, value);
        }

        public UnitBase VolumeUnit
        {
            get => GetComplexValueOrDefault(VolumeKey, VolumeDefault);
            set => AddOrUpdateComplexValue(VolumeKey, value);
        }

        public UnitBase CapacityUnit
        {
            get => GetComplexValueOrDefault(CapacityKey, CapacityDefault);
            set => AddOrUpdateComplexValue(CapacityKey, value);
        }

        public UnitBase MassUnit
        {
            get => GetComplexValueOrDefault(MassKey, MassDefault);
            set => AddOrUpdateComplexValue(MassKey, value);
        }

        public string AppTheme
        {
            get => GetValueOrDefault(ApplicationThemeKey, ApplicationThemeDefault);
            set => AddOrUpdateValue(ApplicationThemeKey, value);
        }
        #endregion

        #region Public Methods
        public UnitBase GetComplexValueOrDefault(string key, UnitBase defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public Task AddOrUpdateComplexValue(string key, UnitBase value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, bool value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, string value) => AddOrUpdateValueInternal(key, value);
        public bool GetValueOrDefault(string key, bool defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public string GetValueOrDefault(string key, string defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        #endregion

        #region Internal Implementation
        /// <summary>
        /// All values are deserialized and restored to their respective base objects
        /// </summary>
        /// <typeparam name="T">Generic return type</typeparam>
        /// <param name="key">Reference key</param>
        /// <param name="defaultValue">Default value to be used in no key exists</param>
        /// <returns></returns>
        private T GetValueOrDefaultInternal<T>(string key, T defaultValue = default(T))
        {
            object value = null;

            if(Preferences.ContainsKey(key))
            {
                value = JsonConvert.DeserializeObject<T>((string)Preferences.Get(key, null), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
            }
            return null != value ? (T)value : defaultValue;
        }

        /// <summary>
        /// Value is serialized prior to storage as string.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="key">Reference key for lookup</param>
        /// <param name="value">Value of the data being saved to preferences.</param>
        /// <returns></returns>
        private async Task AddOrUpdateValueInternal<T>(string key, T value)
        {
            if (value == null)
            {
                await Task.Run(() => Preferences.Remove(key));
            }

            Preferences.Set(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
        }
        #endregion
    }
}
