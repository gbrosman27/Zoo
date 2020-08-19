namespace MoneyCollectors
{
    /// <summary>
    /// The interface used to represent a money collector.
    /// </summary>
    public interface IMoneyCollector
    {
        /// <summary>
        /// Gets the money balance.
        /// </summary>
        decimal MoneyBalance { get; }

        /// <summary>
        /// Adds money to the money collector.
        /// </summary>
        /// <param name="amount">The amount of money to add.</param>
        void AddMoney(decimal amount);

        /// <summary>
        /// Removes money from the money collector.
        /// </summary>
        /// <param name="amount">The amount of money to be removed.</param>
        /// <returns>Returns the removed amount of money.</returns>
        decimal RemoveMoney(decimal amount);
    }
}