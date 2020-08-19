using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent laying an egg.
    /// </summary>
    public class LayEggBehavior : IReproduceBehavior
    {
        /// <summary>
        /// The animal reproduces by laying an egg.
        /// </summary>
        /// <param name="animal">The animal to lay an egg.</param>
        /// <returns>The animal baby.</returns>
        public Animal Reproduce(Animal animal)
        {
            // Lay an egg.
            Animal baby = this.LayEgg(animal) as Animal;

            // If the baby is hatchable...
            if (baby is IHatchable)
            {
                // Hatch the baby out of its egg.
                this.HatchEgg(baby as IHatchable);                
            }

            return baby;
        }
        
        /// <summary>
        /// Hatches an egg.
        /// </summary>
        /// <param name="egg">The egg to hatch.</param>
        private void HatchEgg(IHatchable egg)
        {
            // Hatch the egg.
            egg.Hatch();
        }

        /// <summary>
        /// Lays an egg.
        /// </summary>
        /// <param name="animal">The animal to lay an egg.</param>
        /// <returns>The resulting egg.</returns>
        private IReproducer LayEgg(Animal animal)
        {            
            IReproducer animalEgg = null;              
                
            // Create a baby reproducer.
            animalEgg = Activator.CreateInstance(animal.GetType(), string.Empty, 0, animal.Weight * (animal.BabyWeightPercentage / 100), animal.Gender) as Animal;
                
            // Return the baby (egg) from the base Reproduce method.
            return animalEgg;           
        }
    }
}