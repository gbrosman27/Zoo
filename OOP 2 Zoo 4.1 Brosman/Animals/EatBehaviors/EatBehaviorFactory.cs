namespace Animals
{
    /// <summary>
    /// The class to represent the eat behavior factory.
    /// </summary>
    public static class EatBehaviorFactory
    {
        /// <summary>
        /// Creates the eat behavior.
        /// </summary>
        /// <param name="type">The type of eat behavior the animal should perform.</param>
        /// <returns>Return the type of eat behavior.</returns>
        public static IEatBehavior CreateEatBehavior(EatBehaviorType type)
        {
            IEatBehavior eatBehavior = null;

            switch (type)
            {
                case EatBehaviorType.Consume:
                    eatBehavior = new ConsumeBehavior();
                    break;

                case EatBehaviorType.BuryAndEatBone:
                    eatBehavior = new BuryAndEatBoneBehavior();
                    break;

                case EatBehaviorType.ShowAffection:
                    eatBehavior = new ShowAffectionBehavior();
                    break;
            }

            return eatBehavior;
        }
    }
}