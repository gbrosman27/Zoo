using System;
using Foods;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent showing affection.
    /// </summary>
    public class ShowAffectionBehavior : IEatBehavior
    {
        /// <summary>
        /// The animal eats.
        /// </summary>
        /// <param name="eater">The intended animal.</param>
        /// <param name="food">The animal's food.</param>
        public void Eat(IEater eater, Food food)
        {
            // Increase animal's weight as a result of eating food.
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);

            this.ShowAffection();
        }

        /// <summary>
        /// The animal shows affection.
        /// </summary>
        private void ShowAffection()
        {
            // Shows affection after eating.
        }
    }
}