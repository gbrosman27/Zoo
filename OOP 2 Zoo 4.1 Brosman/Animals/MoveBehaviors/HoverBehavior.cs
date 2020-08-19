using System;
using Utilities;

namespace Animals.MoveBehaviors
{
    [Serializable]

    /// <summary>
    /// The class to represent the hover behavior.
    /// </summary>
    public class HoverBehavior : IMoveBehavior
    {
        /// <summary>
        /// The animal hovers in random directions.
        /// </summary>
        private static Random random;

        /// <summary>
        /// The hover behavior step count.
        /// </summary>
        private int stepCount;

        /// <summary>
        /// The process to make an animal hover.
        /// </summary>
        private HoverProcess process;

        /// <summary>
        /// The animal moves.
        /// </summary>
        /// <param name = "animal" > The animal to move.</param>
        public void Move(Animal animal)
        {
            Random random = new Random();            

            // if there are no more steps to take (step count is at 0), switch to the next process
            if (this.stepCount == 0)
            {
                this.NextProcess(animal);                
            }

            // decrement the step count
            this.stepCount--;

            // define a move distance variable
            int moveDistance = 0;

            switch (this.process)
            {
                case HoverProcess.Hovering:
                    // the animal moves at a normal pace, so set the move distance variable to the animal's move distance
                    moveDistance = animal.MoveDistance;

                    // the animal moves randomly on each step, so give the animal a random horizontal and vertical direction
                    animal.XDirection = random.Next(0, 2) == 0 ? HorizontalDirection.Right : HorizontalDirection.Left;
                    animal.YDirection = random.Next(0, 2) == 0 ? VerticalDirection.Up : VerticalDirection.Down;

                    break;

                case HoverProcess.Zooming:
                    moveDistance = animal.MoveDistance * 4;

                    break;
            }

            MoveHelper.MoveHorizontally(animal, moveDistance);
            MoveHelper.MoveVertically(animal, moveDistance);
        }

        /// <summary>
        /// The next process in the hover movement.
        /// </summary>
        /// <param name="animal">The animal hovering.</param>
        private void NextProcess(Animal animal)
        {
            random = new Random();

            // if the current process is hovering
            if (this.process == HoverProcess.Hovering)
            {
                // switch to zooming
                this.process = HoverProcess.Zooming;

                // set the step count to a random number between 5 and 8, inclusive
                this.stepCount = random.Next(5, 9);

                // set the animal's horizontal and vertical directions to a random direction
                animal.XDirection = random.Next(0, 2) == 0 ? HorizontalDirection.Right : HorizontalDirection.Left;
                animal.YDirection = random.Next(0, 2) == 0 ? VerticalDirection.Up : VerticalDirection.Down;
            }           
            else if (this.process == HoverProcess.Zooming)
            {
                this.process = HoverProcess.Hovering;

                // set the step count to a random number between 7 and 10, inclusive
                this.stepCount = random.Next(7, 11);
            }
        }
    }
}