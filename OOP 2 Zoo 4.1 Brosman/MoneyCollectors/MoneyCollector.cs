using System;

namespace MoneyCollectors
{
    [Serializable]

    /// <summary>
    /// The class used to represent a money collector.
    /// </summary>
    public abstract class MoneyCollector : IMoneyCollector
    {
        /// <summary>
        /// The money balance of the money collector.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// Gets the money balance of the money collector.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Adds money to the money collector.
        /// </summary>
        /// <param name="amount">The amount of money to be added.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyBalance += amount;
        }

        /// <summary>
        /// Removes money from the money collector.
        /// </summary>
        /// <param name="amount">The amount of money to be removed.</param>
        /// <returns>The amount of the removed money.</returns>
        public virtual decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved;

            // If there is enough money in the wallet...
            if (this.moneyBalance >= amount)
            {
                // Return the requested amount.
                amountRemoved = amount;
            }
            else
            {
                // Otherwise return all the money that is left.
                amountRemoved = this.moneyBalance;
            }

            // Subtract the amount removed from the wallet's money balance.
            this.moneyBalance -= amountRemoved;

            return amountRemoved;
        }
    }
}