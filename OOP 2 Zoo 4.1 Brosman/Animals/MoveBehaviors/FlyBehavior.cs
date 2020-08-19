using System;
using Utilities;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class to represent a fly behavior.
    /// </summary>
    public class FlyBehavior : IMoveBehavior
    {
        /// <summary>
        /// The animal moves by flying.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        public void Move(Animal animal)
        {
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

            // If the animal is currently moving down.
            if (animal.YDirection == VerticalDirection.Down)
            {
                // Move down by 10 and switch directions.
                animal.YPosition += 10;
                animal.YDirection = VerticalDirection.Up;
            }
            else
            {
                // Move up by 10 and switch directions.
                animal.YPosition -= 10;
                animal.YDirection = VerticalDirection.Down;
            }
        }
    }
}