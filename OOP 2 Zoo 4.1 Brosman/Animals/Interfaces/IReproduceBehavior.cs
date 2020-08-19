using Reproducers;

namespace Animals
{
    /// <summary>
    /// The interface to represent a reproduction behavior.
    /// </summary>
    public interface IReproduceBehavior
    {
        /// <summary>
        /// The animal reproduces.
        /// </summary>
        /// <param name="animal">The animal to reproduce.</param>
        /// <returns>Returns the animal.</returns>
        Animal Reproduce(Animal animal);
    }
}