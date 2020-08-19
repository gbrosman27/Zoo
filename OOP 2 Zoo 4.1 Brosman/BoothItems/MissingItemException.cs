using System;

namespace BoothItems
{
    /// <summary>
    /// The class to represent a missing item exception.
    /// </summary>
    public class MissingItemException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MissingItemException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public MissingItemException(string message)
            : base(message)
        {
        }
    }
}