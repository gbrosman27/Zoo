using System;
using System.Collections.Generic;
using Animals;
using CagedItems;

namespace Zoos
{
    [Serializable]

    /// <summary>
    /// The class to represent a cage.
    /// </summary>
    public class Cage
    {
        /// <summary>
        /// A list of items in the cage.
        /// </summary>
        private List<ICageable> cagedItems = new List<ICageable>();

        /// <summary>
        /// Initializes a new instance of the Cage class.
        /// </summary>
        /// <param name="height">The height of the cage.</param>
        /// <param name="width">The width of the cage.</param>        
        public Cage(int height, int width)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets the list of caged items.
        /// </summary>
        public IEnumerable<ICageable> CagedItems
        {
            get
            {
                return this.cagedItems;
            }
        }

        /// <summary>
        /// Gets the height of the cage.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the width of the cage.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Adds an animal to the cage.
        /// </summary>
        /// <param name="cagedItem">The item to be added to the cage.</param>
        public void Add(ICageable cagedItem)
        {
            this.cagedItems.Add(cagedItem);
        }

        /// <summary>
        /// Removes an animal from the cage.
        /// </summary>
        /// <param name="cagedItem">The item to be removed from the cage.</param>
        public void Remove(ICageable cagedItem)
        {
            this.cagedItems.Remove(cagedItem);
        }

        /// <summary>
        /// Show the contents of the cage.
        /// </summary>
        /// <returns>The cage details.</returns>
        public override string ToString()
        {
            // Cage dimensions.
            string result = $"{cagedItems[0].GetType().Name} cage ({Width} x {Height})";

            // Loop through the cage animals and add their info to the result string.
            foreach (Animal a in this.cagedItems)
            {
                result = result + $"{Environment.NewLine} {a.ToString()} ({ a.XPosition} x { a.YPosition})";
            }

            return result;
        }
    }
}