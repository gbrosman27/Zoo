using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class used to represent a kangaroo.
    /// </summary>
    public class Kangaroo : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Kangaroo class.
        /// </summary>
        /// <param name="name">The kangaroo's name.</param>
        /// <param name="age">The kangaroo's age.</param>
        /// <param name="weight">The kangaroo's weight.</param>
        /// /// <param name="gender">The Kangaroo's gender.</param>
        public Kangaroo(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The weight of the baby kangaroo.
            this.BabyWeightPercentage = 13.0;
        }
    }
}