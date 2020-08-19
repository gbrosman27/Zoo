namespace Animals
{
    /// <summary>
    /// The interface which is used to define the role of something that can be hatched.
    /// </summary>
    public interface IHatchable
    {
        /// <summary>
        /// Hatches from its egg.
        /// </summary>
        void Hatch();
    }
}