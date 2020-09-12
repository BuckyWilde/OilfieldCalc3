// ********************************************************************************************************************
// Assembly             :  Tubulars
// Author               :  Scott Michael Bidulka
// Created              :  08-14-2020
//
// Last Modified By     :  Scott Michael Bidulka
// Last Modified On     :  08-26-2020
// ********************************************************************************************************************
// <copyright company="Buck Wilde Enterprises">
//      Copyright (c) Scott Michael Bidulka. All rights reserved.
// </copyright>
// <summary>
//      Base class common to all drillstring tubulars in the well. Drillpipe and Collars are both
//      concidered drillstring tubulars
// </summary>
// ********************************************************************************************************************
using System;
using SQLite;

namespace Tubulars
{
    [Table("Drillstring")]
    public abstract class DrillstringTubularBase : IDrillstringTubular
    {
        /// <summary>Gets or sets the item identifier.</summary>
        /// <value>The item identifier is used my the sqlite database for unique ID</value>
        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }

        /// <summary>Gets or sets the item sort order.</summary>
        /// <value>The item sort order.</value>
        public int ItemSortOrder { get; set; }

        /// <summary>Gets or sets the item description.</summary>
        /// <value>The item description is to be overridden in the concrete object.</value>
        public abstract string ItemDescription { get; }

        /// <summary>Gets or sets the length.</summary>
        /// <value>The length.</value>
        public double Length { get; set; }

        /// <summary>Gets or sets the outside diameter.</summary>
        /// <value>The outside diameter.</value>
        public double OutsideDiameter { get; set; }

        /// <summary>Gets or sets the inside diameter.</summary>
        /// <value>The inside diameter.</value>
        public double InsideDiameter { get; set; }

        /// <summary>Gets or sets the adjusted weight of the tubular in kg/m.</summary>
        /// <value>The adjusted weight metric value.</value>
        public double AdjustedWeight { get; set; }

        /// <summary>Gets the total weight of the tubular in kg.</summary>
        /// <value>The total metric weight.</value>
        [Ignore]
        public double TotalWeight => this.AdjustedWeight * this.Length;

        /// <summary>Gets the dry displacement per unit.</summary>
        /// <value>The dry displacement per unit.</value>
        [Ignore]
        public double DryDisplacementPerUnit => TubularMath.GetDryDisplacement(this.OutsideDiameter, this.InsideDiameter);

        /// <summary>Gets the wet displacement per unit.</summary>
        /// <value>The wet displacement per unit.</value>
        [Ignore]
        public double WetDisplacementPerUnit => TubularMath.GetWetDisplacement(this.OutsideDiameter);

        /// <summary>Gets the total dry displacement.</summary>
        /// <value>The total dry displacement.</value>
        [Ignore]
        public double TotalDryDisplacement => this.DryDisplacementPerUnit * this.Length;

        /// <summary>Gets the total wet dispalcement.</summary>
        /// <value>The total wet dispalcement.</value>
        [Ignore]
        public double TotalWetDispalcement => this.WetDisplacementPerUnit * this.Length;

        /// <summary>Gets the internal capacity per unit.</summary>
        /// <value>The internal capacity per unit.</value>
        [Ignore]
        public double InternalCapacityPerUnit => TubularMath.GetInternalCapacity(this.InsideDiameter);

        /// <summary>Gets the total internal capacity.</summary>
        /// <value>The total internal capacity.</value>
        [Ignore]
        public double TotalInternalCapacity => this.InternalCapacityPerUnit * this.Length;

        /// <summary>Compares this instance with a specified Object and indicates whether this instance
        /// precedes, follows, or appears in the same position in the sort order as the specified
        /// Object.</summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates whether this instance precedes,
        /// follows, or appears in the same position in the sort order as the value parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">Object is not IDrillstringTubular</exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is IDrillstringTubular otherTubular)
                return this.ItemSortOrder.CompareTo(otherTubular.ItemSortOrder);
            else
                throw new ArgumentException("Object is not IDrillstringTubular");
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            //Get unit from persistant storage
            //string smallLengthUnit = Preferences.Get("smallLengthUnit", "mm");

            //return this.InsideDiameter + smallLengthUnit + " ID " + this.ItemDescription;
#pragma warning disable CA1305 // Specify IFormatProvider
            return string.Format("{0} OD {1}", this.OutsideDiameter, this.ItemDescription);
#pragma warning restore CA1305 // Specify IFormatProvider
        }
    }
}
