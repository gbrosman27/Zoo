using Foods;

namespace Animals
{
    /// <summary>
    /// The class to represent an eat behavior.
    /// </summary>
    public interface IEatBehavior
    {
        /// <summary>
        /// The eat behavior.
        /// </summary>
        /// <param name="eater">The intended eater.</param>
        /// <param name="food">The intended food.</param>
        void Eat(IEater eater, Food food);
    }
}