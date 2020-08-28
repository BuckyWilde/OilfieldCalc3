
// ********************************************************************************************************************
// Assembly             :  OilfieldCalc3
// Author               :  Scott Michael Bidulka
// Created              :  08-26-2020
//
// Last Modified By     :  Scott Michael Bidulka
// Last Modified On     :  08-26-2020
// ********************************************************************************************************************
// <copyright company="Buck Wilde Enterprises">
//      Copyright (c) Scott Michael Bidulka. All rights reserved.
// </copyright>
// <summary>
//      Public interface for user preferences dealing with settings of primative types.
// </summary>
// ********************************************************************************************************************
using System.Threading.Tasks;

namespace OilfieldCalc3.Services.Settings
{
    public interface ISettings
    {
        //TODO: Add user settings here...

        bool GetValueOrDefault(string key, bool defaultValue);
        string GetValueOrDefault(string key, string defaultValue);

        Task AddOrUpdateValue(string key, bool value);
        Task AddOrUpdateValue(string key, string value);
    }
}
