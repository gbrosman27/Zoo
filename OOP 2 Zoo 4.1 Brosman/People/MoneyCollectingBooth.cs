using System;
using System.Collections.Generic;
using BoothItems;
using MoneyCollectors;

namespace People
{
    [Serializable]

    /// <summary>
    /// The class used to represent a money collecting booth.
    /// </summary>
    public class MoneyCollectingBooth : Booth
    {
        /// <summary>
        /// The money box to house the money.
        /// </summary>
        private IMoneyCollector moneyBox;

        /// <summary>
        /// The price of the ticket.
        /// </summary>
        private decimal ticketPrice;

        /// <summary>
        /// The price of the water bottle.
        /// </summary>
        private decimal waterBottlePrice;

        /// <summary>
        /// A stack of tickets.
        /// </summary>
        private Stack<Ticket> ticketStack;

        /// <summary>
        /// Initializes a new instance of the MoneyCollectingBooth class.
        /// </summary>
        /// <param name="attendant">The booth's attendant.</param>
        /// <param name="ticketPrice">The price of the ticket.</param>
        /// <param name="waterBottlePrice">The price of the water bottle.</param>
        /// <param name="moneyBox">The money box used to house money.</param>
        public MoneyCollectingBooth(Employee attendant, decimal ticketPrice, decimal waterBottlePrice, IMoneyCollector moneyBox)
            : base(attendant)
        {
            this.ticketPrice = ticketPrice;
            this.waterBottlePrice = waterBottlePrice;
            this.moneyBox = moneyBox;
            //// this.moneyBox.AddMoney(42.75m);
            
            // Instantiates a new ticket stack.
            this.ticketStack = new Stack<Ticket>();

            // Create tickets with unique serial numbers and add them to the list.
            for (int i = 0; i < 5; i++)
            {
                Ticket ticket = new Ticket(15.00m, i, .01);
                i = ticket.SerialNumber;
                ////this.Items.Add(ticket);
                this.ticketStack.Push(ticket);
            }

            // Create water bottles with unique serial numbers and add them to the list.
            for (int i = 0; i < 5; i++)
            {
                WaterBottle waterBottle = new WaterBottle(this.WaterBottlePrice, i, 1);
                i = waterBottle.SerialNumber;
                this.Items.Add(waterBottle);
            }
        }

        /// <summary>
        /// Gets the money balance in the money box.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBox.MoneyBalance;
            }
        }

        /// <summary>
        /// Gets the ticket price.
        /// </summary>
        public decimal TicketPrice
        {
            get
            {
                return this.ticketPrice;
            }
        }

        /// <summary>
        /// Gets the price of the water bottle.
        /// </summary>
        public decimal WaterBottlePrice
        {
            get
            {
                return this.waterBottlePrice;
            }
        }

        /// <summary>
        /// Add money to the money box.
        /// </summary>
        /// <param name="amount">The amount to be added to the money box.</param>
        public void AddMoney(decimal amount)
        {
            // this.moneyBox.AddMoney(amount);
            this.moneyBox.AddMoney(amount);
        }

        /// <summary>
        /// The amount to be removed from the money box.
        /// </summary>
        /// <param name="amount">The amount to be removed.</param>
        /// <returns>The amount that was removed from the money box.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved = this.moneyBox.RemoveMoney(amount);

            return amountRemoved;
        }

        /// <summary>
        /// Sells a ticket to the guest.
        /// </summary>
        /// <param name="payment">The payment for the ticket.</param>
        /// <returns>Returns a ticket.</returns>
        public Ticket SellTicket(decimal payment)
        {
            Item item = null;

            try
            {
                if (payment == this.TicketPrice)
                {
                    // item = Attendant.FindItem(this.Items, typeof(Ticket));
                    item = this.ticketStack.Pop();
                    
                    if (item != null)
                    {
                        this.AddMoney(payment);
                    }
                }
            }
            catch (Exception)
            {
                throw new MissingItemException("Ticket not found.");
            }

            return item as Ticket;
        }

        /// <summary>
        /// Sells the guest a water bottle.
        /// </summary>
        /// <param name="payment">The payment for the water bottle.</param>
        /// <returns>Returns a water bottle.</returns>
        public WaterBottle SellWaterBottle(decimal payment)
        {
            Item item = null;

            try
            {
                if (payment == this.WaterBottlePrice)
                {
                    item = Attendant.FindItem(this.Items, typeof(WaterBottle));

                    if (item != null)
                    {
                        this.AddMoney(payment);
                    }
                }
            }
            catch (Exception)
            {
                throw new MissingItemException("Waterbottle not found.");
            }

            return item as WaterBottle;
        }
    }
}