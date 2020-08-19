using System;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent a swim behavior.
    /// </summary>
    public class SwimBehavior : IMoveBehavior
    {
        /// <summary>
        /// The animal moves by swimming.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        public void Move(Animal animal)
        {
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);
            MoveHelper.MoveVertically(animal, animal.MoveDistance / 2);
        }
    }
}