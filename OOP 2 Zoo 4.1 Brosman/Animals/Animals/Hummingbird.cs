using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent a hummingbird.
    /// </summary>
    public class Hummingbird : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Hummingbird class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// /// <param name="gender">The Hummingbird's gender.</param>
        public Hummingbird(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 17.5;

            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Hover);
        }

        /// <summary>
        /// The size of the animal appearance.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                // Determine if the animal should be a baby or an adult.
                double animalSize = (this.Age == 0) ? 0.4 : 0.6;

                return animalSize;
            }
        }
    }
}