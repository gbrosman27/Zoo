using System;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent the pace behavior.
    /// </summary>
    public class PaceBehavior : IMoveBehavior
    {
        /// <summary>
        /// The animal moves by pacing.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        public void Move(Animal animal)
        {
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);
        }
    }
}