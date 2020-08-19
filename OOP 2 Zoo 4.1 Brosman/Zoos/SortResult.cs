using System;
using System.Collections.Generic;
using Animals;

namespace Zoos
{
    [Serializable]

    /// <summary>
    /// The class used to represent the sort results.
    /// </summary>
    public class SortResult
    {
        /// <summary>
        /// Gets or sets the animals in the list.
        /// </summary>
        public List<Animal> Animals { get; set; }

        /// <summary>
        /// Gets or sets the count of the sorts.
        /// </summary>
        public int CompareCount { get; set; }

        /// <summary>
        /// Gets or sets the elapsed milliseconds it takes to complete a sort.
        /// </summary>
        public double ElapsedMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the swap count after sorting.
        /// </summary>
        public int SwapCount { get; set; }
    }
}