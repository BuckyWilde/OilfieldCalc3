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
//      Static class for common tubular calculations
// </summary>
// ********************************************************************************************************************
using System;

namespace Tubulars
{
    public static class TubularMath
    {
        /// <summary>Gets the dry displacement. The dry displacement is the displacement material of the tubular</summary>
        /// <param name="outsideDiameter">The outside Diameter.</param>
        /// <param name="insideDiameter">The inside diameter.</param>
        /// <returns>Double value representing the dry displacement of the tubular</returns>
        public static double GetDryDisplacement(double outsideDiameter, double insideDiameter)
        {
            return Math.PI * (Math.Pow(outsideDiameter / 2, 2) - Math.Pow(insideDiameter / 2, 2)) / 1000000;
        }

        /// <summary>Gets the annular capacity. The annulus is the space between an outer and inner cylinder</summary>
        /// <param name="insideDiameter">The inside diameter of the outer tubular.</param>
        /// <param name="outsideDiameter">The outside diameter of the inner tubular.</param>
        /// <returns>Double value representing the annular capacity</returns>
        public static double GetAnnularCapacity(double insideDiameter, double outsideDiameter)
        {
            return Math.PI * (Math.Pow(insideDiameter / 2, 2) - Math.Pow(outsideDiameter / 2, 2)) / 1000000;
        }

        /// <summary>Gets the wet displacement. The wet displacement is the displacement of the tubular as if it has closed ends.</summary>
        /// <param name="outsideDiameter">The outside diameter.</param>
        /// <returns>Double value representing the wet displacement.</returns>
        public static double GetWetDisplacement(double outsideDiameter)
        {
            return Math.PI * (Math.Pow(outsideDiameter / 2, 2)) / 1000000;
        }

        /// <summary>Gets the internal capacity. The internal capacity is the capacity of the tubular cylinder.</summary>
        /// <param name="insideDiameter">The inside diameter.</param>
        /// <returns>Double value representing the internal capacity.</returns>
        public static double GetInternalCapacity(double insideDiameter)
        {
            return Math.PI * (Math.Pow(insideDiameter / 2, 2)) / 1000000;
        }
    }
}
