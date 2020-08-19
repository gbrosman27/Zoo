using Utilities;

namespace CagedItems
{
    /// <summary>
    /// The interface to represent something that can be caged.
    /// </summary>
    public interface ICageable
    {
        /// <summary>
        /// Gets the animal's display size.
        /// </summary>
        double DisplaySize { get; }

        /// <summary>
        /// Gets the animal's resource key.
        /// </summary>
        string ResourceKey { get; }

        /// <summary>
        /// Gets the animal's horizontal movement direction.
        /// </summary>
        HorizontalDirection XDirection { get; }

        /// <summary>
        /// Gets the animal's horizontal position.
        /// </summary>
        int XPosition { get; }

        /// <summary>
        /// Gets the animal's vertical movement direction.
        /// </summary>
        VerticalDirection YDirection { get; }

        /// <summary>
        /// Gets the animal's vertical position.
        /// </summary>
        int YPosition { get; }
    }
}