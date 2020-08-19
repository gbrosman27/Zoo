﻿using System;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent a mammal.
    /// </summary>
    public abstract class Mammal : Animal
    {
        /// <summary>
        /// Initializes a new instance of the Mammal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// /// <param name="gender">The Mammal's gender.</param>
        public Mammal(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Pace);
            this.EatBehavior = EatBehaviorFactory.CreateEatBehavior(EatBehaviorType.Consume);
            this.ReproduceBehavior = ReproduceBehaviorFactory.CreateReproduceBehavior(ReproduceBehaviorType.GiveBirth);
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        public override double WeightGainPercentage
        {
            get
            {
                return 15.0;
            }
        }
    }
}