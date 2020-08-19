using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class used to represent a shark.
    /// </summary>
    public class Shark : Fish
    {
        /// <summary>
        /// Initializes a new instance of the Shark class.
        /// </summary>
        /// <param name="name">The name of the shark.</param>
        /// <param name="age">The age of the shark.</param>
        /// <param name="weight">The weight of the shark.</param>
        /// /// <param name="gender">The Shark's gender.</param>
        public Shark(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The weight of the baby shark.
            this.BabyWeightPercentage = 18.0;
        }

        /// <summary>
        /// The size of the animal appearance.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                // Determine if the animal should be a baby or an adult.
                double animalSize = (this.Age == 0) ? 1.0 : 1.5;

                return animalSize;
            }
        }
    }
}