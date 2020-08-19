using System;
using Foods;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent the consume behavior.
    /// </summary>
    public class ConsumeBehavior : IEatBehavior
    {
        /// <summary>
        /// The animal eats and weight gain is set.
        /// </summary>
        /// <param name="eater">The intended animal.</param>
        /// <param name="food">The animal's food.</param>
        public void Eat(IEater eater, Food food)
        {
            // Increase animal's weight as a result of eating food.
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);
        }
    }
}