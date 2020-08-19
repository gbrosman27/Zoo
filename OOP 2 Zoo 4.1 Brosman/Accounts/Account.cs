using System;
using MoneyCollectors;

namespace Accounts
{
    [Serializable]

    /// <summary>
    /// The class used to represent an account.
    /// </summary>
    public class Account : IMoneyCollector
    {
        /// <summary>
        /// The money balance of the account.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// Gets the account's money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Adds money to the account.
        /// </summary>
        /// <param name="amount">The amount to add to the account.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyBalance += amount;
        }

        /// <summary>
        /// Removes money from the account.
        /// </summary>
        /// <param name="amount">The amount of money to be removed from the account.</param>
        /// <returns>Returns the amount removed from the account.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            // Currently allows money balance to go negative.
            this.moneyBalance -= amount;

            return amount;
        }
    }
}