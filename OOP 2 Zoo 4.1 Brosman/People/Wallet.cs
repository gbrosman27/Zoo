using System;
using MoneyCollectors;

namespace People
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent a wallet.
    /// </summary>
    public class Wallet : IMoneyCollector
    {
        /// <summary>
        /// The color of the wallet.
        /// </summary>
        private WalletColor color;

        /// <summary>
        /// The implement to carry money.
        /// </summary>
        private IMoneyCollector moneyPocket;

        /// <summary>
        /// Initializes a new instance of the Wallet class.
        /// </summary>
        /// <param name="color">The color of the wallet.</param>
        public Wallet(WalletColor color)
        {
            this.color = color;

            // Creates a new money pocket for the wallet.
            this.moneyPocket = new MoneyPocket();
        }

        /// <summary>
        /// Gets the money balance in the money pocket.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyPocket.MoneyBalance;
            }
        }

        /// <summary>
        /// Add money to the money pocket.
        /// </summary>
        /// <param name="amount">The amount to be added to the money pocket.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyPocket.AddMoney(amount);
        }

        /// <summary>
        /// The amount to be removed from the money pocket.
        /// </summary>
        /// <param name="amount">The amount to be removed.</param>
        /// <returns>The amount that was removed from the money pocket.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved = this.moneyPocket.RemoveMoney(amount);

            return amountRemoved;
        }
    }
}