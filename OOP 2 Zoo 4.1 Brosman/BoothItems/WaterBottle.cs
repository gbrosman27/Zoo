using System;

namespace BoothItems
{
    [Serializable]

    /// <summary>
    /// The class to represent a WaterBottle.
    /// </summary>
    public class WaterBottle : SoldItem
    {
        /// <summary>
        /// The water bottle's serial number.
        /// </summary>
        private int serialNumber;

        /// <summary>
        /// Initializes a new instance of the WaterBottle class.
        /// </summary>
        /// <param name="price">The price of the water bottle.</param>
        /// <param name="serialNumber">The water bottle's serial number.</param>
        /// <param name="weight">The weight of the water bottle.</param>
        public WaterBottle(decimal price, int serialNumber, double weight)
            : base(price, weight)
        {
            this.serialNumber = serialNumber;
        }

        /// <summary>
        /// Gets the water bottle's serial number.
        /// </summary>
        public int SerialNumber
        {
            get
            {
                return this.serialNumber;
            }
        }
    }
}