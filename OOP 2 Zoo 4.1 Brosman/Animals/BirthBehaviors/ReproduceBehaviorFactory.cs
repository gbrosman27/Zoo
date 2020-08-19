namespace Animals
{
    /// <summary>
    /// The class to represent the reproduce behavior factory.
    /// </summary>
    public static class ReproduceBehaviorFactory
    {
        /// <summary>
        /// Creates a reproduction behavior.
        /// </summary>
        /// <param name="type">The type of reproduction of the intended animal.</param>
        /// <returns>Returns the selected reproduction method.</returns>
        public static IReproduceBehavior CreateReproduceBehavior(ReproduceBehaviorType type)
        {
            IReproduceBehavior reproduceBehavior = null;

            switch (type)
            {
                case ReproduceBehaviorType.GiveBirth:
                    reproduceBehavior = new GiveBirthBehavior();
                    break;

                case ReproduceBehaviorType.LayEggs:
                    reproduceBehavior = new LayEggBehavior();
                    break;
            }

            return reproduceBehavior;
        }
    }
}