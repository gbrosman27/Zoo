using System;
using Utilities;

namespace Animals.MoveBehaviors
{
    [Serializable]

    /// <summary>
    /// The class used to represent the climb behavior.
    /// </summary>
    public class ClimbBehavior : IMoveBehavior
    {
        /// <summary>
        /// A random number.
        /// </summary>
        private static Random random;

        /// <summary>
        /// The max height to climb.
        /// </summary>
        private int maxHeight;

        /// <summary>
        /// The enum of the climb process.
        /// </summary>
        private ClimbProcess process;

        /// <summary>
        /// The animal moves.
        /// </summary>
        /// <param name="animal">The animal to move.</param>
        public void Move(Animal animal)
        {
            Random random = new Random();
            
            this.NextProcess(animal);                  
                                 
            switch (this.process)
            {
                case ClimbProcess.Climbing:
                    
                    // ensure animal is moving up
                    animal.YDirection = VerticalDirection.Up;

                    // move vertically
                    MoveHelper.MoveVertically(animal, animal.MoveDistance);

                    // if the animal's next step will take it above the max height
                    if (animal.MoveDistance > this.maxHeight)
                    {
                        // make animal move down
                        animal.YDirection = VerticalDirection.Down;
                        
                        MoveHelper.MoveVertically(animal, animal.MoveDistance);

                        ///// switch its horizontal direction (if moving right, make it move left and vice versa)
                        if (animal.XDirection == HorizontalDirection.Right)
                        {
                            animal.XDirection = HorizontalDirection.Left;
                            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);
                        }
                        else
                        {
                            animal.XDirection = HorizontalDirection.Right;
                            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);
                        }

                        // switch to next process
                        this.NextProcess(animal);
                    }

                    break;

                case ClimbProcess.Falling:

                    // move horizontally.
                    MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

                    // move vertically at twice the distance
                    MoveHelper.MoveVertically(animal, animal.MoveDistance * 2);

                    // if the animal's next move will take it past the bottom, switch to the next process
                    if (animal.YPosition - animal.MoveDistance < 0)
                    {
                        this.NextProcess(animal);
                    }

                    break;

                case ClimbProcess.Scurrying:

                    // move horizontally
                    MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

                    // if the animal will hit a vertical wall (either right or left)
                    if (animal.XPosition + animal.MoveDistance > animal.XPositionMax)
                    {
                        // set the animal to the edge and switch to the next process
                        animal.XPosition = animal.XPositionMax;
                        this.NextProcess(animal);
                    }
                    else if (animal.XPosition - animal.MoveDistance < 0)
                    {
                        animal.XPosition = 0;
                        this.NextProcess(animal);
                    }                  

                    break;                    
            }                 
        }

        /// <summary>
        /// The next process for movement.
        /// </summary>
        /// <param name="animal">The animal moving.</param>
        private void NextProcess(Animal animal)
        {
            random = new Random();

            //// if the current process is climbing, switch to falling.
            if (this.process == ClimbProcess.Climbing)
            {
                this.process = ClimbProcess.Falling;
            }                        
            else if (this.process == ClimbProcess.Falling)
            {
                this.process = ClimbProcess.Scurrying;
            }            
            else if (this.process == ClimbProcess.Scurrying)
            {                
                int lowerMax = Convert.ToInt32(Math.Floor(Convert.ToDouble(animal.YPositionMax) * 0.15));
                int higherMax = Convert.ToInt32(Math.Floor(Convert.ToDouble(animal.YPositionMax) * 0.85));

                //// set max height to a random value between the lowest max and the highest max
                this.maxHeight = random.Next(lowerMax, higherMax);

                //// switch to climbing
                this.process = ClimbProcess.Climbing;
            }            
        }
    }
}