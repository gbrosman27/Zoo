﻿using System;

namespace BoothItems
{
    [Serializable]

    /// <summary>
    /// The class used to represent an item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// The weight of the item.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="weight">The weight of the item.</param>
        public Item(double weight)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Gets the weight of the item.
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }
    }
}