using System.Collections.Generic;

namespace Utilities
{
    /// <summary>
    /// The class to represent the list utilities.
    /// </summary>
    public static class ListUtil
    {
        /// <summary>
        /// Flattens the list.
        /// </summary>
        /// <param name="list">The list to be flattened.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The string returned.</returns>
        public static string Flatten(IEnumerable<string> list, string separator)
        {
            string result = null;

            foreach (object s in list)
            {
                result += result == null ? s : separator + s;
            }

            return result;
        }
    }
}