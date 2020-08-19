using System;

namespace MoneyCollectors
{
    [Serializable]

    /// <summary>
    /// The class used to represent a money pocket.
    /// </summary>
    public class MoneyPocket : MoneyCollector
    {
        /// <summary>
        /// Removes money from the money pocket.
        /// </summary>
        /// <param name="amount">The amount of money to remove.</param>
        /// <returns>The amount of money removed.</returns>
        public override decimal RemoveMoney(decimal amount)
        {
            this.Unfold();

            decimal moneyRemoved = base.RemoveMoney(amount);

            this.Fold();

            return moneyRemoved;
        }

        /// <summary>
        /// Fold the money pocket.
        /// </summary>
        private void Fold()
        {
        }

        /// <summary>
        /// Unfold the money pocket.
        /// </summary>
        private void Unfold()
        {
        }
    }
}