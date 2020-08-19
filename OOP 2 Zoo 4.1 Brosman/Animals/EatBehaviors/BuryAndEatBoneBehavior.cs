using System;
using Foods;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent burying a bone and eating a bone.
    /// </summary>
    public class BuryAndEatBoneBehavior : IEatBehavior
    {
        /// <summary>
        /// The animal eats.
        /// </summary>
        /// <param name="eater">The intended animal.</param>
        /// <param name="food">The animal's food.</param>
        public void Eat(IEater eater, Food food)
        {
            this.BuryBone(food);
            this.DigUpAndEatBone();

            // Increase animal's weight as a result of eating food.
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);

            this.Bark();
        }

        /// <summary>
        /// The animal barks.
        /// </summary>
        private void Bark()
        {
            // Bark in satisfaction after eating.
        }

        /// <summary>
        /// The animal buries the bone.
        /// </summary>
        /// <param name="bone">The bone to be buried.</param>
        private void BuryBone(Food bone)
        {
            // Bury the bone.
        }

        /// <summary>
        /// The animal digs up and eats the bone.
        /// </summary>
        private void DigUpAndEatBone()
        {
            // Dig up and eat the bone.
        }
    }
}