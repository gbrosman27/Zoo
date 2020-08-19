using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent an eagle.
    /// </summary>
    public class Eagle : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Eagle class.
        /// </summary>
        /// <param name="name">The name of the eagle.</param>
        /// <param name="age">The age of the eagle.</param>
        /// <param name="weight">The weight of the eagle.</param>
        /// /// <param name="gender">The Eagle's gender.</param>
        public Eagle(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The weight of the baby eagle.
            this.BabyWeightPercentage = 25.0;
        }
    }
}