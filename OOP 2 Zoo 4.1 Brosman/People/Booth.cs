using BoothItems;
using System;
using System.Collections.Generic;

namespace People
{
    [Serializable]
    /// <summary>
    /// The class which is used to represent a booth.
    /// </summary>
    public abstract class Booth
    {
        /// <summary>
        /// The employee currently assigned to be the attendant of the booth.
        /// </summary>
        private Employee attendant;

        /// <summary>
        /// A list of items.
        /// </summary>
        private List<Item> items;

        /// <summary>
        /// Initializes a new instance of the Booth class.
        /// </summary>
        /// <param name="attendant">The employee to be the booth's attendant.</param>
        public Booth(Employee attendant)
        {
            // Set field values via parameters.
            this.attendant = attendant;

            // Create couponbooks and add them to the list
            this.items = new List<Item>();
        }

        /// <summary>
        /// Gets the employee of the booth.
        /// </summary>
        protected Employee Attendant
        {
            get
            {
                return this.attendant;
            }
        }

        /// <summary>
        /// Gets the list of items.
        /// </summary>
        protected List<Item> Items
        {
            get
            {
                return this.items;
            }
        }
    }
}