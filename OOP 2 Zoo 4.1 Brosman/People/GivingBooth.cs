using System;
using BoothItems;

namespace People
{
    [Serializable]

    /// <summary>
    /// The class used to represent a booth that gives informational products.
    /// </summary>
    public class GivingBooth : Booth
    {
        /// <summary>
        /// Initializes a new instance of the GivingBooth class.
        /// </summary>
        /// <param name="attendant">The booth's attendant.</param>
        public GivingBooth(Employee attendant)
            : base(attendant)
        {
            // Create time variables.
            DateTime dateMade = DateTime.Now;
            DateTime dateExpired = DateTime.Now.AddYears(1);

            for (int i = 0; i < 5; i++)
            {
                CouponBook couponBook = new CouponBook(dateMade, dateExpired, 0.8);
                this.Items.Add(couponBook);
            }

            // Create maps and add them to the list.
            for (int i = 0; i < 10; i++)
            {
                Map map = new Map(0.5, dateMade);
                this.Items.Add(map);
            }
        }

        /// <summary>
        /// Gives the guest a free coupon book.
        /// </summary>
        /// <returns>Returns a coupon book.</returns>
        public CouponBook GiveFreeCouponBook()
        {
            Item item = null;

            try
            {
                item = Attendant.FindItem(this.Items, typeof(CouponBook));
            }
            catch (Exception)
            {
                throw new MissingItemException("Couponbook not found.");
            }

            return item as CouponBook;
        }

        /// <summary>
        /// Gives the guest a free coupon book.
        /// </summary>
        /// <returns>Returns a map.</returns>
        public Map GiveFreeMap()
        {
            Item item = null;

            try
            {
                item = Attendant.FindItem(this.Items, typeof(Map));
            }
            catch (Exception)
            {
                throw new MissingItemException("Map not found.");
            }

            return item as Map;
        }
    }
}