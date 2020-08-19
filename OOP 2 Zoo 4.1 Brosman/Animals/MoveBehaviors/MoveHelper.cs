using Utilities;

namespace Animals
{
    /// <summary>
    /// The class to represent movements.
    /// </summary>
    public static class MoveHelper
    {
        /// <summary>
        /// Move horizontally.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        /// <param name="moveDistance">The distance the animal should move.</param>
        public static void MoveHorizontally(Animal animal, int moveDistance)
        {
            // If the animal is wanting to move to the right...
            if (animal.XDirection == HorizontalDirection.Right)
            {
                // If the current position and the desire to move a specified distance is farther than the max distance allowed...
                if (animal.XPosition + moveDistance > animal.XPositionMax)
                {
                    // The animal moves to the max distance, then turns to the left.
                    animal.XPosition = animal.XPositionMax;
                    animal.XDirection = HorizontalDirection.Left;
                }
                else
                {
                    // If the animal does not want to move the max distance or farther, proceed to move that distance.
                    animal.XPosition += moveDistance;
                }
            }
            else
            {
                // If animal moves too far left...
                if (animal.XPosition - moveDistance < 0)
                {
                    // The animal's current position at left most point.
                    animal.XPosition = 0;

                    // Changes the animal moving left to moving right.
                    animal.XDirection = HorizontalDirection.Right;
                }
                else
                {
                    // If the animal does not want to move the max distance or farther, proceed to move that distance to the left.
                    animal.XPosition -= moveDistance;
                }
            }
        }

        /// <summary>
        /// Move vertically.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        /// <param name="moveDistance">The distance the animal should move.</param>
        public static void MoveVertically(Animal animal, int moveDistance)
        {
            if (animal.YDirection == VerticalDirection.Up)
            {
                if (animal.YPosition + moveDistance > animal.YPositionMax)
                {
                    animal.YPosition = animal.YPositionMax;
                    animal.YDirection = VerticalDirection.Down;
                }
                else if (animal.YPosition + moveDistance < animal.YPositionMax)
                {
                    animal.YPosition += moveDistance;
                    animal.YDirection = VerticalDirection.Up;
                }
                else if (animal.YPosition + moveDistance > animal.YPositionMax)
                {
                    animal.YPosition = animal.YPositionMax;
                    animal.YDirection = VerticalDirection.Down;
                }
                else
                {
                    // If the animal does not want to move the max distance or farther, proceed to move that distance.
                    animal.YPosition += moveDistance;
                }
            }
            else if (animal.YDirection == VerticalDirection.Down)
            {
                if (animal.YPosition - moveDistance < 0)
                {
                    animal.YPosition = 0;
                    animal.YDirection = VerticalDirection.Up;
                }
                else if (animal.YPosition - moveDistance > 0)
                {
                    animal.YPosition -= moveDistance;
                    animal.YDirection = VerticalDirection.Down;
                }
                else if (animal.YPosition - moveDistance < 0)
                {
                    animal.YPosition = 0;
                    animal.YDirection = VerticalDirection.Up;
                }
                else
                {
                    // If the animal does not want to move the max distance or farther, proceed to move that distance.
                    animal.YPosition -= moveDistance;
                }
            }
            else if (animal.YDirection == VerticalDirection.Up)
            {
                if (animal.YPosition + moveDistance > animal.YPositionMax)
                {
                    animal.YPosition = animal.YPositionMax;
                    animal.YDirection = VerticalDirection.Down;
                }
                else if (animal.YPosition + moveDistance > animal.YPositionMax)
                {
                    animal.YPosition = animal.YPositionMax;
                    animal.YDirection = VerticalDirection.Down;
                }
                else if (animal.YPosition + moveDistance < animal.YPositionMax)
                {
                    animal.YPosition += moveDistance;
                    animal.YDirection = VerticalDirection.Up;
                }
                else
                {
                    // If the animal does not want to move the max distance or farther, proceed to move that distance.
                    animal.YPosition += moveDistance;
                }
            }
            else
            {
                if (animal.YPosition - moveDistance < 0)
                {
                    animal.YPosition = 0;
                    animal.YDirection = VerticalDirection.Up;
                }
                else if (animal.YPosition - moveDistance > 0)
                {
                    animal.YPosition -= moveDistance;
                    animal.YDirection = VerticalDirection.Down;
                }
                else if (animal.YPosition - moveDistance < 0)
                {
                    animal.YPosition = 0;
                    animal.YDirection = VerticalDirection.Up;
                }
                else
                {
                    // If the animal does not want to move the max distance or farther, proceed to move that distance.
                    animal.YPosition -= moveDistance;
                }
            }
        }
    }
}