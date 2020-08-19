using System;
using Foods;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent an ostrich.
    /// </summary>
    public sealed class Ostrich : Bird, IEater
    {
        /// <summary>
        /// Initializes a new instance of the Ostrich class.
        /// </summary>
        /// <param name="name">The name of the ostrich.</param>
        /// <param name="age">The age of the ostrich.</param>
        /// <param name="weight">The weight of the ostrich.</param>
        /// /// <param name="gender">The Ostrich's gender.</param>
        public Ostrich(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The weight of the baby ostrich.
            this.BabyWeightPercentage = 30.0;

            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Pace);
        }

        /// <summary>
        /// The size of the animal appearance.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                // Determine if the animal should be a baby or an adult.
                double animalSize = (this.Age == 0) ? 0.4 : 0.8;

                return animalSize;
            }
        }
    }
}