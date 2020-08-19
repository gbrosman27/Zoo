using Animals.MoveBehaviors;

namespace Animals
{
    /// <summary>
    /// The class to represent a move behavior factory.
    /// </summary>
    public static class MoveBehaviorFactory
    {
        /// <summary>
        /// Creates the animal's move behavior.
        /// </summary>
        /// <param name="type">The type of animal.</param>
        /// <returns>Returns the intended movement behavior.</returns>
        public static IMoveBehavior CreateMoveBehavior(MoveBehaviorType type)
        {
            IMoveBehavior animalMove = null;

            switch (type)
            {
                case MoveBehaviorType.Fly:
                    animalMove = new FlyBehavior();
                    break;

                case MoveBehaviorType.Pace:
                    animalMove = new PaceBehavior();
                    break;

                case MoveBehaviorType.Swim:
                    animalMove = new SwimBehavior();
                    break;

                case MoveBehaviorType.Climb:
                    animalMove = new ClimbBehavior();
                    break;

                case MoveBehaviorType.Hover:
                    animalMove = new HoverBehavior();
                    break;

                case MoveBehaviorType.NoMove:
                    animalMove = new NoMoveBehavior();
                    break;
            }

            return animalMove;
        }
    }
}