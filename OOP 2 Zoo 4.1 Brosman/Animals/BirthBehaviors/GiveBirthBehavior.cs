using System;
using Foods;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent a birthing behavior.
    /// </summary>
    public class GiveBirthBehavior : IReproduceBehavior
    {
        /// <summary>
        /// The animal reproduces by giving birth.
        /// </summary>
        /// <param name="animal">The animal to give birth.</param>
        /// <returns>The animal baby.</returns>
        public Animal Reproduce(Animal animal)
        {
            // Create a baby reproducer.
            Animal baby = Activator.CreateInstance(animal.GetType(), string.Empty, 0, animal.Weight * (animal.BabyWeightPercentage / 100), animal.Gender) as Animal;

            // If the animal is not a platypus and baby is an eater...
            if (animal.GetType() != typeof(Platypus) && baby is IEater)
            {
                // Feed the baby.
                this.FeedNewborn(baby as IEater);
            }

            // Reduce mother's weight by 25 percent more than the value of the baby's weight.
            animal.Weight -= baby.Weight * 1.25;

            return baby;
        }

        /// <summary>
        /// Feeds the newborn animal.
        /// </summary>
        /// <param name="eater">The animal that is eating.</param>
        private void FeedNewborn(IEater eater)
        {
            // Determine milk weight.
            double milkWeight = eater.Weight * 0.005;

            // Generate milk.
            Food milk = new Food(milkWeight);

            // Feed baby.
            eater.Eat(milk);

            // Reduce parent's weight.
            eater.Weight -= milkWeight;
        }
    }
}