using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Animals;
using BoothItems;
using CagedItems;
using Foods;
using MoneyCollectors;
using Reproducers;
using Utilities;
using VendingMachines;

namespace People
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent a guest.
    /// </summary>
    public class Guest : IEater, ICageable
    {
        /// <summary>
        /// The age of the guest.
        /// </summary>
        private int age;

        /// <summary>
        /// A list of items in the guest's bag.
        /// </summary>
        private List<Item> bag;

        /// <summary>
        /// The guest's checking account.
        /// </summary>
        private IMoneyCollector checkingAccount;

        /// <summary>
        /// The gender of the person.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// The name of the guest.
        /// </summary>
        private string name;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        private Wallet wallet;

        /// <summary>
        /// Initializes a new instance of the Guest class.
        /// </summary>
        /// <param name="name">The name of the guest.</param>
        /// <param name="age">The age of the guest.</param>
        /// <param name="moneyBalance">The initial amount of money to put into the guest's wallet.</param>
        /// <param name="walletColor">The color of the guest's wallet.</param>
        /// <param name="gender">The guest's gender.</param>
        /// <param name="checkingAccount">The guest's checking account.</param>
        public Guest(string name, int age, decimal moneyBalance, WalletColor walletColor, Gender gender, IMoneyCollector checkingAccount)
        {
            this.age = age;
            this.name = name;
            this.wallet = new Wallet(walletColor);
            this.wallet.AddMoney(moneyBalance);
            this.gender = gender;
            this.checkingAccount = checkingAccount;

            // Creates the bag of items.
            this.bag = new List<Item>();

            // Initialize positions.
            this.XDirection = 0;
            this.YPosition = 0;
        }

        /// <summary>
        /// Gets or sets the adopted animal.
        /// </summary>
        public Animal AdoptedAnimal { get; set; }

        /// <summary>
        /// Gets or sets the age of the guest.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value >= 0 && value <= 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age", "The age must be between 0 and 120.");
                }
            }
        }

        /// <summary>
        /// Gets the field values of the checking account.
        /// </summary>
        public IMoneyCollector CheckingAccount
        {
            get
            {
                return this.checkingAccount;
            }
        }

        /// <summary>
        /// Gets the guest's display size.
        /// </summary>
        public double DisplaySize
        {
            get
            {
                return 0.6;
            }
        }

        /// <summary>
        /// Gets or sets the guest's gender.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the guest.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name must only include letters.");
                }
            }
        }

        /// <summary>
        /// Gets the guest's resource key.
        /// </summary>
        public string ResourceKey
        {
            get
            {
                return "Guest";
            }
        }

        /// <summary>
        /// Gets the field values for the wallet.
        /// </summary>
        public Wallet Wallet
        {
            get
            {
                return this.wallet;
            }
        }

        /// <summary>
        /// Gets or sets the weight of the employee.
        /// </summary>
        public double Weight
        {
            get
            {
                // Confidential.
                return 0.0;
            }

            set
            {
                this.Weight = value;
            }
        }

        /// <summary>
        /// Gets the weight gain percentage.
        /// </summary>
        public double WeightGainPercentage
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the guest's horizontal movement direction.
        /// </summary>
        public HorizontalDirection XDirection { get; private set; }

        /// <summary>
        /// Gets the guest's horizontal position.
        /// </summary>
        public int XPosition { get; private set; }

        /// <summary>
        /// Gets the guest's vertical movement direction.
        /// </summary>
        public VerticalDirection YDirection { get; private set; }

        /// <summary>
        /// Gets the guest's vertical position.
        /// </summary>
        public int YPosition { get; private set; }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public void Eat(Food food)
        {
            // Eat the food.
        }

        /// <summary>
        /// Feeds the specified eater.
        /// </summary>
        /// <param name="eater">The eater to be fed.</param>
        /// <param name="animalSnackMachine">The animal snack machine from which to buy food.</param>
        public void FeedAnimal(IEater eater, VendingMachine animalSnackMachine)
        {
            // Find food price.
            decimal price = animalSnackMachine.DetermineFoodPrice(eater.Weight);

            if (this.wallet.MoneyBalance < price)
            {
                // Withdraw 10 times the price of the food.
                this.WithdrawMoney(price * 10);
            }

            // Get money from wallet.
            decimal payment = this.wallet.RemoveMoney(price);

            // Buy food.
            Food food = animalSnackMachine.BuyFood(payment);

            // Feed animal.
            eater.Eat(food);
        }

        /// <summary>
        /// Formats the guest console return.
        /// </summary>
        /// <returns>Returns a guest.</returns>
        public override string ToString()
        {
            if (this.AdoptedAnimal != null)
            {
                return string.Format($"{this.name}: {this.age} [${wallet.MoneyBalance} / ${checkingAccount.MoneyBalance}] {this.AdoptedAnimal.Name}");
            }
            else
            {
                return string.Format($"{this.name}: {this.age} [${wallet.MoneyBalance} / ${checkingAccount.MoneyBalance}]");
            }
        }

        /// <summary>
        /// The guest visits the information booth.
        /// </summary>
        /// <param name="informationBooth">The information booth to visit.</param>
        public void VisitInformationBooth(GivingBooth informationBooth)
        {
            // Get a free map and add it to the bag..
            Map map = informationBooth.GiveFreeMap();
            this.bag.Add(map);

            // Get a free coupon book and add it to the bag.
            CouponBook couponBook = informationBooth.GiveFreeCouponBook();
            this.bag.Add(couponBook);
        }

        /// <summary>
        /// The guest visits the ticket booth.
        /// </summary>
        /// <param name="ticketBooth">The ticket booth to visit.</param>
        /// <returns>The ticket booth.</returns>
        public Ticket VisitTicketBooth(MoneyCollectingBooth ticketBooth)
        {
            // Gets ticket price from property.
            decimal ticketPrice = ticketBooth.TicketPrice;

            // Withdraw twice the amount of the ticket price if necessary.
            if (this.wallet.MoneyBalance < ticketPrice)
            {
                this.WithdrawMoney(ticketPrice * 2);
            }

            // Removes money from wallet for ticket.
            decimal moneyForTicket = this.wallet.RemoveMoney(ticketPrice);

            // Sells the ticket.
            Ticket ticket = ticketBooth.SellTicket(moneyForTicket);

            // Gets price of water bottle.
            decimal priceWaterBottle = ticketBooth.WaterBottlePrice;

            // Withdraw twice the amount of the water bottle price if necessary.
            if (this.wallet.MoneyBalance < priceWaterBottle)
            {
                this.WithdrawMoney(priceWaterBottle * 2);
            }

            // Removes money for watter bottle.
            decimal moneyForWaterBottle = this.wallet.RemoveMoney(priceWaterBottle);

            // Sells the guest a water bottle and adds it to the items list..
            WaterBottle waterBottle = ticketBooth.SellWaterBottle(moneyForWaterBottle);
            this.bag.Add(waterBottle);

            return ticket;
        }

        /// <summary>
        /// The guest withdraws money from the account.
        /// </summary>
        /// <param name="amount">The amount of money to be withdrawn.</param>
        public void WithdrawMoney(decimal amount)
        {
            // Withdraw money from the checking account.
            decimal amountRemoved = this.CheckingAccount.RemoveMoney(amount);

            // Add the money removed from the account to the wallet.
            this.wallet.AddMoney(amountRemoved);
        }
    }
}