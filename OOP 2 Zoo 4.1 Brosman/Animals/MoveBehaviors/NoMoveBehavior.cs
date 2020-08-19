using System;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent an animal standing still.
    /// </summary>
    public class NoMoveBehavior : IMoveBehavior
    {
        /// <summary>
        /// The animal moves.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        public void Move(Animal animal)
        {
            // The animal is standing still.
        }
    }
}