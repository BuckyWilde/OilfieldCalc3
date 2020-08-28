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
//      Base interface common to all wellbore tubulars in the well. Casing and open hole are both
//      concidered wellbore tubulars
// </summary>
// ********************************************************************************************************************

namespace Tubulars
{
    /// <summary>Public interface for all wellbore tubular items. Inherits from ITubularbase</summary>
    public interface IWellboreTubular : ITubular
    {
        /// <summary>Gets or sets the start depth.</summary>
        /// <value>The start depth.</value>
        double StartDepth { get; set; }

        /// <summary>Gets or sets the end deth.</summary>
        /// <value>The end deth.</value>
        double EndDepth { get; set; }

        /// <summary>Gets or sets the washout factor.</summary>
        /// <value>The washout factor.</value>
        int WashoutFactor { get; set; }

    }
}
