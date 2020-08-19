using System;

namespace BoothItems
{
    [Serializable]

    /// <summary>
    /// The class used to represent a sold item.
    /// </summary>
    public abstract class SoldItem : Item
    {
        /// <summary>
        /// The price of the sold item.
        /// </summary>
        private decimal price;

        /// <summary>
        /// Initializes a new instance of the SoldItem class.
        /// </summary>
        /// <param name="price">The price of the sold item.</param>
        /// <param name="weight">The weight of the sold item.</param>
        public SoldItem(decimal price, double weight)
            : base(weight)
        {
            this.price = price;
        }

        /// <summary>
        /// Gets the price of the sold item.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }
        }
    }
}