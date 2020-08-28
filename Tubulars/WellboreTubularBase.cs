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
//      Base class common to all wellbore tubulars in the well. Casing and open hole are both
//      concidered wellbore tubulars
// </summary>
// ********************************************************************************************************************
using System;
using SQLite;
namespace Tubulars
{
    [Table("Wellbore")]
    public abstract class WellboreTubularBase : IWellboreTubular
    {
        /// <summary>Gets or sets the item identifier.</summary>
        /// <value>The item identifier is used my the sqlite database for unique ID</value>
        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }

        /// <summary>Gets or sets the item sort order.</summary>
        /// <value>The item sort order.</value>
        public int ItemSortOrder { get; set; }

        /// <summary>Gets or sets the item description.</summary>
        /// <value>The item description.</value>
        public abstract string ItemDescription { get; }

        /// <summary>Gets or sets the start depth.</summary>
        /// <value>The start depth.</value>
        public double StartDepth { get; set; }

        /// <summary>Gets or sets the end depth.</summary>
        /// <value>The end depth.</value>
        public double EndDepth { get; set; }

        /// <summary>Gets or sets the inside diameter.</summary>
        /// <value>The inside diameter.</value>
        public double InsideDiameter { get; set; }

        /// <summary>Gets or sets the washout factor. Washout only affects open hole sections of the wellbore.</summary>
        /// <value>The washout factor. Integer from 0 to 100</value>
        public abstract int WashoutFactor { get; set; }

        /// <summary>Gets the length of the tubular section.</summary>
        /// <value>The length.</value>
        [Ignore]
        public double Length => this.EndDepth - this.StartDepth;
        
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
        /// <exception cref="System.ArgumentException">Object is not IWellboreTubular</exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;


            if (obj is IWellboreTubular otherTubular)
                return this.ItemSortOrder.CompareTo(otherTubular.ItemSortOrder);
            else
                throw new ArgumentException("Object is not IWellboreTubular");
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            //Get unit from persistant storage
            //string smallLengthUnit = Preferences.Get("smallLengthUnit", "mm");

            //return this.InsideDiameter + smallLengthUnit + " ID " + this.ItemDescription;
            return string.Format("{0} ID {1}", this.InsideDiameter, this.ItemDescription);
        }
    }
}
