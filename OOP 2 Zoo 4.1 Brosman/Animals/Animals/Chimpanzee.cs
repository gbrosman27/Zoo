using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class used to represent a chimpanzee.
    /// </summary>
    public class Chimpanzee : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Chimpanzee class.
        /// </summary>
        /// <param name="name">The name of the chimpanzee.</param>
        /// <param name="age">The age of the chimpanzee.</param>
        /// <param name="weight">The weight of the chimpanzee.</param>
        /// /// <param name="gender">The Chimpanzee's gender.</param>
        public Chimpanzee(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The weight of the baby chimpanzee.
            this.BabyWeightPercentage = 10.0;

            // this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Pace);
        }
    }
}