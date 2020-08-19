using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class used to represent a squirrel.
    /// </summary>
    public class Squirrel : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Squirrel class.
        /// </summary>
        /// <param name="name">The name of the squirrel.</param>
        /// <param name="age">The age of the squirrel.</param>
        /// <param name="weight">The weight of the squirrel.</param>
        /// /// <param name="gender">The Squirrel's gender.</param>
        public Squirrel(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The weight of the baby squirrel.
            this.BabyWeightPercentage = 17.0;

            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Climb);
        }
    }
}