using System;
using Foods;
using Reproducers;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent a platypus.
    /// </summary>
    public sealed class Platypus : Mammal, IHatchable
    {
        /// <summary>
        /// Initializes a new instance of the Platypus class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// /// <param name="gender">The Platypus's gender.</param>
        public Platypus(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 12.0;

            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Swim);
            this.EatBehavior = EatBehaviorFactory.CreateEatBehavior(EatBehaviorType.ShowAffection);
            this.ReproduceBehavior = ReproduceBehaviorFactory.CreateReproduceBehavior(ReproduceBehaviorType.LayEggs);
        }

        /// <summary>
        /// The size of the animal appearance.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                // Determine if the animal should be a baby or an adult.
                double animalSize = (this.Age == 0) ? 0.8 : 1.1;

                return animalSize;
            }
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public override void Eat(Food food)
        {
            this.StashInPouch(food);

            base.Eat(food);
        }

        /// <summary>
        /// Hatches the animal.
        /// </summary>
        public void Hatch()
        {
            // The animal hatches from an egg.
        }

        /// <summary>
        /// Stashes food in its cheek pouches.
        /// </summary>
        /// <param name="food">The food to be stashed.</param>
        private void StashInPouch(Food food)
        {
            // Stash food to eat later.
        }
    }
}