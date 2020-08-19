using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class used to represent a fish.
    /// </summary>
    public abstract class Fish : Animal
    {
        /// <summary>
        /// Initializes a new instance of the Fish class.
        /// </summary>
        /// <param name="name">The name of the fish.</param>
        /// <param name="age">The age of the fish.</param>
        /// <param name="weight">The weight of the fish.</param>
        /// /// <param name="gender">The Fish's gender.</param>
        public Fish(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Swim);
            this.EatBehavior = EatBehaviorFactory.CreateEatBehavior(EatBehaviorType.Consume);
            this.ReproduceBehavior = ReproduceBehaviorFactory.CreateReproduceBehavior(ReproduceBehaviorType.LayEggs);
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        public override double WeightGainPercentage
        {
            get
            {
                return 5.0;
            }
        }
    }
}