using System;

namespace MoneyCollectors
{
    [Serializable]

    /// <summary>
    /// The class used to represent a money box.
    /// </summary>
    public class MoneyBox : MoneyCollector
    {
        /// <summary>
        /// Removes money from the money box.
        /// </summary>
        /// <param name="amount">The amount of money to remove from the money box.</param>
        /// <returns>The amount removed.</returns>
        public override decimal RemoveMoney(decimal amount)
        {
            this.Unlock();

            decimal moneyRemoved = base.RemoveMoney(amount);

            this.Lock();

            return moneyRemoved;
        }

        /// <summary>
        /// Locks the money box.
        /// </summary>
        private void Lock()
        {
        }

        /// <summary>
        /// Unlocks the money box.
        /// </summary>
        private void Unlock()
        {
        }
    }
}