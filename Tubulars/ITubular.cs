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
//      Base interface common to all tubulars in the well including wellbore tublars and drillstring tubulars
// </summary>
// ********************************************************************************************************************

namespace Tubulars
{
    /// <summary>
    /// ITubularBase is common to all tubular items
    /// </summary>
    public interface ITubular
    {
        /// <summary>
        /// Gets or sets the item identifier.</summary>
        /// <value>The item identifier.</value>
        int ItemID { get; set; }


        /// <summary>
        /// Gets or sets the item sort order.</summary>
        /// <value>The item sort order.</value>
        int ItemSortOrder { get; set; }

        /// <summary>Gets or sets the item description.</summary>
        /// <value>The item description.</value>
        string ItemDescription { get; }

        /// <summary>Gets the length.</summary>
        /// <value>The length.</value>
        double Length { get; }

        /// <summary>Gets or sets the inside diameter.</summary>
        /// <value>The inside diameter.</value>
        double InsideDiameter { get; set; }

        /// <summary>Gets the internal capacity per unit.</summary>
        /// <value>The internal capacity per unit.</value>
        double InternalCapacityPerUnit { get; }

        /// <summary>Gets the total internal capacity.</summary>
        /// <value>The total internal capacity.</value>
        double TotalInternalCapacity { get; }

        /// <summary>
        /// Compares this instance with a specified Object and indicates whether this instance
        /// precedes, follows, or appears in the same position in the sort order as the specified
        /// Object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// int32
        /// A 32-bit signed integer that indicates whether this instance precedes,
        /// follows, or appears in the same position in the sort order as the value parameter.
        /// </returns>
        int CompareTo(object obj);

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        string ToString();

    }
}