namespace Animals
{
    /// <summary>
    /// The interface to represent a move behavior.
    /// </summary>
    public interface IMoveBehavior
    {
        /// <summary>
        /// The animal moves.
        /// </summary>
        /// <param name="animal">The intended animal.</param>
        void Move(Animal animal);
    }
}