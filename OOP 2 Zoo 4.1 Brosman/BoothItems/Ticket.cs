using System;

namespace BoothItems
{
    [Serializable]

    /// <summary>
    /// The class used to represent a Ticket.
    /// </summary>
    public class Ticket : SoldItem
    {
        /// <summary>
        /// Whether or not the ticket has been redeemed.
        /// </summary>
        private bool isRedeemed;

        /// <summary>
        /// The ticket's serial number.
        /// </summary>
        private int serialNumber;

        /// <summary>
        /// Initializes a new instance of the Ticket class.
        /// </summary>
        /// <param name="price">The price of the ticket.</param>
        /// <param name="serialNumber">The ticket's serial number.</param>
        /// <param name="weight">The weight of the ticket.</param>
        public Ticket(decimal price, int serialNumber, double weight)
            : base(price, weight)
        {
            this.serialNumber = serialNumber;
        }

        /// <summary>
        /// Gets a value indicating whether or not the ticket has been redeemed.
        /// </summary>
        public bool IsRedeemed
        {
            get
            {
                return this.isRedeemed;
            }
        }

        /// <summary>
        /// Gets the ticket's serial number.
        /// </summary>
        public int SerialNumber
        {
            get
            {
                return this.serialNumber;
            }
        }

        /// <summary>
        /// Redeem the ticket.
        /// </summary>
        public void Redeem()
        {
            this.isRedeemed = true;
        }
    }
}